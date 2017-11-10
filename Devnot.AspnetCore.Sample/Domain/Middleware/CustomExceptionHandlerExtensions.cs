using System;
using Microsoft.AspNetCore.Builder;

namespace Devnot.AspnetCore.Sample.Domain.Middleware
{
    public static class CustomExceptionHandlerExtensions
    {

        public static IApplicationBuilder UseCustomExceptipn(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentException(nameof(app));
            }
            return app.UseMiddleware<CustomErrorPagesMiddleware>();
        }
    }
}
