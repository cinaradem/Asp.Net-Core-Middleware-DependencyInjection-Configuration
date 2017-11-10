using System.Linq;
using Devnot.AspnetCore.Sample.Models;

namespace Devnot.AspnetCore.Sample.Domain.Services
{
  public class SqlSearchService : ISearchService
  {

    public readonly NewsContext Context;

    public SqlSearchService(NewsContext newsContext)
    {
      Context = newsContext;
    }

    public SearchViewModel Search(string term)
    {
      var searchResultModel = new SearchViewModel { Provider = "Sql Search" };

      searchResultModel.Newses = Context.Newses.Where(m => m.Content.Contains(term) || m.Spot.Contains(term) || m.Title.Contains(term) || m.Category.Contains(term)).Select(m => m.Title).Take(50).ToList();
      return searchResultModel;
    }
  }
}
