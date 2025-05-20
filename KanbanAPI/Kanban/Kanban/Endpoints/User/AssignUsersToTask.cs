using Microsoft.AspNetCore.Mvc;

namespace Kanban.Endpoints.User;

public sealed class AssignUsersToTask : IEndpoint
{
    public sealed record AssignUsersToTaskRequest(Guid TaskId, List<Guid> UserIds);
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("api/userTasks", async ([FromBody] AssignUsersToTaskRequest request, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new AssignUsersToTaskCommand(request.TaskId, request.UserIds);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
         .WithTags(Tags.UserTask);
    }
}
