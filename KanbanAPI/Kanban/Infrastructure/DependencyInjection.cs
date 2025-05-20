using Application.Abstractions.Authentication;
using Common;
using Infrastructure.Authentication;
using Infrastructure.Authorization;
using Infrastructure.Caching;
using Infrastructure.DomainEvents;
using Infrastructure.Time;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
        .AddServices()
        .AddDatabase(configuration)
        .AddCachingService()
        .AddHealthChecks(configuration)
        .AddAuthenticationInternal(configuration)
        .AddAuthorizationInternal();

    private static IServiceCollection AddCachingService(this IServiceCollection services)
    {
        services.AddScoped<ICacheService, RedisCacheService>();
        services.AddHostedService<TaskCachePreloader>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IDomainEventsDispatcher, DomainEventsDispatcher>();
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApplicationDBContext>(
            options => options
            .UseNpgsql(connectionString, sqlOptions =>
            sqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "public")));

        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDBContext>());

        return services;
    }

    private static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("Database")!);

        return services;
    }

    private static IServiceCollection AddAuthenticationInternal(
      this IServiceCollection service,
      IConfiguration configuration)
    {
        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!)),
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero,
                };
            });

        service.AddHttpContextAccessor();
        service.AddScoped<IUserContext, UserContext>();
        service.AddSingleton<IPasswordHasher, PasswordHasher>();
        service.AddSingleton<ITokenProvider, TokenProvider>();

        return service;
    }

    private static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
        });

        services.AddScoped<PermissionProvider>();
        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

        return services;
    }
}
