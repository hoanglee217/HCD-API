using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;

namespace Hcd.Common.Exceptions
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
            Exception exception, CancellationToken cancellationToken = default)
        {
            // Handle TimeoutException with 408 Request Timeout
            if (exception is TimeoutException)
            {
                await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.RequestTimeout, "A timeout occurred");
                return true;
            }

            // Handle ArgumentException with 400 Bad Request
            if (exception is ArgumentException)
            {
                await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.BadRequest, "A bad request occurred");
                return true;
            }

            // Handle ArgumentException with 401 Unauthorized
            if (exception is UnauthorizedException)
            {
                await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.Unauthorized, "Unauthorized");
                return true;
            }

            // Handle NotFoundException with 404 Not Found
            if (exception is NotFoundException) // Assuming NotFoundException is your custom exception
            {
                await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.NotFound, "Resource not found");
                return true;
            }

            // Handle DuplicateException with 409 Conflict
            if (exception is DuplicateException) // Assuming DuplicateException is your custom exception
            {
                await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.Conflict, "A conflict occurred: Duplicate entry");
                return true;
            }

            // Handle DuplicateException with  410 Gone
            if (exception is GoneException)
            {
                await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.Gone, "Requesting an outdated resource");
                return true;
            }

            // Handle unexpected errors with 500 Internal Server Error
            await MyException.ExceptionMessage(httpContext, exception, HttpStatusCode.InternalServerError, "An unexpected error occurred");
            return true;
        }
    }

}