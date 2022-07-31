namespace Search;

public interface ISearchHandler
{
    public ISearchHandler Next { set; get; }
    public IEnumerable<string> Handle(InvertedIndex invertedIndex);
}