namespace Infrastructure.EntityConfigurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Role)
               .WithMany(r => r.Users)
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
           new User
           {
               Id = Guid.Parse("d20b73cf-aab9-459a-90d5-2d9f65bd4f91"),
               Username = "admin",
               Password = "$2a$12$pCF8WvWAwvDtSKZJtpm9ZuPxiibhVEm4t9j8M1mAEjsa55UdVCyF2",
               Email = "admin@example.com",
               RoleId = Guid.Parse("a11b1a7f-c5e0-45a0-ba0f-f68435c826eb"),
               DateCreated = DateTime.UtcNow.ToString(),
               CreatedBy = "seed",
           },
           new User
           {
               Id = Guid.Parse("a3b1e294-c106-4dd4-bce1-a97132d16c3d"),
               Username = "user1",
               Password = "$2a$12$KEY3WPXYB5ldI/fInlj3geJj12OCmXHu9AouvyKffORMypumTVtP.",
               Email = "user@example.com",
               RoleId = Guid.Parse("121b4b8b-d3f9-4b88-ab11-857dc9941c3b"),
               DateCreated = DateTime.UtcNow.ToString(),
               CreatedBy = "seed"
           },
           new User
           {
               Id = Guid.Parse("6d8de1aa-3d88-450a-a35c-408efd8f5bb2"),
               Username = "user2",
               Password = "$2a$12$dHimz4GciBJHZTDs4BoqruADW.wgIEPckq2ceCbJTkX9F.8GC/QoO",
               Email = "user2@example.com",
               RoleId = Guid.Parse("121b4b8b-d3f9-4b88-ab11-857dc9941c3b"),
               DateCreated = DateTime.UtcNow.ToString(),
               CreatedBy = "seed"
           }
       );
    }
}
