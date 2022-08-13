namespace Search;

public interface IDataProvider
{
    public IEnumerable<Document> GetData(string path);
}