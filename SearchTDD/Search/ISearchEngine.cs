namespace Search;

public interface ISearchEngine
{
    public IEnumerable<string> Query(string query);
}