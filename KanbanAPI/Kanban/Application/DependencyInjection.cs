using Application.Abstractions.Behaviours;
using Application.Abstractions.Messaging;
using Application.Handlers.Tasks;
using Application.Handlers.Users;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Application;


public static class DependancyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
             
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehavior<,>));

        services.AddScoped<INotificationHandler<MyEvent>, MyEventHandler>();

        services.AddScoped<IRequestHandler<PaginateTasksQuery, Result<PagedList<TodoResponse>>>, PaginateTasksHandler>();

        services.AddScoped<IRequestHandler<LoginCommand, Result<string>>, LoginHandler>();

        services.AddValidatorsFromAssembly(typeof(DependancyInjection).Assembly,
            includeInternalTypes: true);

        return services;
    }
}