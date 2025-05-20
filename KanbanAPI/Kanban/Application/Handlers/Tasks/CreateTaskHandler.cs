using Application.Abstractions.Messaging.Events;
using Domain.GeneralErrors;
namespace Application.Handlers.Tasks;

public sealed record CreateToDoCommand
    (string Title, string? Description, string DateTimeStart, string DateTimeEnd, string CreatedBy, Priority Priority, Status Status) : IRequest<Result<int>>;

internal sealed class CreateTaskHandler(IApplicationDbContext context, IDateTimeProvider dateTimeProvider, IMediator mediator)
    : IRequestHandler<CreateToDoCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateToDoCommand request, CancellationToken cancellation = default)
    {
        var chkDateRange = CheckDateRange(request);

        if (chkDateRange.IsFailure) return Result.Failure<int>(chkDateRange.Error);

        var toDo = new ToDo
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            DateStart = DateTime.Parse(request.DateTimeStart).ToString(),
            DateEnd = DateTime.Parse(request.DateTimeEnd).ToString(),
            CreatedBy = request.CreatedBy,
            Priority = request.Priority,
            Status = request.Status,
            DateCreated = dateTimeProvider.Now.ToString()
        };

        await context.Tasks.AddAsync(toDo, cancellation);
        int success = await context.SaveChangesAsync(cancellation);

        if(success > 0)
        {
            await mediator.Publish(new TaskChangedEvent(toDo), cancellation);
        }

        return success > 0
            ? Result.Success(success)
            : Result.Failure<int>(GeneralError.PostFailure(typeof(ToDo).Name));
    }

    private Result CheckDateRange(CreateToDoCommand request)
    {
        var now = dateTimeProvider.Now;

        if (DateTime.Parse(request.DateTimeStart) < now) return Result.Failure(DateTimeErrors.ProjectStartDateAfterToday());
        if (DateTime.Parse(request.DateTimeEnd) < DateTime.Parse(request.DateTimeStart)) return Result.Failure(DateTimeErrors.ProjectCannotEndBeforeItBegins());

        return Result.Success();
    }
}
