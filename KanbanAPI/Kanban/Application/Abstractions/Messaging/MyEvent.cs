namespace Application.Abstractions.Messaging;

public sealed class MyEvent(Guid EntityId) : INotification;

public class MyEventHandler : INotificationHandler<MyEvent>
{
    public Task Handle(MyEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}