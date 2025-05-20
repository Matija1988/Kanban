using Application.Handlers.Comments;

namespace Kanban.Endpoints.Comments;

public sealed class DeleteComment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapDelete("api/comments/{id}", async (Guid Id, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new DeleteCommentCommand(Id);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Comments);
    }
}
