using Devnot.AspnetCore.Sample.Domain.Services;
using Devnot.AspnetCore.Sample.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devnot.AspnetCore.Sample.Controllers
{



    public class SearchController : Controller
    {

        private readonly ISearchService _searchServices;

        public SearchController(ISearchService searchServices)
        {
            _searchServices = searchServices;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public SearchViewModel SearchContent(string term)
        {
            SearchViewModel result = _searchServices.Search(term);
            return result;
        }
    }
}
