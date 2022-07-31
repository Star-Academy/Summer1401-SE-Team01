namespace Search;

public class ExludeAllHandler : ISearchHandler
{
    public ISearchHandler Next { get; set; }
    public IEnumerable<string> Handle(InvertedIndex invertedIndex)
    {
        
    }
}