using System.Collections.Generic;
using System.IO;

namespace Search;

public class FileProvider : IDataProvider
{
    public IEnumerable<(string name, string content)> GetData(string path)
    {
        string[] paths = Directory.GetFiles(path);
        List<(string name, string content)> files = new List<(string name, string content)>();
        foreach (var filePath in paths)
        {
            files.Add(new(new FileInfo(filePath).Name, File.ReadAllText(filePath)));
        }

        return files;
    }
}