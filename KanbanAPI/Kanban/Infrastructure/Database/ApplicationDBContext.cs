using Common;
using Infrastructure.DomainEvents;

namespace Infrastructure.Database;

public sealed class ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbOpt, IDomainEventsDispatcher domainEventsDispatcher)
    : DbContext(dbOpt), IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ToDo> Tasks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<UserToDo> UserToDos { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync();
        await PublishDomainEventsAsync();
        return result;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                List<IDomainEvent> domainEvents = entity.DomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        await domainEventsDispatcher.DispatchAsync(domainEvents);
    }
}
