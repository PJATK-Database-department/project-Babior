using MarketWatch.Server.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace HospitalMngmnt.Server.Extensions
{

    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }

    }
}