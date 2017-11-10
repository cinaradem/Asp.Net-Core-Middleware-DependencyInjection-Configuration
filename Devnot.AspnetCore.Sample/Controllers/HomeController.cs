using System.Diagnostics;
using Devnot.AspnetCore.Sample.Domain;
using Devnot.AspnetCore.Sample.Domain.Options;
using Devnot.AspnetCore.Sample.Domain.Services;
using Devnot.AspnetCore.Sample.Domain.Utils;
using Devnot.AspnetCore.Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Devnot.AspnetCore.Sample.Controllers
{
    public class HomeController : Controller
    {
    
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly OperationService _operationService;


        public HomeController(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation, OperationService operationService, AzureSearchMockData azureSearchMockData, NewsContext context)
        {
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _operationService = operationService;
            //DbInitializer.Initialize(context);
            //azureSearchMockData.MockData();

        }

        public IActionResult Index()
        {
            ViewBag.Transient = _transientOperation;
            ViewBag.Scoped = _scopedOperation;
            ViewBag.Singleton = _singletonOperation;
            ViewBag.Service = _operationService;

            //var count = int.Parse("devnot");
            return View();
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
