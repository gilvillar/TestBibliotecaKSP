using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestBackend.Middleware
{
    /// <summary>
    /// Esta clase implementa un middleware para el manejo de excepciones no controladas
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware>? _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        /// <summary>
        /// metodo que se prepara para atrapar las excepciones no controladas
        /// </summary>
        /// <param name="http">Objeto de tipo HttpContext.</param>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //en caso de presentarse una excepcion se registra en el log
                _logger?.LogError(ex, "Unhandled exception");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// metodo que maneja las excepciones atrapadas
        /// </summary>
        /// <param name="http">Objeto de tipo HttpContext.</param>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //determinamos que tipo de información enviaremos dependiendo del ambiente en que
            //nos encontremos (produccion o desarrollo)
            var response = _env.IsDevelopment()
                ? new ErrorDetails(context.Response.StatusCode, exception.Message, exception.StackTrace)
                : new ErrorDetails(context.Response.StatusCode, "Internal Server Error");

            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }

    /// <summary>
    /// Esta clase representa la estructura de la información a enviar
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Representa el codigo de estatus
        /// </summary>
        public int StatusCode { get; }
        /// <summary>
        /// Representa el mensaje de error
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Representa el Stack de la excepcion
        /// </summary>
        public string? StackTrace { get; }

        public ErrorDetails(int statusCode, string message, string? stackTrace = null)
        {
            StatusCode = statusCode;
            Message = message;
            StackTrace = stackTrace;
        }
    }
}
