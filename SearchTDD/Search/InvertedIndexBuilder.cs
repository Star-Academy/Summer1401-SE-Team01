namespace Search;

public class InvertedIndexBuilder : IInvertedIndexBuilder
{
    public InvertedIndex Build(IEnumerable<(string name, string content)>? list)
    {
        InvertedIndex invertedIndex = new InvertedIndex();
        foreach (var file in list)
        {
            foreach (var word in file.content.ToUpper().Split())
            {
                if (invertedIndex.Database.ContainsKey(word))
                {
                    invertedIndex.Database[word] = invertedIndex.Database[word].Append(file.name);
                }
                else
                {
                    invertedIndex.Database.Add(word, new List<string>(){file.name});
                }
            }
        }

        return invertedIndex;
    }
    
    
}