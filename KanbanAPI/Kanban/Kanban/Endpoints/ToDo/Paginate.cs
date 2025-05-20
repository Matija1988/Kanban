using Application.Handlers.Tasks;

namespace KanbanAPI.Endpoints.ToDo;

public sealed class Paginate : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("api/tasks", async(Status? status, int page, int size, string? sort, IMediator sender, CancellationToken token) =>
        {
            var command = new PaginateTasksQuery(status, page, size, sort);

            var result = await sender.Send(command, token);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithName("PaginateTasks")
        .WithTags(Tags.Tasks);
    }
}
