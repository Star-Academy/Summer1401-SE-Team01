namespace SearchTDD.Test;

public class QueryHandlerTest
{
    private readonly QueryHandler _queryHandler;
    public QueryHandlerTest()
    {
        _queryHandler = new QueryHandler();
    }
    [Fact]
    public void SplitQuary__()
    {
        List<string> expected = new List<string>() {"HELLO", "-"}
    }
}