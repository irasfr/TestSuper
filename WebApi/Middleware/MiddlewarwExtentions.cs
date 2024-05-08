using Microsoft.AspNetCore.Builder;

namespace Api.Middleware
{
    public static class middlewarwExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}