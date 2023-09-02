using EmployeeTask.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmployeeTask.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        public GlobalExceptionMiddleware(RequestDelegate next,ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task HandleException(HttpContext httpContext, Exception ex, HttpStatusCode httpStatusCode, string message)
        {

           //Handling exceptions

            HttpResponse response = httpContext.Response;

            Error error = new()
            {
                 ErrorMessage=  message,
                StatusCode = httpStatusCode,
                IsSuccess = false,
                Result = ex
            };

            string errorResultJson=JsonConvert.SerializeObject(error,Formatting.Indented);
            

            //Logging error
            _logger.LogError(errorResultJson);

            response.Redirect("./Home/Error");
        }
    }


    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
