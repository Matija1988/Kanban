
using Application.Handlers.Tasks;

namespace Kanban.Endpoints.ToDo;

public class Post : IEndpoint
{
    public sealed record PostTodoRequest
    (string Title, string? Description, string DateTimeStart, string DateTimeEnd, string CreatedBy, Priority Priority, Status Status) : IRequest<Result<int>>;
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("api/tasks", async (PostTodoRequest request, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateToDoCommand(request.Title, request.Description, request.DateTimeStart, request.DateTimeEnd, request.CreatedBy, request.Priority, request.Status);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Tasks);
    }
}
