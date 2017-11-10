using System.Collections.Generic;
using System.Linq;
using Devnot.AspnetCore.Sample.Domain.Options;
using Devnot.AspnetCore.Sample.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Options;

namespace Devnot.AspnetCore.Sample.Domain.Services
{
    public class AzureSearchService : ISearchService
    {
        private readonly AzureSearchOptions _azureSearchOptions;

        public AzureSearchService(IOptions<DevnotOptions> azureSearchOptions)
        {
            _azureSearchOptions = azureSearchOptions.Value.SearchEngine.AzureSearch;
        }

        public SearchViewModel Search(string term)
        {
            var searchResultModel = new SearchViewModel { Provider = "Azure Search" };

            SearchServiceClient serviceClient = new SearchServiceClient(_azureSearchOptions.SearchServiceName, new SearchCredentials(_azureSearchOptions.SearchServiceQueryApiKey));

            var indexClient = serviceClient.Indexes.GetClient("news");
            SearchParameters sp = new SearchParameters() { SearchMode = SearchMode.All, Top = 100 };
            searchResultModel.Newses = indexClient.Documents.Search(term, sp).Results.SelectMany(m => m.Document).Where(n => n.Key == "Title").Select(k => k.Value.ToString()).ToList();
            return searchResultModel;
        }
    }
}
