using Domain.Comments;

namespace Application.Abstractions.Messaging.Events;

public record CommentChangedEvents(Comment Comment, CommentChangeType ChangeType) : INotification;