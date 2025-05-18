using Application.Abstractions.Messaging;
using Microsoft.Extensions.Logging;

namespace Application.Abstractions.Behaviours;

public class RequestLoggingBehavior<TRequest, TResponse>(ILogger<RequestLoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        Func<Task<TResponse>> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        logger.LogInformation("Handling {RequestName}", requestName);

        var response = await next();

        if (response.IsSuccess)
        {
            logger.LogInformation("Successfully handled {RequestName}", requestName);
        }
        else
        {
            logger.LogError("Request {RequestName} failed: {Error}", requestName, response.Error);
        }

        return response;
    }
}