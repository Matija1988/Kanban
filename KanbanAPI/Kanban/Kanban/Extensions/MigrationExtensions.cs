using Infrastructure.Database;
using Infrastructure.EntityConfigurations.DataSeed;

namespace KanbanAPI.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ApplicationDBContext dbContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

        dbContext.Database.Migrate();
    }
}
