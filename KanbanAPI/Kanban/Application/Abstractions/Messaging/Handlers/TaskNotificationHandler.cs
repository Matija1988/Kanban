
using Application.Abstractions.Messaging.Events;
using Microsoft.AspNetCore.SignalR;

namespace Application.Abstractions.Messaging.Handlers;

public sealed class TaskNotificationHandler : INotificationHandler<TaskCreatedEvent>
{
    private readonly ICacheService _cache;
    private readonly IHubContext<TaskHub> _hubContext;

    public TaskNotificationHandler(ICacheService cache, IHubContext<TaskHub> hubContext)
    {
        _cache = cache;
        _hubContext = hubContext;
    }

    public async Task Handle(TaskCreatedEvent notification, CancellationToken cancellationToken)
    {
        await _cache.RemoveByPatternAsync("tasks:*");
        await _hubContext.Clients.All.SendAsync("TaskCreated", new
        {
            TaskId = notification.Task.Id,
            Title = notification.Task.Title,
            CreatedAt = notification.Task.DateCreated
        });
    }
}
