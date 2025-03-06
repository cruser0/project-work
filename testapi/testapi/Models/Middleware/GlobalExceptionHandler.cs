using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Models.Middleware
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Detail = ex.Message,
                    Status = 500,
                    Title="Internal Server Error",
                    Type ="Server Error"
                };
                string json=JsonSerializer.Serialize(problemDetails);

                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
        }
    }
}
