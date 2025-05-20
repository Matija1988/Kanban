namespace Kanban.Endpoints.User;

public sealed class RegisterUser : IEndpoint
{
    public sealed record RegisterUserRequest(string Email, string Username, string Password);
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("api/register", async (RegisterUserRequest request, IMediator sender, CancellationToken cancellationToken) =>
        {
            var command = new RegisterUserCommand(request.Email, request.Username, request.Password);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Users);
    }  
}
