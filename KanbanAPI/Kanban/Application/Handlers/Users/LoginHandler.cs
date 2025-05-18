using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;

namespace Application.Handlers.Users;

public sealed record LoginCommand(string? Email, string? Username, string Password) : IRequest<Result<string>>;

internal class LoginHandler(IApplicationDbContext context, IPasswordHasher passwordHasher, ITokenProvider tokenProvider) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(request.Email) && string.IsNullOrEmpty(request.Username))
        {
            return Result.Failure<string>(UserErrors.CredentialsEmpty);
        }

        if (string.IsNullOrEmpty(request.Password)) return Result.Failure<string>(UserErrors.InvalidPasword);

        var user = await context.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .FirstOrDefaultAsync(u => u.Email == request.Email || u.Username == request.Username, cancellation);

        if (user == null) return Result.Failure<string>(UserErrors.NotFoundByEmailOrUsername);

        bool verified = passwordHasher.Verify(request.Password, user.Password);

        if (!verified) return Result.Failure<string>(UserErrors.InvalidPasword);

        string token = tokenProvider.Create(user);

        return string.IsNullOrEmpty(token)
               ? Result.Failure<string>(UserErrors.NotFoundByEmailOrUsername)
               : Result.Success(token);
    }
}
