using Application.Abstractions.Messaging.Events;
using Microsoft.AspNetCore.SignalR;

namespace Application.Abstractions.Messaging.Handlers;

internal sealed class CommentNotificationHandler : INotificationHandler<CommentChangedEvents>
{
    private readonly ICacheService _cache;
    private readonly IHubContext<TaskHub> _hubContext;

    public CommentNotificationHandler(ICacheService cache, IHubContext<TaskHub> hubContext)
    {
        _cache = cache;
        _hubContext = hubContext;
    }

    public async Task Handle(CommentChangedEvents notification, CancellationToken cancellationToken = default)
    {
        string taskCachePattern = $"tasks:{notification.Comment.ToDoId}*";
        await _cache.RemoveByPatternAsync(taskCachePattern);

        await _cache.RemoveByPatternAsync($"comments:{notification.Comment.ToDoId}*");

        await _hubContext.Clients
           .Group(notification.Comment.ToDoId.ToString())
           .SendAsync("CommentCreated", new
           {
               TaskId = notification.Comment.ToDoId,
               CommentId = notification.Comment.Id,
               Text = notification.Comment.Tekst,
               CreatedBy = notification.Comment.CreatedBy,
               CreatedAt = notification.Comment.DateCreated
           });
    }
}
