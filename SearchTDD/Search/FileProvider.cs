namespace Search;

public class FileProvider : IDataProvider
{
    public IEnumerable<Document> GetData(string path)
    {
        string[] paths = Directory.GetFiles(path);
        List<Document> files = new List<Document>();
        foreach (var filePath in paths)
        {
            files.Add(new(new FileInfo(filePath).Name, File.ReadAllText(filePath)));
        }

        return files;
    }
}