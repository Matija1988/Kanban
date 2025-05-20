using Application;
using Infrastructure;
using Infrastructure.EntityConfigurations.DataSeed;
using KanbanAPI;
using Serilog;
using StackExchange.Redis;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddSwaggerGenWithAuth();

builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

var redisConfig = builder.Configuration.GetSection("Redis")["ConnectionString"];
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect(redisConfig));

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!, name: "postgresql", tags: new[] { "db", "sql" })
    .AddRedis(builder.Configuration["Redis:ConnectionString"], name: "redis", tags: new[] { "cache", "redis" });

builder.Services.AddHealthChecksUI(options =>
{
    options.SetEvaluationTimeInSeconds(15);
    options.MaximumHistoryEntriesPerEndpoint(60);
    options.AddHealthCheckEndpoint("Basic Health", "http://localhost:8080/healthz");
}).AddInMemoryStorage();

builder.Services.AddSignalR();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
//}

app.MapEndpoints();
app.ApplyCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
}

if (app.Environment.IsDevelopment() || Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
{
    app.ApplyMigrations();

}

app.UseSerilogRequestLogging();
app.UseRequestContextLogging();

app.UseStaticFiles();

app.UseExceptionHandler();

app.UseRateLimiter();

app.UseAuthentication();

app.UseAuthorization();

await app.RunAsync();

namespace KanbanApi
{
    public partial class Program;
}