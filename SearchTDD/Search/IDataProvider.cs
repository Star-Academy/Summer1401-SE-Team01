namespace Search;

public interface IDataProvider
{
    public IEnumerable<(string name, string content)> GetData(string path);
}