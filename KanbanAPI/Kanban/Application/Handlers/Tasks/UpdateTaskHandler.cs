using Application.Abstractions.Behaviours;
using Application.Abstractions.Messaging.Events;
using Domain.GeneralErrors;
using Domain.ToDos;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Handlers.Tasks;

public sealed record UpdateTaskCommand
    (Guid Id, string Title, string? Description, string? DateStart, string? DateEnd, Priority Priority, Status Status, string ModifiedBy, uint RowVersion)
    : IRequest<Result<bool>>;
internal class UpdateTaskHandler(IApplicationDbContext context, IDateTimeProvider dateTimeProvider, IMediator mediator) : IRequestHandler<UpdateTaskCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateTaskCommand request, CancellationToken cancellation = default)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);

        context.Tasks.Entry(task).Property(t => t.RowVersion).OriginalValue = request.RowVersion;

        if (task == null) return Result.Failure<bool>(GeneralError.NotFoundWithGuid(typeof(ToDo).Name, request.Id));

        var entity = new ToDo
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            DateStart = request.DateStart,
            DateEnd = request.DateEnd,
            Priority = request.Priority,
            Status = request.Status,
            DateModified = dateTimeProvider.Now.ToString(),
            ModifiedBy = request.ModifiedBy,
        };

        context.Tasks.Update(entity);
        int response = await context.SaveChangesAsync(cancellation);

        if (response > 0)
        {
            await mediator.Publish(new TaskChangedEvent(entity, TaskChangeType.Updated), cancellation);
        }

        return response > 0
            ? Result.Success(true)
            : Result.Failure<bool>(ToDoErrors.UpdateError(request.Id));
    }
}
