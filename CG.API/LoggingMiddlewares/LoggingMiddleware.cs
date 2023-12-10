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
                // Set the correlation ID and request timestamp in the context
                context.Items["CorrelationId"] = correlationId;
                context.Items["RequestReceivedTime"] = requestReceivedTime;

                // Log request information at the Information level with the timestamp, correlation ID, and client IP address
                _logger.LogInformation($"Received request ({correlationId}) at {requestReceivedTime} from {context.Connection.RemoteIpAddress}: {context.Request.Method} {context.Request.Path}");

                // Log request headers at the Information level with the timestamp and correlation ID
                _logger.LogInformation($"Request headers ({correlationId}) at {requestReceivedTime}:");
                foreach (var header in context.Request.Headers)
                {
                    _logger.LogInformation($"{header.Key}: {header.Value}");
                }

                // Log request body at the Information level with the timestamp and correlation ID
                context.Request.EnableBuffering();
                using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    var requestBody = await reader.ReadToEndAsync();
                    if (!string.IsNullOrEmpty(requestBody))
                    {
                        _logger.LogInformation($"Request body ({correlationId}) at {requestReceivedTime}: {requestBody}");
                    }

                    // Reset the position of the request body stream so that it can be read again by other middleware
                    context.Request.Body.Position = 0;
                }

                await _next(context);

                // Log response information at the Information level with the timestamp, correlation ID, and client IP address
                _logger.LogInformation($"Sent response ({correlationId}) at {DateTime.UtcNow} to {context.Connection.RemoteIpAddress}: {context.Response.StatusCode}");

                // Log response headers at the Information level with the timestamp and correlation ID
                _logger.LogInformation($"Response headers ({correlationId}) at {DateTime.UtcNow}:");
                foreach (var header in context.Response.Headers)
                {
                    _logger.LogInformation($"{header.Key}: {header.Value}");
                }

                // Log response body at the Information level with the timestamp and correlation ID
                Stream originalBodyStream = context.Response.Body;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    context.Response.Body = memoryStream;
                    memoryStream.Position = 0;

                    string responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
                    if (!string.IsNullOrEmpty(responseBody))
                    {
                        _logger.LogInformation($"Response body ({correlationId}) at {DateTime.UtcNow}: {responseBody}");
                    }

                    await memoryStream.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception ex)
            {
                // Log error information at the Error level with the timestamp, correlation ID, and client IP address
                _logger.LogError($"An error occurred ({correlationId}) at {DateTime.UtcNow} from {context.Connection.RemoteIpAddress}: {ex}");
                throw;
            }
            finally
                {
                // Log the URL for every request in the finally block at the Information level with the correlation ID
                _logger.LogInformation(
                    "Request ({correlationId}) {datetime}: {method} {url} => {statusCode}",
                    correlationId,
                    DateTime.UtcNow,
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


