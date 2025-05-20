using Domain.N2NEntities;

namespace Application.Handlers.Users;

public sealed record RemoveUsersFromTaskCommand(Guid TaskId, List<Guid> UserIds) : IRequest<Result<bool>>;
internal sealed class RemoveUsersFromTasksHandler(IApplicationDbContext context)
    : IRequestHandler<RemoveUsersFromTaskCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(RemoveUsersFromTaskCommand request, CancellationToken cancellation = default)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(x => x.Id == request.TaskId, cancellation);

        if (task == null) return Result.Failure<bool>(GeneralError.NotFoundWithGuid(typeof(ToDo).Name, request.TaskId));

        List<UserToDo> userToDos = new List<UserToDo>();

        foreach (var userId in request.UserIds)
        {
            var users = await context.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellation);

            if (users == null) continue;

            var userToDo = await context.UserToDos.FirstOrDefaultAsync(x => x.UserId  == userId && x.ToDoId == task.Id, cancellationToken: cancellation);

            userToDos.Add(userToDo);

            context.UserToDos.Remove(userToDo);
        }

        int success = await context.SaveChangesAsync(cancellation);

        return success > 0
            ? Result.Success(true)
            : Result.Failure<bool>(GeneralError.PostFailure(typeof(UserToDo).Name));
    }
}

