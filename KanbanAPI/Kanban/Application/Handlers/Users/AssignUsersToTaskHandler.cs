using Domain.N2NEntities;

namespace Application.Handlers.Users;

public sealed record AssignUsersToTaskCommand(Guid TaskId, List<Guid> UserIds) : IRequest<Result<bool>>;
internal sealed class AssignUsersToTaskHandler(IApplicationDbContext context, IDateTimeProvider dateTimeProvider) : IRequestHandler<AssignUsersToTaskCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(AssignUsersToTaskCommand request, CancellationToken cancellation = default)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.TaskId, cancellation);

        if(task == null) return Result.Failure<bool>(GeneralError.NotFoundWithGuid(typeof(ToDo).Name, request.TaskId));

        List<UserToDo> userToDos = new List<UserToDo>();

        foreach (var userId in request.UserIds) 
        {
            var users = await context.Users.FirstOrDefaultAsync(x =>x.Id == userId, cancellation);

            if (users == null) continue;

            var userToDo = new UserToDo
            {
                Id = Guid.NewGuid(),
                ToDoId = request.TaskId,
                UserId = userId,
                AssignedDate = dateTimeProvider.Now.ToString(),
            };

            userToDos.Add(userToDo);
        }

        await context.UserToDos.AddRangeAsync(userToDos, cancellation);
        int success = await context.SaveChangesAsync(cancellation);

        return success > 0
            ? Result.Success(true)
            : Result.Failure<bool>(GeneralError.PostFailure(typeof(UserToDo).Name));    
    }
}
