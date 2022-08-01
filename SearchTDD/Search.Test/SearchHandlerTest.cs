using System.Linq;
using Xunit.Abstractions;

namespace Search.Test;

public class SearchHandlerTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly InvertedIndex _invertedIndex = new InvertedIndex();
    private readonly ISearchHandler _includeOneHandler = new IncludeOneHandler();
    private readonly ISearchHandler _includeAllHandler = new IncludeAllHandler();
    private readonly ISearchHandler _excludeAllHandler = new ExcludeAllHandler();
    private readonly IEnumerable<string> _queryWithoutPlus = new [] { "DocumeNT", "-GREAT", "-PLEasE" };
    private readonly IEnumerable<string> _queryWithoutMinus = new [] { "DocuMent", "+text", "+A"};
    private readonly IEnumerable<string> _queryWithUnusedMinus = new [] { "DocuMent", "+text", "-salam", "+A"};
    private readonly IEnumerable<string> _queryWithPlus = new [] { "DocumeNT", "+THiS", "+iS", "-GREAT", "-PLEasE" };
    private readonly IEnumerable<string> _anotherQueryWithPlus = new [] { "DocumeNT", "+text", "+A", "-GREAT", "-PLEasE" };
    private readonly IEnumerable<string> _queryToCheckMinus = new [] { "-DocuMent", "+salam", "-Text", "+A"};

    public SearchHandlerTest(ITestOutputHelper testOutputHelper)
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
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, _queryWithoutPlus);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_IncludeOneHandlerQuery1_ContainsAllExpectations(string expected)
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, _queryWithoutPlus);
        
        Assert.Contains(expected, answer);
    }

    [Fact]
    public void Handle_IncludeOneHandlerQuery4_SizeIsThree()
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, _queryWithPlus);
        _testOutputHelper.WriteLine(_invertedIndex.AllNames.Count().ToString());
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_IncludeOneHandlerQuery4_ContainsAllExpectations(string expected)
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, _queryWithPlus);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_IncludeOneHandlerQuery5_SizeIsTwo()
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, _anotherQueryWithPlus);
        _testOutputHelper.WriteLine(_invertedIndex.AllNames.Count().ToString());
        
        Assert.Equal(2, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    public void Handle_IncludeOneHandlerQuery5_ContainsAllExpectations(string expected)
    {
        IEnumerable<string> answer = _includeOneHandler.Handle(_invertedIndex, _anotherQueryWithPlus);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_ExcludeAllHandlerQuery2_SizeIsThree()
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, _queryWithoutMinus);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_ExcludeAllHandlerQuery2_ContainsAllExpectations(string expected)
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, _queryWithoutMinus);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_ExcludeAllHandlerQuery3_SizeIsThree()
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, _queryWithUnusedMinus);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_ExcludeAllHandlerQuery3_ContainsAllExpectations(string expected)
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, _queryWithUnusedMinus);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_ExcludeAllHandlerQuery6_SizeIsTwo()
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, _queryToCheckMinus);
        
        Assert.Equal(2, answer.Count());
    }
    
    [Theory]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_ExcludeAllHandlerQuery6_ContainsAllExpectations(string expected)
    {
        IEnumerable<string> answer = _excludeAllHandler.Handle(_invertedIndex, _queryToCheckMinus);
        
        Assert.Contains(expected, answer);
    }

    [Fact]
    public void Handle_IncludeAllHandlerQuery3_SizeIsOne()
    {
        IEnumerable<string> answer = _includeAllHandler.Handle(_invertedIndex, _queryWithUnusedMinus);
        
        Assert.Single(answer);
    }
    
    [Theory]
    [InlineData("1")]
    public void Handle_IncludeAllHandlerQuery3_ContainsAllExpectations(string expected)
    {
        IEnumerable<string> answer = _includeAllHandler.Handle(_invertedIndex, _queryWithUnusedMinus);
        
        Assert.Contains(expected, answer);
    }

    [Fact]
    public void Handle_IncludeAllHandlerQuery2_SizeIsThree()
    {
        IEnumerable<string> answer = _includeAllHandler.Handle(_invertedIndex, _queryWithoutMinus);
        
        Assert.Single( answer);
    }

    [Theory]
    [InlineData("1")]

    public void Handle_IncludeAllHandlerQuery2_ContainsAllExpectations(string expected)
    {
        IEnumerable<string> answer = _includeAllHandler.Handle(_invertedIndex, _queryWithoutMinus);
        
        Assert.Contains(expected, answer);
    }
}