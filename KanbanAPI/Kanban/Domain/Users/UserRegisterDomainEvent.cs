using Common;

namespace Domain.Users;

public sealed class UserRegisterDomainEvent(Guid UserId) : IDomainEvent;
