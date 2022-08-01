using System.Text.RegularExpressions;

namespace Search;

public class SearchEngine : ISearchEngine
{
    private InvertedIndex _invertedIndex;
    private ISearchHandler _searchHandler;

    public SearchEngine(InvertedIndex invertedIndex, ISearchHandler searchHandler)
    {
        _invertedIndex = invertedIndex;
        _searchHandler = searchHandler;
    }

    
    public IEnumerable<string> Query(string query)
    {
        char[] delimiterChars = new[] { ' ', ',', '!', '.', '?', ';', ':', '\'', '\"', '/', '\\' };
        var splitedQuery = query.ToUpper().Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
        return _searchHandler.Handle(_invertedIndex, splitedQuery);
    }
}