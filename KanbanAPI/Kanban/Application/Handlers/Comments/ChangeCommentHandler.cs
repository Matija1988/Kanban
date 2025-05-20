using Application.Abstractions.Messaging.Events;

namespace Application.Handlers.Comments;

public sealed record ChangeCommentCommand(Guid CommentId, string Tekst, string ModifiedBy, string DateModified) : IRequest<Result<bool>>;
internal sealed class ChangeCommentHandler(IApplicationDbContext context, IMediator mediator) : IRequestHandler<ChangeCommentCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(ChangeCommentCommand request, CancellationToken cancellation = default)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(x => x.Id == request.CommentId);

        if (comment == null) return Result.Failure<bool>(GeneralError.NotFoundWithGuid(typeof(Comment).Name, request.CommentId));

        comment.Tekst = request.Tekst;
        comment.ModifiedBy = request.ModifiedBy;
        comment.DateModified = request.DateModified;

        int success = await context.SaveChangesAsync(cancellation);

        if (success > 0)
        {
            await mediator.Publish(new CommentChangedEvents(comment, CommentChangeType.Updated), cancellation);
        }

        return success > 0
            ? Result.Success(true)
            : Result.Failure<bool>(GeneralError.UnexpectedError(typeof(Comment).Name));
    }
}
