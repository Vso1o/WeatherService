using System.Text.Json;
using WeatherService.Business.Exceptions.Abstractions;

namespace WeatherService.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ApiException ex)
            {
                await HandleApiExceptionAsync(context, ex);
            }
            catch (Exception ex) 
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleApiExceptionAsync(HttpContext context, ApiException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.StatusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Error. {exception.Message}"
            }));
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            return context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Internal Server Error. {exception.Message}"
            }));
        }

        private class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }
    }
}
