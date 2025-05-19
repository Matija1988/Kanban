using Application.Handlers.Tasks;

namespace Kanban.Endpoints.ToDo;

public class GetTask : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("api/tasks/{id}", async (Guid Id, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new GetTaskDetailsQuery(Id);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Tasks);
    }
}
