namespace Infrastructure.EntityConfigurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(
          new Role { Id = Guid.Parse("a11b1a7f-c5e0-45a0-ba0f-f68435c826eb"), Name = "Admin" },
          new Role { Id = Guid.Parse("121b4b8b-d3f9-4b88-ab11-857dc9941c3b"), Name = "User" }
      );
    }
}
