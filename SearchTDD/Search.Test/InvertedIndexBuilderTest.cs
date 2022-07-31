using Search;
using Xunit.Abstractions;

namespace Search.Test;

public class InvertedIndexBuilderTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly InvertedIndexBuilder _indexBuilder;
    public InvertedIndexBuilderTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _indexBuilder = new InvertedIndexBuilder();
    }

    [Fact]
    public void Build_AddSomeFile_()
    {
        (string name, string content)[] inputToBuilder = new (string name, string content)[]
        {
            new("1", "This is a Text document !"),
            new("2", "Hello What a great day it is"),
            new("3", "Hello Please put this into the microwave")
        };

        var result = _indexBuilder.Build(inputToBuilder);
        
        Dictionary<string, IEnumerable<string>> expected = new Dictionary<string, IEnumerable<string>>()
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
        
        Assert.Equal(expected.Keys, result.Database.Keys);
    }
}