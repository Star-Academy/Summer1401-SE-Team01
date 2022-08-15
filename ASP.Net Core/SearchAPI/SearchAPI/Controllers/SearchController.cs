using Microsoft.AspNetCore.Mvc;
using Search;

namespace SearchAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SearchController : Controller
{
    private ISearchEngine _searchEngine;
    
    public SearchController(ISearchEngine searchEngine)
    {
        _searchEngine = searchEngine;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<string>> Search(string query)
    {
        return Ok(_searchEngine.Query(query));
    }
}