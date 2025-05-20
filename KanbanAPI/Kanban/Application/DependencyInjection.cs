using Application.Abstractions.Behaviours;
using Application.Abstractions.Messaging.Events;
using Application.Abstractions.Messaging.Handlers;
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
        services.AddScoped<INotificationHandler<TaskChangedEvent>, TaskNotificationHandler>();
        services.AddScoped<INotificationHandler<CommentChangedEvents>, CommentNotificationHandler>();

        services.AddTransient<IRequestHandler<PaginateTasksQuery, Result<PagedList<TodoResponse>>>, PaginateTasksHandler>();
        services.AddTransient<IRequestHandler<GetTaskDetailsQuery, Result<TodoResponse>>, GetTaskDetails>();
        services.AddTransient<IRequestHandler<UpdateTaskCommand, Result<bool>>, UpdateTaskHandler>();
        services.AddTransient<IRequestHandler<CreateToDoCommand, Result<int>>, CreateTaskHandler>();
        services.AddTransient<IRequestHandler<DeleteTaskCommand, Result<bool>>, DeleteTaskHandler>();

        services.AddTransient<IRequestHandler<ChangeTaskStatusPriorityCommand, Result<bool>>, ChangeTaskStatusPriority>();

        services.AddTransient<IRequestHandler<CommentTaskCommand, Result<Guid>>, CommentTaskHandler>();
        services.AddTransient<IRequestHandler<DeleteCommentCommand, Result<bool>>, DeleteCommentHandler>();
        services.AddTransient<IRequestHandler<ChangeCommentCommand, Result<bool>>, ChangeCommentHandler>();

        services.AddTransient<IRequestHandler<AssignUsersToTaskCommand, Result<bool>>, AssignUsersToTaskHandler>();
        services.AddTransient<IRequestHandler<RemoveUsersFromTaskCommand, Result<bool>>, RemoveUsersFromTasksHandler>();

        services.AddTransient<IRequestHandler<LoginCommand, Result<string>>, LoginHandler>();
        services.AddTransient<IRequestHandler<RegisterUserCommand, Result<Guid>>, RegisterUserHandler>();  

        services.AddValidatorsFromAssembly(typeof(DependancyInjection).Assembly,
            includeInternalTypes: true);

        return services;
    }
}