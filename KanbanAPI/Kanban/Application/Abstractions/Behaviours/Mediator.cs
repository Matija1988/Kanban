using Application.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Abstractions.Behaviours;

public class Mediator(IServiceProvider provider) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var requestType = request.GetType();
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));
        dynamic handler = provider.GetRequiredService(handlerType);

        var behaviors = provider
            .GetServices(typeof(IPipelineBehavior<,>).MakeGenericType(requestType, typeof(TResponse)))
            .Cast<dynamic>()
            .Reverse()
            .ToList();

        Func<Task<TResponse>> handlerDelegate = () => handler.Handle((dynamic)request, cancellationToken);

        foreach (var behavior in behaviors)
        {
            var next = handlerDelegate;
            handlerDelegate = () => behavior.Handle((dynamic)request, next, cancellationToken);
        }

        return await handlerDelegate();
    }
    public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
       where TNotification : INotification
    {
        var handlers = provider
            .GetServices<INotificationHandler<TNotification>>()
            .ToList();

        foreach (var handler in handlers)
        {
            await handler.Handle(notification, cancellationToken);
        }
    }
}