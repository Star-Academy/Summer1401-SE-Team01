namespace Search;

public interface IInvertedIndexBuilder
{
    public InvertedIndex Build(IEnumerable<(string name, string content)>? list);
}