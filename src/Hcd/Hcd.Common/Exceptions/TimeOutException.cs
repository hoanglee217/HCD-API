using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hcd.Common.Exceptions
{
    public class TimeOutException(ILogger<TimeOutException> logger) : IExceptionHandler
    {        
        private readonly ILogger<TimeOutException> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception, CancellationToken cancellationToken = default)
        {
            _logger.LogError(exception, "A timeout occurred");

            if (exception is TimeoutException)
            {
                await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
                {
                    Status = (int)HttpStatusCode.RequestTimeout,
                    Type = exception.GetType().Name,
                    Title = "A timeout occurred",
                    Detail = exception.Message,
                    Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
                });

                return true;
            }
            return false;
        }
    }
}