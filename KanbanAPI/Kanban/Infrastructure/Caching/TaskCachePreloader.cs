using Application.Handlers.Tasks;
using Application.Handlers;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Caching;

public sealed class TaskCachePreloader : IHostedService
{
    private readonly IServiceProvider _services;

    public TaskCachePreloader(IServiceProvider services)
    {
        _services = services;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        var cache = scope.ServiceProvider.GetRequiredService<ICacheService>();

        var query = dbContext.Tasks
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Comments)
            .Include(x => x.UserToDos)
            .ThenInclude(x => x.User)
            .OrderBy(x => x.DateCreated)
            .Select(x => new TodoResponse
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                CreatedBy = x.CreatedBy ?? "",
                DateModified = x.DateModified,
                ModifiedBy = x.ModifiedBy,
                Title = x.Title,
                Description = x.Description,
                DateEnd = x.DateEnd,
                DateStart = x.DateStart,
                Status = x.Status.ToString(),
                Priority = x.Priority.ToString(),
                RowVersion = x.RowVersion.ToString(),
                Comments = x.Comments.Select(c => 
                new CommentResponse(
                    c.Id, 
                    c.DateCreated, 
                    c.CreatedBy ?? "",
                    c.Tekst))
                .ToList(),

                Users = x.UserToDos.Select(
                    ut => new UserResponse(
                    ut.User.Id, 
                    ut.User.Username, 
                    ut.User.Email, 
                    ut.User.Role.Name))
                .ToList()
            });

        int page = 1, size = 100;
        var pagedList = await PagedList<TodoResponse>.CreateAsync(query, page, size);

        string cacheKey = $"tasks:page={page}:size={size}:status=:sort=DateCreated";
        await cache.SetAsync(cacheKey, pagedList, TimeSpan.FromMinutes(5));
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

