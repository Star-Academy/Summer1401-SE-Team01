namespace Search;

public interface IInvertedIndexBuilder
{
    public InvertedIndex Build(IEnumerable<Document> list);
}