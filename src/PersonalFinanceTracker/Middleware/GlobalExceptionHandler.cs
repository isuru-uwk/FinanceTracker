using FinanceTracker.Shared;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace FinanceTracker.Api.Middleware
{
    public class GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger,
        IHostEnvironment environment) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            var statusCode = exception switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                ValidationException => (int)HttpStatusCode.BadRequest,
                ArgumentNullException => (int)HttpStatusCode.BadRequest,
                ArgumentException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                NotImplementedException => (int)HttpStatusCode.NotImplemented,
                NotSupportedException => (int)HttpStatusCode.MethodNotAllowed,
                TimeoutException => (int)HttpStatusCode.RequestTimeout,
                OperationCanceledException => (int)HttpStatusCode.RequestTimeout,
                HttpRequestException => (int)HttpStatusCode.BadGateway,
                DbUpdateConcurrencyException => (int)HttpStatusCode.Conflict,
                DbUpdateException => (int)HttpStatusCode.InternalServerError,

                // fallback
                _ => (int)HttpStatusCode.InternalServerError
            };

            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "An error occurred while processing your request.",
                Status = statusCode,
                Instance = httpContext.Request.Path,
                Detail = environment.IsDevelopment() ? exception.ToString() : "An internal server error has occurred."
            };

            problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/problem+json";

            var json = JsonSerializer.Serialize(problemDetails, JsonConfiguration.SerializerOptions);
            await httpContext.Response.WriteAsync(json, cancellationToken);

            return true;
        }
    }
}
