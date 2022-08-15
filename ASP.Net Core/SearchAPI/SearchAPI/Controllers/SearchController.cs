using Microsoft.AspNetCore.Mvc;
using Search;

namespace SearchAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : Controller
{
    static readonly string _filePath = Path.GetFullPath(@"TestFiles");
    private ISearchEngine _searchEngine;
    
    public SearchController()
    {
        var fileProvider = new FileProvider();
        var documents = fileProvider.GetData(_filePath);
        var invertedIndex = new InvertedIndexBuilder().Build(documents);
        var includeAllHandler = new IncludeAllHandler();
        includeAllHandler.Next = new IncludeOneHandler();
        includeAllHandler.Next.Next = new ExcludeAllHandler();

        _searchEngine = new SearchEngine(invertedIndex, includeAllHandler);
    }

    [HttpGet("[action]")]
    public ActionResult<IEnumerable<string>> Query(string query)
    {
        return Ok(_searchEngine.Query(query));
    }
}