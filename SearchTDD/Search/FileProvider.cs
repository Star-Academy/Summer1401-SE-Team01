namespace Search;

public class FileProvider : IDataProvider
{
    public IEnumerable<(string name, string content)> GetData(string path)
    {
        if(Directory.GetFiles(path).Length == 0)
            return new (string name, string content)[0];
        else
        {
            return new (string name, string content)[]
            {
                ("1", "This is a Text document !")
            };
        }
    }
}