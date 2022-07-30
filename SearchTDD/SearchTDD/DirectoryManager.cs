namespace SearchTDD;

public class DirectoryManager
{
    private string folderPath;
    private readonly List<String> _filePaths;
    public DirectoryManager(string path)
    {
        folderPath = path;
        _filePaths = new List<string>(Directory.GetFiles(path));
    }

    public List<Doc> GetFiles()
    {
        List<Doc> answer = new List<Doc>();
        foreach (var path in _filePaths)
        {
            answer.Add(new Doc(path));
        }
    }
}