using System.Collections.Generic;
using Devnot.AspnetCore.Sample.Models;

namespace Devnot.AspnetCore.Sample.Domain.Services
{
    public interface ISearchService
    {
        SearchViewModel Search(string term);
    }
}
