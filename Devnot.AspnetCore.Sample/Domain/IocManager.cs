using System.Reflection;
using Devnot.AspnetCore.Sample.Domain.Options;
using Devnot.AspnetCore.Sample.Domain.Services;
using Devnot.AspnetCore.Sample.Domain.Services.Exceptions;
using Devnot.AspnetCore.Sample.Domain.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devnot.AspnetCore.Sample.Domain
{
    public class IocManager
    {

        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOperationTransient, OperationLifeTime>();
            services.AddScoped<IOperationScoped, OperationLifeTime>();
            services.AddSingleton<IOperationSingleton, OperationLifeTime>();
            services.AddTransient<OperationService, OperationService>();

            var options = configuration.Get<DevnotOptions>();

            var exceptionProvider = Assembly.GetEntryAssembly().GetType(options.Exception.Provider);
            services.AddSingleton(typeof(IExceptionProvider), exceptionProvider);

            var searchProvider = Assembly.GetEntryAssembly().GetType(options.SearchEngine.Provider);
            services.AddTransient(typeof(ISearchService), searchProvider);

            services.AddTransient<AzureSearchMockData>();
        }
    }
}
