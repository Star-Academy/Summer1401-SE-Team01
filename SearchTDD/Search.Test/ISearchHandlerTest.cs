using Xunit.Abstractions;

namespace Search.Test;

public class ISearchHandlerTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private InvertedIndex invertedIndex = new InvertedIndex();
    private ISearchHandler _includeOneHandler = new IncludeOneHandler();
    private ISearchHandler _includeAllHandler = new IncludeAllHandler();
    private ISearchHandler _excludeAllHandler = new ExludeAllHandler();
    private IEnumerable<string> query1;
    private IEnumerable<string> query2;
    private IEnumerable<string> query3;
    private IEnumerable<string> query4;
    private IEnumerable<string> query5;
    public ISearchHandlerTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
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
            ["DAY"] = new[] { "2" },
            ["IT"] = new[] { "2" },
            ["PLEASE"] = new[] { "3" },
            ["PUT"] = new[] { "3" },
            ["INTO"] = new[] { "3" },
            ["THE"] = new[] { "3" },
            ["MICROWAVE"] = new[] { "3" },

        };
        invertedIndex.AllNames.Add("1");
        invertedIndex.AllNames.Add("2");
        invertedIndex.AllNames.Add("3");
        
        query1 = new[] { "DocumeNT", "-GREAT", "-PLEasE" };
        query2 = new[] { "+THiS", "+iS", "-GREAT", "-PLEasE" };
        query3 = new[] { "This", "IS", "+A", "-GREAT" };
        query4 = new[] { "DocumeNT", "+THiS", "+iS", "-GREAT", "-PLEasE" };
        query5 = new[] { "DocumeNT", "+text", "+A", "-GREAT", "-PLEasE" };
    }

    [Fact]
    public void Handle_IncludeOneHandlerQuery1_SizeIsThree()
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(invertedIndex, query1);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_IncludeOneHandlerQuery1_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(invertedIndex, query1);
        
        Assert.Contains(expected, answer);
    }

    [Fact]
    public void Handle_IncludeOneHandlerQuery4_SizeIsThree()
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(invertedIndex, query4);
        _testOutputHelper.WriteLine(invertedIndex.AllNames.Count().ToString());
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_IncludeOneHandlerQuery4_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(invertedIndex, query4);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_IncludeOneHandlerQuery5_SizeIsTwo()
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(invertedIndex, query5);
        _testOutputHelper.WriteLine(invertedIndex.AllNames.Count().ToString());
        
        Assert.Equal(2, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    public void Handle_IncludeOneHandlerQuery5_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(invertedIndex, query5);
        
        Assert.Contains(expected, answer);
    }

    /// //////////////////
    
    [Fact]
    public void Handle_IncludeAllHandlerQuery3_SizeIsOne()
    {
        IEnumerable<string> answer = _includeAllHandler.Handle(invertedIndex, query3);
        
        Assert.Equal(1, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    public void Handle_IncludeAllHandlerQuery3_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _includeAllHandler.Handle(invertedIndex, query3);
        
        Assert.Contains(expected, answer);
    }

    [Fact]
    public void Handle_IncludeAllHandlerQuery2_SizeIsThree()
    {
        IEnumerable<string> answer = _includeAllHandler.Handle(invertedIndex, query2);
        
        Assert.Equal(3, answer.Count());
    }

    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]

    public void Handle_IncludeAllHandlerQuery2_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _includeAllHandler.Handle(invertedIndex, query2);
        
        Assert.Contains(expected, answer);
    }

}