namespace Search.Test;

public class ISearchHandlerTest
{
    private readonly ISearchHandler _searchHandler;
    public ISearchHandlerTest()
    {
        InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.Database = new Dictionary<string, IEnumerable<string>>()
        {
            ["THIS"] = new[] { "1", "3" },
            ["IS"] = new[] { "1", "2" },
            ["A"] = new[] { "1", "2" },
            ["TEXT"] = new[] { "1" },
            ["DOCUMENT"] = new[] { "1" },
            ["!"] = new[] { "1" },
            ["HELLO"] = new[] { "2", "3" },
            ["WHAT"] = new[] { "2" },
            ["GREAT"] = new[] { "2" },
            ["DAY"] = new []{"2"},
            ["IT"] = new []{"2"},
            ["PLEASE"] = new []{"3"},
            ["PUT"] = new []{"3"},
            ["INTO"] = new []{"3"},
            ["THE"] = new []{"3"},
            ["MICROWAVE"] = new []{"3"},

        };
        
        // _searchHandler = new IncludeOneHandler();
    }
    
    
}