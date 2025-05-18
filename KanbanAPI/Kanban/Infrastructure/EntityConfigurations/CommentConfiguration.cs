namespace Infrastructure.EntityConfigurations;

internal sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasData(
            new Comment
            {
                Id = Guid.Parse("ae6139d2-375c-40df-b5ab-293346277d2f"),
                DateCreated = DateTime.UtcNow.ToString(),
                DateModified = DateTime.UtcNow.ToString(),
                CreatedBy = "user1",
                Tekst = "We will overload the flux capacitors!",
                ToDoId = Guid.Parse("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47")
            }
           );
    }
}
