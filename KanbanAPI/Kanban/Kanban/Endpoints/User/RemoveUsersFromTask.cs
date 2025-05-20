using Microsoft.AspNetCore.Mvc;

namespace Kanban.Endpoints.User;

public class RemoveUsersFromTask : IEndpoint
{
    public sealed record RemoveUsersFromTaskRequest(Guid TaskId, List<Guid> UserIds);
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapDelete("api/userTasks", async ([FromBody] RemoveUsersFromTaskRequest request, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new RemoveUsersFromTaskCommand(request.TaskId, request.UserIds);

            Result<bool> result = await sender.Send(command,cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.UserTask);
    }
}
