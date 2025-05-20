using Application.Abstractions.Messaging.Events;

namespace Application.Handlers.Comments;

public sealed record DeleteCommentCommand(Guid Id) : IRequest<Result<bool>>;
internal sealed class DeleteCommentHandler(IApplicationDbContext context, IMediator mediator) : IRequestHandler<DeleteCommentCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteCommentCommand request, CancellationToken cancellation = default)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellation);

        if (comment == null) return Result.Failure<bool>(GeneralError.NotFoundWithGuid(typeof(Comment).Name, request.Id));

        context.Comments.Remove(comment);
        int success = await context.SaveChangesAsync(cancellation);

        if (success > 0)
        {
            await mediator.Publish(new CommentChangedEvents(comment, CommentChangeType.Deleted), cancellation);
        }

        return success > 0
            ? Result.Success(true)
            : Result.Failure<bool>(GeneralError.UnexpectedError(typeof(Comment).Name));
    }
}
