using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse> (ILogger<LoggingBehavior<TRequest, TResponse>> logger): IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle request={Request} - Response={Response} - request={Request}", typeof(TRequest).Name, typeof(TResponse).Name, request);
        var timer = new Stopwatch();
        timer.Start();

        var response = await next();
        timer.Stop();
        var time = timer.Elapsed;
        if (time.Seconds > 3)
            logger.LogWarning("[PERFOMANCE] The request {request} took {TimeTAken} ", typeof(TRequest).Name, time.Seconds);


       logger.LogInformation("[END] Handled request={Request} with response={Response}", typeof(TRequest).Name, response);
        return response;

    }
}
