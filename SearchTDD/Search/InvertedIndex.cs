using System.Linq;

namespace Search;

public class InvertedIndex
{
    public Dictionary<string, IEnumerable<string>> Database { get; set; }
    public HashSet<string> AllNames { get; }= new HashSet<string>();

    public InvertedIndex()
    {
        Database = new Dictionary<string, IEnumerable<string>>();
    }

    public void Add(string name, IEnumerable<string> words)
    {
        AllNames.Add(name);
        foreach (var word in words)
        {
            if (!Database.ContainsKey(word)) Database.Add(word, new List<string>());
            Database[word].Append(name);
        }
    }
}