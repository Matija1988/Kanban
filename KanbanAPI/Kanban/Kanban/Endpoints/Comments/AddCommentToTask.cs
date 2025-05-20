using Application.Handlers.Comments;

namespace Kanban.Endpoints.Comments;

public sealed record CommentTaskRequest(Guid TaskId, string Text, string CreatedBy, string DateCreated);
public sealed class AddCommentToTask : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("api/comments",async (CommentTaskRequest request, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new CommentTaskCommand(request.TaskId, request.Text, request.CreatedBy, request.DateCreated);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Comments);
    }
}
