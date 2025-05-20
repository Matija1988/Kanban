using Application.Handlers.Tasks;

namespace Kanban.Endpoints.ToDo;

public sealed class DeleteTask : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapDelete("api/tasks/{id}", async (Guid id, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new DeleteTaskCommand(id);

            var result = await sender.Send(command, cancellationToken); 

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Tasks);
    }
}
