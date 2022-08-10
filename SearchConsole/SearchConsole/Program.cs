using Search;

public class Program
{
    public static void Main(string [] args)
    {
        string FilePath = Path.GetFullPath(@"TestFiles");
        var fileProvider = new FileProvider();
        var documents = fileProvider.GetData(FilePath);
        var invertedIndex = new InvertedIndexBuilder().Build(documents);
        var includeAllHandler = new IncludeAllHandler();
        includeAllHandler.Next = new IncludeOneHandler();
        includeAllHandler.Next.Next = new ExcludeAllHandler();

        var searchEngine = new SearchEngine(invertedIndex, includeAllHandler);
        var answer = searchEngine.Query(Console.ReadLine());

        foreach (var fileName in answer)
        {
            Console.WriteLine(fileName);
        }
    }
}