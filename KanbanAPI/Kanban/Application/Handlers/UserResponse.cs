namespace Application.Handlers;

public record class UserResponse(Guid Id, string Username, string Email, string Role);
