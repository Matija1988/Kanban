using Application.Abstractions.Messaging.Events;
using Domain.GeneralErrors;

namespace Application.Handlers.Tasks;

public sealed record DeleteTaskCommand(Guid Id) : IRequest<Result<bool>>;
internal sealed class DeleteTaskHandler(IApplicationDbContext context, IMediator mediator) : IRequestHandler<DeleteTaskCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellation = default)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellation);

        if (task == null) return Result.Failure<bool>(GeneralError.NotFoundWithGuid(typeof(ToDo).Name, request.Id));

        context.Tasks.Remove(task);
       int success = await context.SaveChangesAsync(cancellation);

        if (success > 0)
        {
            await mediator.Publish(new TaskChangedEvent(task, TaskChangeType.Deleted), cancellation);
        }

        return success > 0
            ? Result.Success(true)
            : Result.Failure<bool>(GeneralError.UnexpectedError(typeof(ToDo).Name));
    }
}
