namespace Search;

public class IncludeAllHandler : ISearchHandler
{
    public ISearchHandler Next { get; set; }

    public IEnumerable<string> Handle(InvertedIndex invertedIndex, IEnumerable<string> query)
    {
        return null;
    }
}