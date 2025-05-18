using Application.Abstractions.Data;
using Application.Abstractions.HATEOS;
using Application.Abstractions.Messaging;
using Domain.GeneralErrors;
using Domain.ToDos;

namespace Application.Handlers.Tasks;

public sealed record PaginateTasksQuery(bool? Status, int Page, int Size, string Sort) : IRequest<Result<PagedList<TodoResponse>>>;
internal class PaginateTasksHandler(IApplicationDbContext context, ILinkService linkService, ICacheService cache) 
    : IRequestHandler<PaginateTasksQuery, Result<PagedList<TodoResponse>>>
{
    public async Task<Result<PagedList<TodoResponse>>> Handle(PaginateTasksQuery request, CancellationToken cancellation = default)
    {
        string cacheKey = $"tasks:page={request.Page}:size={request.Size}:status={request.Status}:sort={request.Sort}";

        var cached = await cache.GetAsync<PagedList<TodoResponse>>(cacheKey);

        if (cached is not null)
            return Result.Success(cached);

        var query = context.Tasks
        .AsNoTracking();

        if (request.Status.HasValue)
            query = query.Where(x => x.isInProgress == request.Status.Value);

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
                isInProgress = x.isInProgress,
                DateEnd = x.DateEnd,
                DateStart = x.DateStart
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
