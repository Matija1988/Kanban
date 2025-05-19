namespace Application.Handlers;

public sealed record CommentResponse(Guid Id, string DateCreated, string CreatedBy, string Tekst);
