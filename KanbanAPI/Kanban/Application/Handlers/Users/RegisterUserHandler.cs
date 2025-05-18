using Application.Abstractions.Messaging;

namespace Application.Handlers.Users;

public sealed record RegisterUserCommand(string Email, string Username, string Password) : IRequest<Result<bool>>;
public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<bool>>
{
    public Task<Result<bool>> Handle(RegisterUserCommand request, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }
}
