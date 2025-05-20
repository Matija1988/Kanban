using Application.Handlers.Comments;

namespace Kanban.Endpoints.Comments;

public sealed record ChangeCommentRequest(string Text, string ModifiedBy, string DateModified);
public sealed class ChangeComment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPut("api/comments/{id}", async (Guid Id, ChangeCommentRequest request, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new ChangeCommentCommand(Id, request.Text, request.ModifiedBy, request.DateModified);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Comments);
    }
}
