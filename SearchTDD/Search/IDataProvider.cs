namespace Search;

public interface IDataProvider
{
    IEnumerable<(string name, string content)> GetData(string path);
}