namespace Search.Test;

public class InvertedIndexBuilderTest
{
    private readonly InvertedIndexBuilder _indexBuilder;
    public InvertedIndexBuilderTest()
    {
        _indexBuilder = new InvertedIndexBuilder();
    }
    
    public static Dictionary<string, IEnumerable<string>> Data =>
        new Dictionary<string, IEnumerable<string>>()
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

    [Fact]
    public void Build_AddSomeFile_TheInvertedIndexBuiltCorrectly()
    {
        Document[] inputToBuilder = {
            new Document("1", "This is a Text document !"),
            new Document("2", "Hello What a great day it is"),
            new Document("3", "Hello Please put this into the microwave")
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