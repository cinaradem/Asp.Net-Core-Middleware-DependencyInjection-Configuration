using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Devnot.AspnetCore.Sample.Domain.Middleware.HtmlMinification
{

    public class HtmlMinificationMiddleware
    {
        private RequestDelegate _next;
     
        public HtmlMinificationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {

            //var a = int.Parse("devnot");
            var stream = context.Response.Body;
            try
            {
                using (var buffer = new MemoryStream())
                {
                    context.Response.Body = buffer;
                    await _next(context);
                    var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");

                    buffer.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(buffer))
                    {
                        string responseBody = await reader.ReadToEndAsync();
                        if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
                        {
                            responseBody = Regex.Replace(responseBody,
                                @">\s+<", "><", RegexOptions.Compiled);
                            responseBody = Regex.Replace(responseBody,
                                @"<!--(?!\s*(?:\[if [^\]]+]|<!|>))(?:(?!-->)(.|\n))*-->", "", RegexOptions.Compiled);
                        }
                        var bytes = Encoding.UTF8.GetBytes(responseBody);
                        using (var memoryStream = new MemoryStream(bytes))
                        {
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            await memoryStream.CopyToAsync(stream);
                        }
                    }

                }
            }
            finally
            {
                context.Response.Body = stream;
            }

        }
    }
}
