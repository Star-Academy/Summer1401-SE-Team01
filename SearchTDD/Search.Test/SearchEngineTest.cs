using System.Linq;

namespace Search.Test;

public class SearchEngineTest
{
    private ISearchEngine _searchEngineIncludeAll;
    private ISearchEngine _searchEngineIncludeOne;
    private ISearchEngine _searchEngineExcludeAll;
    
    private readonly string testQuery = "DocumeNT +iS +this   -GREAT -PLEasE";

    public SearchEngineTest()
    {
        InvertedIndex _invertedIndex = new InvertedIndex(); 
        _invertedIndex.Database = new Dictionary<string, IEnumerable<string>>()
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
            ["DAY"] = new[] { "2" },
            ["IT"] = new[] { "2" },
            ["PLEASE"] = new[] { "3" },
            ["PUT"] = new[] { "3" },
            ["INTO"] = new[] { "3" },
            ["THE"] = new[] { "3" },
            ["MICROWAVE"] = new[] { "3" },

        };
        
        _invertedIndex.AllNames.Add("1");
        _invertedIndex.AllNames.Add("2");
        _invertedIndex.AllNames.Add("3");
        
        
        _searchEngineIncludeAll = new SearchEngine(_invertedIndex, new IncludeAllHandler());
        _searchEngineExcludeAll = new SearchEngine(_invertedIndex, new ExcludeAllHandler());
        _searchEngineIncludeOne = new SearchEngine(_invertedIndex, new IncludeOneHandler());
    }

    [Fact]
    public void Query_searchEngineIncludeAll_SizeIsOne()
    {
        var result = _searchEngineIncludeAll.Query(testQuery);
        
        Assert.Equal(1, result.Count());
    }

    [Theory]
    [InlineData("1")]

    public void Query_searchEngineIncludeAll_ContainsAllExpecteds(string expected)
    {
        var result = _searchEngineIncludeAll.Query(testQuery);
        
        Assert.Contains(expected, result);
    }
    
    
    [Fact]
    public void Query_searchEngineIncludeOne_SizeIsThree()
    {
        var result = _searchEngineIncludeOne.Query(testQuery);
        
        Assert.Equal(3, result.Count());
    }

    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Query_searchEngineIncludeOne_ContainsAllExpecteds(string expected)
    {
        var result = _searchEngineIncludeOne.Query(testQuery);
        
        Assert.Contains(expected, result);
    }
    
    [Fact]
    public void Query_searchEngineExcludeAll_SizeIsOne()
    {
        var result = _searchEngineExcludeAll.Query(testQuery);
        
        Assert.Equal(1, result.Count());
    }

    [Theory]
    [InlineData("1")]
    public void Query_searchEngineExcludeAll_ContainsAllExpecteds(string expected)
    {
        var result = _searchEngineExcludeAll.Query(testQuery);
        
        Assert.Contains(expected, result);
    }
}