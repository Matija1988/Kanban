namespace Infrastructure.EntityConfigurations;

internal sealed class UserToDoConfiguration : IEntityTypeConfiguration<UserToDo>
{
    public void Configure(EntityTypeBuilder<UserToDo> builder)
    {
        builder.HasKey(ut => new { ut.UserId, ut.ToDoId });

        builder.HasOne(ut => ut.User)
               .WithMany(u => u.UserToDos)
               .HasForeignKey(ut => ut.UserId);

        builder.HasOne(ut => ut.ToDo)
               .WithMany(t => t.UserToDos)
               .HasForeignKey(ut => ut.ToDoId);

        builder.Property(ut => ut.AssignedDate)
               .IsRequired();

        builder.HasData(
        new UserToDo
        {
            Id = Guid.Parse("b68ec62d-c943-40ba-a652-3a226bb36a66"),
            UserId = Guid.Parse("a3b1e294-c106-4dd4-bce1-a97132d16c3d"),
            ToDoId = Guid.Parse("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"),
            AssignedDate = DateTime.UtcNow.ToString(),
        },
        new UserToDo
        {
            Id = Guid.Parse("32e4c3bb-900b-4dd5-b7f6-18277027985d"),
            UserId = Guid.Parse("6d8de1aa-3d88-450a-a35c-408efd8f5bb2"),
            ToDoId = Guid.Parse("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"),
            AssignedDate = DateTime.UtcNow.ToString(),
        }
        );
    }
}