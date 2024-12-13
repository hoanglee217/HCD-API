using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hcd.Common.Exceptions
{
    public class DefaultException(ILogger<DefaultException> logger) : IExceptionHandler
    {
        private readonly ILogger<DefaultException> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
            Exception exception, CancellationToken cancellationToken = default)
        {
            _logger.LogError(exception, "An unexpected error occurred");

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = exception.GetType().Name,
                Title = "An unexpected error occurred",
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            });
            return true;
        }
    }
}