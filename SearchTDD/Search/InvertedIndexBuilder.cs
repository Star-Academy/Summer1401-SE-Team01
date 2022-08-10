namespace Search;

public class InvertedIndexBuilder : IInvertedIndexBuilder
{
    public InvertedIndex Build(IEnumerable<Document> list)
    {
        InvertedIndex invertedIndex = new InvertedIndex();
        foreach (var file in list)
        {
            invertedIndex.Add(file.Name, file.Content.ToUpper().Split());
        }

        return invertedIndex;
    }
    
    
}