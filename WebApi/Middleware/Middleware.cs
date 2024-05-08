using Microsoft.AspNetCore.Builder;
using System;
using System.Threading.Tasks;
using System.Net;
using Application.Common.Exceptions;
using FluentValidation;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace Api
{

    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case FluentValidation.ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case InternalServerError:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;


            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }

    public static class CastomErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCastomExeceptionHardler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}

