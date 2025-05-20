using Application.Abstractions.HATEOS;
using Domain.GeneralErrors;

namespace Application.Handlers.Tasks;

public sealed record PaginateTasksQuery(Status? Status, int Page, int Size, string Sort) : IRequest<Result<PagedList<TodoResponse>>>;
internal class PaginateTasksHandler(IApplicationDbContext context, ILinkService linkService, ICacheService cache) 
    : IRequestHandler<PaginateTasksQuery, Result<PagedList<TodoResponse>>>
{
    public async Task<Result<PagedList<TodoResponse>>> Handle(PaginateTasksQuery request, CancellationToken cancellation = default)
    {
        string cacheKey = $"tasks:page={request.Page}:size={request.Size}:status={request.Status}:sort={request.Sort}";

        var cached = await cache.GetAsync<PagedList<TodoResponse>>(cacheKey);

        if (cached is not null)
            return Result.Success(cached);

        IQueryable<ToDo> query = context.Tasks
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Comments)
            .Include(x => x.UserToDos)
            .ThenInclude(x => x.User);

        if (request.Status != null)
            query = query.Where(x => x.Status == request.Status);

        var projectedQuery = query
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

         Comments = x.Comments.Select(c => new CommentResponse(
             c.Id,
             c.DateCreated,
             c.CreatedBy ?? "",
             c.Tekst
         )).ToList(),

         Users = x.UserToDos.Select(ut => new UserResponse(
             ut.User.Id,
             ut.User.Username,
             ut.User.Email,
             ut.User.Role.Name
         )).ToList()
     });

        var pagedList = await PagedList<TodoResponse>.CreateAsync(projectedQuery, request.Page, request.Size);

        if (pagedList.Items.Count == 0)
            return Result.Failure<PagedList<TodoResponse>>(GeneralError.NoEntities(nameof(ToDo)));

        AddLinks(pagedList, request);

        await cache.SetAsync(cacheKey, pagedList, TimeSpan.FromMinutes(5));

        return Result.Success(pagedList);
    }

    private void AddLinks(PagedList<TodoResponse> responses, PaginateTasksQuery query)
    {
        responses.Links.Add(linkService.Generate("PaginateTasks",
               new
               {
                   status = query.Status,
                   page = query.Page,
                   size = query.Size,
                   sort = query.Sort,
               },
               "self",
               "GET"));

        if (responses.HasNextPage)
       {
            responses.Links.Add(linkService.Generate("PaginateTasks",
                new
                {
                    status = query.Status,
                    page = query.Page + 1,
                    size = query.Size,
                    sort = query.Sort,
                },
                "next-page",
                "GET"));
        }

        if (responses.HasPreviousPage)
        {
            responses.Links.Add(linkService.Generate("PaginateTasks",
                new
                {
                    status = query.Status,
                    page = query.Page - 1,
                    size = query.Size,
                    sort = query.Sort,
                },
                "previous-page",
                "GET"));
        }
    } 
}
