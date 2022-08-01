using Xunit.Abstractions;

namespace Search.Test;

public class ISearchHandlerTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly InvertedIndex _invertedIndex = new InvertedIndex();
    private readonly ISearchHandler _includeOneHandler = new IncludeOneHandler();
    private ISearchHandler _includeAllHandler = new IncludeAllHandler();
    private readonly ISearchHandler _excludeAllHandler = new ExcludeAllHandler();
    private readonly IEnumerable<string> query1 = new [] { "DocumeNT", "-GREAT", "-PLEasE" };
    private readonly IEnumerable<string> query2 = new [] { "DocuMent", "+text", "+A"};
    private readonly IEnumerable<string> query3 = new [] { "DocuMent", "+text", "-salam", "+A"};
    private readonly IEnumerable<string> query4 = new [] { "DocumeNT", "+THiS", "+iS", "-GREAT", "-PLEasE" };
    private readonly IEnumerable<string> query5 = new [] { "DocumeNT", "+text", "+A", "-GREAT", "-PLEasE" };
    private readonly IEnumerable<string> query6 = new [] { "-DocuMent", "+salam", "-Text", "+A"};

    public ISearchHandlerTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
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
    }

    [Fact]
    public void Handle_IncludeOneHandlerQuery1_SizeIsThree()
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, query1);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_IncludeOneHandlerQuery1_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, query1);
        
        Assert.Contains(expected, answer);
    }

    [Fact]
    public void Handle_IncludeOneHandlerQuery4_SizeIsThree()
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, query4);
        _testOutputHelper.WriteLine(_invertedIndex.AllNames.Count().ToString());
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_IncludeOneHandlerQuery4_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, query4);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_IncludeOneHandlerQuery5_SizeIsTwo()
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, query5);
        _testOutputHelper.WriteLine(_invertedIndex.AllNames.Count().ToString());
        
        Assert.Equal(2, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    public void Handle_IncludeOneHandlerQuery5_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, query5);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_ExcludeAllHandlerQuery2_SizeIsThree()
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, query2);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_ExcludeAllHandlerQuery2_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, query2);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_ExcludeAllHandlerQuery3_SizeIsThree()
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, query3);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_ExcludeAllHandlerQuery3_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, query3);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_ExcludeAllHandlerQuery6_SizeIsTwo()
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, query6);
        
        Assert.Equal(2, answer.Count());
    }
    
    [Theory]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_ExcludeAllHandlerQuery6_ContainsAllExpecteds(string expected)
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, query6);
        
        Assert.Contains(expected, answer);
    }

}