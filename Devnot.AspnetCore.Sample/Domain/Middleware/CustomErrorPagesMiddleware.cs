using System;
using System.Dynamic;
using System.Threading.Tasks;
using Devnot.AspnetCore.Sample.Domain.Services;
using Devnot.AspnetCore.Sample.Domain.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.KeyVault.Models;
using Newtonsoft.Json;

namespace Devnot.AspnetCore.Sample.Domain.Middleware
{
    /// <summary>
    /// CustomErrorPagesMiddleware
    /// </summary>
    public class CustomErrorPagesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionProvider _logger;

        /// <summary>
        /// CustomErrorPagesMiddleware
        /// </summary>
        /// <param name="next"></param>
        public CustomErrorPagesMiddleware(RequestDelegate next, IExceptionProvider logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                context.Response.Clear();
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json; charset=utf-8";
                var error = ex.InnerException != null ?
                    new Error { Code = ex.InnerException.HResult, Message = ex.InnerException.Message }
                    : new Error { Code = ex.HResult, Message = ex.Message };
                error.ExceptionDetais = new ExpandoObject();
                error.ExceptionDetais = ex;
                var responseBody = JsonConvert.SerializeObject(error);
                await context.Response.WriteAsync(responseBody);
            }
        }
    }
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public dynamic ExceptionDetais { get; set; }
    }
}
