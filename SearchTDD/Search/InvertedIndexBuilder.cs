namespace Search;

public class InvertedIndexBuilder : IInvertedIndexBuilder
{
    public InvertedIndex Build(IEnumerable<(string name, string content)>? list)
    {
        InvertedIndex invertedIndex = new InvertedIndex();
        foreach (var file in list)
        {
            invertedIndex.Add(file.name, file.content.ToUpper().Split());
        }

        return invertedIndex;
    }
    
    
}