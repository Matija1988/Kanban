using Application.Abstractions.Messaging.Events;

namespace Application.Handlers.Tasks;

public sealed record UpdateTaskCommand
    (Guid Id, string Title, string? Description, string? DateTimeStart, string? DateTimeEnd, Priority Priority, Status Status, string ModifiedBy, uint RowVersion)
    : IRequest<Result<bool>>;
internal class UpdateTaskHandler(IApplicationDbContext context, IDateTimeProvider dateTimeProvider, IMediator mediator) : IRequestHandler<UpdateTaskCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellation = default)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (task == null) return Result.Failure<bool>(GeneralError.NotFoundWithGuid(typeof(ToDo).Name, request.Id));

        var chkDateRange = CheckDateRange(request);

        context.Tasks.Entry(task).Property(t => t.RowVersion).OriginalValue = request.RowVersion;

        var user = await context.Users.FirstOrDefaultAsync(x => x.Username == request.ModifiedBy, cancellationToken: cancellation);

        if (user == null) return Result.Failure<bool>(UserErrors.NotFoundByEmailOrUsername);

        task.Id = request.Id;
        task.Title = request.Title;
        task.Description = request.Description;
        task.DateStart = request.DateTimeStart ?? task.DateStart;
        task.DateEnd = request.DateTimeEnd ?? task.DateEnd;
        task.Priority = request.Priority;
        task.Status = request.Status;
        task.ModifiedBy = request.ModifiedBy;
        task.DateModified = dateTimeProvider.Now.ToString();

        int response = await context.SaveChangesAsync(cancellation);

        if (response > 0)
        {
            await mediator.Publish(new TaskChangedEvent(task, TaskChangeType.Updated), cancellation);
        }

        return response > 0
            ? Result.Success(true)
            : Result.Failure<bool>(ToDoErrors.UpdateError(request.Id));
    }

    private Result CheckDateRange(UpdateTaskCommand request)
    {
        var now = dateTimeProvider.Now;

        if (!string.IsNullOrEmpty(request.DateTimeStart) && DateTime.Parse(request.DateTimeStart) < now) 
            return Result.Failure(DateTimeErrors.ProjectStartDateAfterToday());

        if (!string.IsNullOrEmpty(request.DateTimeStart) && !string.IsNullOrEmpty(request.DateTimeEnd) 
            && DateTime.Parse(request.DateTimeEnd) < DateTime.Parse(request.DateTimeStart)) 
            return Result.Failure(DateTimeErrors.ProjectCannotEndBeforeItBegins());

        return Result.Success();
    }
}
