
using Application.Handlers.Tasks;

namespace Kanban.Endpoints.ToDo;

public class UpdateTask : IEndpoint
{
    public sealed record UpdateTaskRequest
    (Guid Id, string Title, string? Description, string? DateStart, string? DateEnd, Priority Priority, Status Status, string ModifiedBy, uint RowVersion);
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPut("api/tasks", async (UpdateTaskRequest request, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new UpdateTaskCommand
            (request.Id, request.Title, request.Description, request.DateStart, request.DateEnd, request.Priority, request.Status, request.ModifiedBy, request.RowVersion);
            
            var result = await sender.Send(command,cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Tasks);
    }
}
