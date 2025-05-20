using Application.Abstractions.Messaging.Events;
using Microsoft.AspNetCore.SignalR;

namespace Application.Abstractions.Messaging.Handlers;

internal sealed class UserTodoNotificationHandler : INotificationHandler<UserToDoEvent>
{
    private readonly ICacheService _cache;
    private readonly IHubContext<TaskHub> _hubContext;

    public UserTodoNotificationHandler(ICacheService cache, IHubContext<TaskHub> hubContext)
    {
        _cache = cache;
        _hubContext = hubContext;
    }
    public async Task Handle(UserToDoEvent notification, CancellationToken cancellationToken = default)
    {
        string taskCachePattern = $"tasks:{notification.userToDo.ToDoId}*";
        await _cache.RemoveByPatternAsync(taskCachePattern);

        await _cache.RemoveByPatternAsync($"userToDo:{notification.userToDo.ToDoId}*");

        await _hubContext.Clients
           .Group(notification.userToDo.ToDoId.ToString())
           .SendAsync("UserToDo", new
           {
               TaskId = notification.userToDo.ToDoId,
               UserId = notification.userToDo.UserId,
           });
    }
}
