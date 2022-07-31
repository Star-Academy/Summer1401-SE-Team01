namespace Search;

public class InvertedIndex
{
    public Dictionary<string, IEnumerable<string>> Database { get; set; }

    public InvertedIndex()
    {
        Database = new Dictionary<string, IEnumerable<string>>();
    }
}