using System;
using System.Threading.Tasks;
using Xunit;
using Testcontainers.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application;
using Infrastructure;
using Application.Abstractions.Data;

public abstract class IntegrationTestBase : IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer;
    protected IServiceProvider ServiceProvider { get; private set; }

    protected IntegrationTestBase()
    {
        _dbContainer = new PostgreSqlBuilder()
            .WithDatabase("kanban_test")
            .WithUsername("postgres")
            .WithPassword("password")
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string>("ConnectionStrings:Database", _dbContainer.GetConnectionString())
            })
            .Build();

        // Register application & infra layers
        services
            .AddApplication()
            .AddInfrastructure(configuration);

        ServiceProvider = services.BuildServiceProvider();

        // Run EF Core migrations
        using var scope = ServiceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>() as DbContext;
        if (dbContext != null)
        {
            await dbContext.Database.MigrateAsync();
        }
    }

    public async Task DisposeAsync()
    {
        await _dbContainer.DisposeAsync();
    }
}