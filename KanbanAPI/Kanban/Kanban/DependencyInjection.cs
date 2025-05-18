using Application.Abstractions.HATEOS;
using Kanban.Services;
using KanbanAPI.Infrastructure;
using StackExchange.Redis;

namespace KanbanAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        services.AddScoped<ILinkService, LinkService>();
        services.AddHttpContextAccessor();

        return services;
    }
}