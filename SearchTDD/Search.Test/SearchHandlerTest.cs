﻿using Xunit.Abstractions;

namespace Search.Test;

public class SearchHandlerTest
{
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

    public SearchHandlerTest()
    {
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
    public void Handle_IncludeOneHandlerQueryWithoutPlus_SizeIsThree()
    {
        var answer = _includeOneHandler.Handle(_invertedIndex, _queryWithoutPlus);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_IncludeOneHandlerQueryWithoutPlus_ContainsAllExpectations(string expected)
    {
        var answer = _includeOneHandler.Handle(_invertedIndex, _queryWithoutPlus);
        
        Assert.Contains(expected, answer);
    }

    [Fact]
    public void Handle_IncludeOneHandlerQueryWithPlus_SizeIsThree()
    {
        var answer = _includeOneHandler.Handle(_invertedIndex, _queryWithPlus);

        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_IncludeOneHandlerQueryWithPlus_ContainsAllExpectations(string expected)
    {
        var answer = _includeOneHandler.Handle(_invertedIndex, _queryWithPlus);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_IncludeOneHandlerAnotherQueryWithPlus_SizeIsTwo()
    {
        var answer = _includeOneHandler.Handle(_invertedIndex, _anotherQueryWithPlus);

        Assert.Equal(2, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    public void Handle_IncludeOneHandlerAnotherQueryWithPlus_ContainsAllExpectations(string expected)
    {
        var answer = _includeOneHandler.Handle(_invertedIndex, _anotherQueryWithPlus);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_ExcludeAllHandlerQueryWithoutMinus_SizeIsThree()
    {
        var answer = _excludeAllHandler.Handle(_invertedIndex, _queryWithoutMinus);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_ExcludeAllHandlerQueryWithoutMinus_ContainsAllExpectations(string expected)
    {
        var answer = _excludeAllHandler.Handle(_invertedIndex, _queryWithoutMinus);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_ExcludeAllHandlerQueryWithUnusedMinus_SizeIsThree()
    {
        var answer = _excludeAllHandler.Handle(_invertedIndex, _queryWithUnusedMinus);
        
        Assert.Equal(3, answer.Count());
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_ExcludeAllHandlerQueryWithUnusedMinus_ContainsAllExpectations(string expected)
    {
        var answer = _excludeAllHandler.Handle(_invertedIndex, _queryWithUnusedMinus);
        
        Assert.Contains(expected, answer);
    }
    
    [Fact]
    public void Handle_ExcludeAllHandlerQueryToCheckMinus_SizeIsTwo()
    {
        var answer = _excludeAllHandler.Handle(_invertedIndex, _queryToCheckMinus);
        
        Assert.Equal(2, answer.Count());
    }
    
    [Theory]
    [InlineData("2")]
    [InlineData("3")]
    public void Handle_ExcludeAllHandlerQueryToCheckMinus_ContainsAllExpectations(string expected)
    {
        var answer = _excludeAllHandler.Handle(_invertedIndex, _queryToCheckMinus);
        
        Assert.Contains(expected, answer);
    }

    [Fact]
    public void Handle_IncludeAllHandlerQueryWithUnusedMinus_SizeIsOne()
    {
        var answer = _includeAllHandler.Handle(_invertedIndex, _queryWithUnusedMinus);
        
        Assert.Single(answer);
    }
    
    [Theory]
    [InlineData("1")]
    public void Handle_IncludeAllHandlerQueryWithUnusedMinus_ContainsAllExpectations(string expected)
    {
        var answer = _includeAllHandler.Handle(_invertedIndex, _queryWithUnusedMinus);
        
        Assert.Contains(expected, answer);
    }

    [Fact]
    public void Handle_IncludeAllHandlerQueryWithoutMinus_SizeIsThree()
    {
        var answer = _includeAllHandler.Handle(_invertedIndex, _queryWithoutMinus);
        
        Assert.Single(answer);
    }

    [Theory]
    [InlineData("1")]

    public void Handle_IncludeAllHandlerQueryWithoutMinus_ContainsAllExpectations(string expected)
    {
        var answer = _includeAllHandler.Handle(_invertedIndex, _queryWithoutMinus);
        
        Assert.Contains(expected, answer);
    }
}