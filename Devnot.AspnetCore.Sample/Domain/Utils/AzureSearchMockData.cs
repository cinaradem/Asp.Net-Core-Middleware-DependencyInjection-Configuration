using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devnot.AspnetCore.Sample.Domain.Options;
using Devnot.AspnetCore.Sample.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Options;

namespace Devnot.AspnetCore.Sample.Domain.Utils
{
  public interface IAzureSearchMockData
  {
    void MockData();
  }
  public class AzureSearchMockData : IAzureSearchMockData
  {

    private readonly AzureSearchOptions _azureSearchOptions;
    private readonly NewsContext _context;
    public AzureSearchMockData(IOptions<SearchOptions> azureSearchOptions, NewsContext context)
    {
      _context = context;
      _azureSearchOptions = azureSearchOptions.Value.AzureSearch;
    }

    private SearchServiceClient CreateSearchServiceClient()
    {

      SearchServiceClient serviceClient = new SearchServiceClient(_azureSearchOptions.SearchServiceName, new SearchCredentials(_azureSearchOptions.SearchServiceQueryApiKey));
      return serviceClient;
    }

    public void MockData()
    {
      SearchServiceClient serviceClient = CreateSearchServiceClient();
      var definition = new Index()
      {
        Name = "news",
        Fields = new[]
          {
                    new Field("Id",     DataType.String)         { IsKey = true,  IsSearchable = false, IsFilterable = false, IsSortable = false, IsRetrievable = true},
                    new Field("Title",   DataType.String)         { IsKey = false, IsSearchable = true,  IsFilterable = true,  IsSortable = true,   IsRetrievable = true},
                    new Field("Category",  DataType.String)         { IsKey = false, IsSearchable = true,  IsFilterable = true,  IsSortable = true,    IsRetrievable = true},
                    new Field("Spot",    DataType.String)         { IsKey = false, IsSearchable = true,  IsFilterable = true,  IsSortable = true,   IsRetrievable = true},
                    new Field("Content",  DataType.String)          { IsKey = false, IsSearchable = true, IsFilterable = true,  IsSortable = true,    IsRetrievable = true},
                }
      };
      //serviceClient.Indexes.Delete("news");

      serviceClient.Indexes.CreateOrUpdate(definition);

      var indexClient = serviceClient.Indexes.GetClient("news");

      for (int i = 0; i < 1500; i++)
      {
        var data = GetData(i);

        foreach (var news in data)
        {
          try
          {
            Console.WriteLine(news.Id);


            var actions =
                new[]
                {
                            IndexAction.Upload(
                                new
                                {
                                  Id = news.Id.ToString(),
                                    Content = news.Content,
                                    Title = news.Title,
                                    Spot = news.Spot,
                                    Category = news.Category
                                })
                };

            var batch = IndexBatch.New(actions);

            indexClient.Documents.Index(batch);
          }
          catch (Exception e)
          {
            Console.WriteLine(e);
          }
        }
      }



    }

    public List<News> GetData(int page)
    {

      return _context.Newses.OrderBy(m => m.Id).Skip(page * 10).Take(10).ToList();

    }

  }

}
