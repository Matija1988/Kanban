using Application.Abstractions.Messaging.Events;
using Domain.Comments;
using Domain.GeneralErrors;

namespace Application.Handlers.Comments;

public sealed record CommentTaskCommand(Guid TaskId, string Text, string CreatedBy, string DateCreated) : IRequest<Result<Guid>>;
internal class CommentTask(IApplicationDbContext context, IMediator mediator)
    : IRequestHandler<CommentTaskCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CommentTaskCommand request, CancellationToken cancellation = default)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.TaskId, cancellationToken: cancellation);

        if (task == null) return Result.Failure<Guid>(GeneralError.NotFoundWithGuid(typeof(ToDo).Name, request.TaskId));

        var comment = new Comment
        {
            Id = Guid.NewGuid(),
            ToDoId = task.Id,
            Tekst = request.Text,
            CreatedBy = request.CreatedBy,
            DateCreated = request.DateCreated,
        };

        await context.Comments.AddAsync(comment, cancellation);
        int success = await context.SaveChangesAsync(cancellation);

        if (success > 0)
        {
            await mediator.Publish(new CommentChangedEvents(comment, CommentChangeType.Created), cancellation);
        }

        return success > 0
            ? Result.Success(comment.Id)
            : Result.Failure<Guid>(GeneralError.PostFailure(typeof(Comment).Name));
    }
}
