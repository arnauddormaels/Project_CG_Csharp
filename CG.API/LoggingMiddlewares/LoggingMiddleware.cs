/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;*/
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CG.API.LoggingMiddlewares
{ 
    public class LoggingMiddleware
    {
            private readonly RequestDelegate _next;
            private readonly ILogger<LoggingMiddleware> _logger;

            public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
            {
                _next = next ?? throw new ArgumentNullException(nameof(next));
                _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
            }

        public async Task Invoke(HttpContext context)
        {
            // Generate a unique correlation ID for the request
            string correlationId = Guid.NewGuid().ToString();
            DateTime requestReceivedTime = DateTime.UtcNow;

            try
            {
                // Log request information at the Information level with the timestamp, correlation ID, and client IP address
                _logger.LogInformation($"Received request ({correlationId}) at {requestReceivedTime} from {context.Connection.RemoteIpAddress}: {context.Request.Method} {context.Request.Path}");

                // Log only specific headers (e.g., "Referer", "Accept", "Date" and "Content-Type")
                // Log request headers at the Information level
                _logger.LogInformation($"Request headers:\n" +
                    $"\tReferer: {context.Request.Headers["Referer"]}\n" +
                    $"\tAccept: {context.Request.Headers["Accept"]}");

                await _next(context);

                // Log response information at the Information level with the timestamp, correlation ID, and client IP address
                _logger.LogInformation($"Sent response ({correlationId}) at {DateTime.UtcNow} to {context.Connection.RemoteIpAddress}: {context.Response.StatusCode}");

                // Log response headers at the Information level
                _logger.LogInformation($"Response headers:\n" +
                    $"\tContent-Type: {context.Response.Headers["Content-type"]}\n" +
                    $"\tDate: {context.Response.Headers["Date"]}");

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred ({correlationId}) at {DateTime.UtcNow} from {context.Connection.RemoteIpAddress}: {ex}");
                throw;
            }
            finally
                {
                // Log the URL for every request in the finally block at the Information level with the ID
                _logger.LogInformation(
                    "Request ({correlationId}) duration {time}s : {method} {url} => {statusCode}",
                    correlationId,
                    Math.Round((DateTime.UtcNow - requestReceivedTime).TotalSeconds,2),
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
                }
            }
        }

        public static class LoggingMiddlewareExtensions
        {
            public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<LoggingMiddleware>();
            }
        }

}


