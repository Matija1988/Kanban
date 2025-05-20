using Application.Handlers.Tasks;

namespace Kanban.Endpoints.ToDo;

public sealed record PatchStatusPriorityRequest(Status? Status, Priority? Priority);
public sealed class PatchTaskStatusPriority : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPatch("api/tasks/{id}", async (Guid id, PatchStatusPriorityRequest request, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new ChangeTaskStatusPriorityCommand(id, request.Status, request.Priority);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Tasks);
    }
}
