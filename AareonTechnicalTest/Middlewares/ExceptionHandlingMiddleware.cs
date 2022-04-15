using AareonTechnicalTest.DataLogger;
using AareonTechnicalTest.DataServices;
using AareonTechnicalTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
namespace MoviesApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate _next;
        public HttpContext _context;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionHandlingMiddleware>();
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation($"Request { context.Request.HttpContext.TraceIdentifier.ToString() } received at { DateTime.Now }");
                // next middleware
                _context = context;
                await _next(context);               
            }
            catch (Exception ex)
            {
                await HandleException(_context, ex);
            }
            finally
            {
                _logger.LogInformation($"Request { context.Request.HttpContext.TraceIdentifier.ToString() } processed at { DateTime.Now }");
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message, Code = "GE" });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}