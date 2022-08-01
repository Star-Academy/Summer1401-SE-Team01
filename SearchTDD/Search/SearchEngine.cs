namespace Search;

public class SearchEngine : ISearchEngine
{
    private static readonly char[] DelimiterChars = new[] { ' ', ',', '!', '.', '?', ';', ':', '\'', '\"', '/', '\\' };
    private readonly InvertedIndex _invertedIndex;
    private readonly ISearchHandler _searchHandler;

    public SearchEngine(InvertedIndex invertedIndex, ISearchHandler searchHandler)
    {
        _invertedIndex = invertedIndex;
        _searchHandler = searchHandler;
    }

    
    public IEnumerable<string> Query(string query)
    {
        var splitQuery = query.ToUpper().Split(DelimiterChars, StringSplitOptions.RemoveEmptyEntries);
        return _searchHandler.Handle(_invertedIndex, splitQuery);
    }
}