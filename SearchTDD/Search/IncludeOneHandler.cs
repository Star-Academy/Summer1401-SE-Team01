namespace Search;

public class IncludeOneHandler : ISearchHandler
{
    public ISearchHandler Next { get; set; }

    public IEnumerable<string> Handle(InvertedIndex invertedIndex)
    {
        return null;
    }
}