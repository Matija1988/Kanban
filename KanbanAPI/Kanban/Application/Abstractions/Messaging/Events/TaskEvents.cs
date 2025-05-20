namespace Application.Abstractions.Messaging.Events;

public record TaskChangedEvent(ToDo Task, TaskChangeType ChangeType) : INotification;