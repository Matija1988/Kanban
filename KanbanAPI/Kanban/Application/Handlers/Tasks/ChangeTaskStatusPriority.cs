using Application.Abstractions.Messaging.Events;
using Domain.GeneralErrors;

namespace Application.Handlers.Tasks;

public sealed record ChangeTaskStatusPriorityCommand(Guid Id, Status? Status, Priority? Priority) : IRequest<Result<bool>>;
internal sealed class ChangeTaskStatusPriority(IApplicationDbContext context, IMediator mediator) 
    : IRequestHandler<ChangeTaskStatusPriorityCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(ChangeTaskStatusPriorityCommand request, CancellationToken cancellationToken = default)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (task == null) return Result.Failure<bool>(GeneralError.NotFoundWithGuid(typeof(ToDo).Name, request.Id));

        task.Status = request.Status ?? task.Status;
        task.Priority = request.Priority ?? task.Priority;

        int success = await context.SaveChangesAsync(cancellationToken);

        if (success > 0)
        {
            await mediator.Publish(new TaskChangedEvent(task, TaskChangeType.Updated), cancellationToken);
        }

        return success > 0
            ? Result.Success(true)
            : Result.Failure<bool>(GeneralError.UnexpectedError(typeof(ToDo).Name));
    }
}
