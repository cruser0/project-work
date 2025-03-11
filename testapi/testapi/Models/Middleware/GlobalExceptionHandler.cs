using API.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Detail = ex.Message,
                    Status = 404,
                    Title = "Not Found",
                    Type = "Server Error"
                };
                string json = JsonSerializer.Serialize(problemDetails);

                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
            catch (ErrorInputPropertyException ex)
            {
                context.Response.StatusCode = 422;
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Detail = ex.Message,
                    Status = 422,
                    Title = "Unprocessable Entity",
                    Type = "Server Error"
                };
                string json = JsonSerializer.Serialize(problemDetails);

                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
            catch (NullPropertyException ex)
            {
                context.Response.StatusCode = 422;
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Detail = ex.Message,
                    Status = 422,
                    Title = "Unprocessable Entity",
                    Type = "Server Error"
                };
                string json = JsonSerializer.Serialize(problemDetails);

                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
            catch (NotFoundTokenException ex)
            {
                context.Response.StatusCode = 401;
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Detail = ex.Message,
                    Status = 401,
                    Title = "Unauthorized",
                    Type = "Server Error"
                };
                string json = JsonSerializer.Serialize(problemDetails);

                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
            catch (DbUpdateException ex)
            {
                context.Response.StatusCode = 400;
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Detail = ex.InnerException.Message,
                    Status = 400,
                    Title = ex.Message,
                    Type = "Server Error"
                };
                string json = JsonSerializer.Serialize(problemDetails);

                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }

            catch (Exception ex)
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
