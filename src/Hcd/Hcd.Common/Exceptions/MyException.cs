using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hcd.Common.Exceptions
{
    public class MyException
    {
        public static async Task ExceptionMessage(HttpContext httpContext,
            Exception exception, HttpStatusCode httpStatusCode, 
            string Tittle)
        {
            // Set the HTTP status code explicitly
            httpContext.Response.StatusCode = (int)httpStatusCode;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = (int)httpStatusCode,
                Type = exception.GetType().Name,
                Title = Tittle,
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            });
        }
    }
}