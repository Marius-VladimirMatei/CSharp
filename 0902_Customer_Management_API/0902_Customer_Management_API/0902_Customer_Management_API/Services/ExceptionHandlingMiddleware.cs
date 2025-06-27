using System.Net; // Needed for HttpStatusCode
using System.Text.Json;


///<summary>
/// ExceptionHandlingMiddleware is a custom middleware for handling exceptions globally in the ASP.NET Core application.
/// Prevents unhandled exceptions from propagating to the client and provides a consistent error response.
/// It catches any exception thrown in later middleware or controllers,
/// logs the error, and returns a consistent JSON 500 response.
///</summary>>

namespace _0902_Customer_Management_API.Services

{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next; // Next middleware in the pipeline to call after handling the exception
        private readonly ILogger<ExceptionHandlingMiddleware> _logger; // Logger to log the exceptions

        public ExceptionHandlingMiddleware(RequestDelegate next,
                                           ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next; // store the reference to the next middleware
            _logger = logger; // store the logger instance for logging exceptions
        }

        /// <summary>
        /// InvokeAsync is called by the framework for each HTTP request.
        /// Wraps the rest of the pipeline in a try/catch to handle any unhandled exception.
        /// Uses the current HTTP request/response context.
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pass control to the next middleware in the pipeline.
                await _next(context);
            }
            catch (Exception ex)
            {
                /// 1) Log the exception with stack trace and request info
                _logger.LogError(ex, "Unhandled exception for {Method} {Path}",
                                 context.Request.Method, context.Request.Path);

                // 2) Prepare a JSON error response
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // 3) Build payload object
                var errorPayload = new
                {
                    error = "An unexpected error occurred.",
                    details = ex.Message  // you might include stack trace only in Development
                };

                // 4) Serialize the payload to JSON
                var json = JsonSerializer.Serialize(errorPayload);
                // 5) Write the JSON into the HTTP response body
                await context.Response.WriteAsync(json);
            }
        }
    }
}
