using Common;

namespace Domain.ToDos;

public static class ToDoErrors
{
    public static Error UpdateError(Guid Id) => Error.NotFound(
     "Task.UpdateError",
     $"Unable to update Task with id = {Id}!");
}
