using Application.Abstractions.Messaging.Events;
using Microsoft.AspNetCore.SignalR;

namespace Application.Abstractions.Messaging.Handlers;

public sealed class TaskNotificationHandler : INotificationHandler<TaskChangedEvent>
{
    private readonly ICacheService _cache;
    private readonly IHubContext<TaskHub> _hubContext;

    public TaskNotificationHandler(ICacheService cache, IHubContext<TaskHub> hubContext)
    {
        _cache = cache;
        _hubContext = hubContext;
    }

    public async Task Handle(TaskChangedEvent notification, CancellationToken cancellationToken)
    {
        await _cache.RemoveByPatternAsync("tasks:*");

        string eventName = notification.ChangeType switch
        {
            TaskChangeType.Created => "TaskCreated",
            TaskChangeType.Updated => "TaskUpdated",
            TaskChangeType.Deleted => "TaskDeleted",
            _ => "TaskChanged"
        };

        await _hubContext.Clients.All.SendAsync(eventName, new
        {
            TaskId = notification.Task.Id,
            Title = notification.Task.Title,
            Status = notification.Task.Status.ToString(),
            Priority = notification.Task.Priority.ToString(),
            ModifiedAt = notification.Task.DateModified ?? notification.Task.DateCreated
        });
    }
}
