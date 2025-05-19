using Application.Abstractions.Authentication;

namespace Application.Handlers.Users;

public sealed record RegisterUserCommand(string Email, string Username, string Password) : IRequest<Result<Guid>>;
public class RegisterUserHandler(IApplicationDbContext context, IDateTimeProvider dateTimeProvider, IPasswordHasher passwordHasher) : IRequestHandler<RegisterUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellation = default)
    {
        if(await context.Users.AnyAsync(u => u.Username == request.Username))
        {
            return Result.Failure<Guid>(UserErrors.UsernameNotUnique);
        }

        if (await context.Users.AnyAsync(u => u.Email == request.Email))
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Password = passwordHasher.Hash(request.Password),
            Username = request.Username,
            Email = request.Email,
            RoleId = Guid.Parse("121b4b8b-d3f9-4b88-ab11-857dc9941c3b"),
            CreatedBy = "self",
            DateCreated = dateTimeProvider.UtcNow.ToString()
        };

        user.Raise(new UserRegisterDomainEvent(user.Id));

        await context.Users.AddAsync(user, cancellation);
        await context.SaveChangesAsync(cancellation);

        return user.Id;
    }
}
