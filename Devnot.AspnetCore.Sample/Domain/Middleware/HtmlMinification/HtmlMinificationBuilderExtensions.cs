using Microsoft.AspNetCore.Builder;

namespace Devnot.AspnetCore.Sample.Domain.Middleware.HtmlMinification
{
    public static class HtmlMinificationBuilderExtensions
    {
        public static IApplicationBuilder UseHtmlMinification(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HtmlMinificationMiddleware>();
        }
      
    }
}
