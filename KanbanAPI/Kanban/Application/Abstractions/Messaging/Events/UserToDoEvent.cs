using Domain.N2NEntities;

namespace Application.Abstractions.Messaging.Events;

public record UserToDoEvent(UserToDo userToDo, UserToDoChangeType userToDoChangeType) : INotification; 