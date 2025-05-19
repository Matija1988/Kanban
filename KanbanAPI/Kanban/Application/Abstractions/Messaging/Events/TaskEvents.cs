namespace Application.Abstractions.Messaging.Events;

public record TaskCreatedEvent(ToDo Task) : INotification;