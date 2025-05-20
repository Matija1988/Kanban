namespace Kanban.Endpoints.User;

public sealed class Login : IEndpoint
{
    public sealed record LoginRequest(string? Email, string? Username, string Password);
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("api/login", async (LoginRequest request, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new LoginCommand(request.Email, request.Username, request.Password);

            Result<string> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Users);
    }
}
