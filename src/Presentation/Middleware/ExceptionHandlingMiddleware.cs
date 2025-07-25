using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyApi.Presentation.Middleware
{
    /// <summary>
    /// Middleware para tratamento global de exceções, retornando JSON padronizado.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        /// <summary>
        /// Inicializa uma nova instância de ExceptionHandlingMiddleware.
        /// </summary>
        /// <param name="next">Próximo middleware no pipeline.</param>
        /// <param name="logger">Logger para registrar exceções.</param>
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        /// <summary>
        /// Executa o middleware, capturando exceções não tratadas.
        /// </summary>
        /// <param name="context">Contexto HTTP.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { error = "Ocorreu um erro inesperado.", details = ex.Message });
                await context.Response.WriteAsync(result);
            }
        }
    }
} 