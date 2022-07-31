using Search;
using Xunit.Abstractions;

namespace Search.Test;

public class FileProviderTest: IDisposable
{
    private readonly ITestOutputHelper _testOutputHelper;
    private FileProvider _fileProvider;

    private static (string name, string content) expected = new("1", "This is a Text document !");

    public FileProviderTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _fileProvider = new FileProvider();

        Directory.CreateDirectory("EmptyTestFolder");
        
        Directory.CreateDirectory("OneTestFile");
        File.WriteAllText(@"OneTestFile/1", "This is a Text document !");

        Directory.CreateDirectory("TestFiles");
        File.WriteAllText(@"TestFiles/1", "This is a Text document !");
        File.WriteAllText(@"TestFiles/2", "Hello What a great day it is");
        File.WriteAllText(@"TestFiles/3", "Please put this into the microwave oven thank you");
    }

    public void Dispose()
    {
        Directory.Delete("EmptyTestFolder", true);
        Directory.Delete("OneTestFile", true);
        Directory.Delete("TestFiles", true);
    }

    [Fact]
    public void GetData_EmptyTestFolder_EmptyIEnumerable()
    {
        var result =_fileProvider.GetData("EmptyTestFolder");
        Assert.Equal(0,result.Count());
    }

    [Fact]
    public void GetData_OneFileTestFolder_SizeIsOne()
    {
        var result = _fileProvider.GetData("OneTestFile");
        Assert.Equal(1 , result.Count());
    }

    [Fact]
    public void GetData_OneTestFileFolder_ContainsTheFile()
    {
        var result = _fileProvider.GetData("OneTestFile");
        (string name, string context) expected = new ("1", "This is a Text document !");

        Assert.Contains(expected, result);
    }

    [Fact]
    public void GetData_TestFilesFolder_CheckSize()
    {
        var result = _fileProvider.GetData("TestFiles");
        Assert.Equal(3,result.Count());
    }

    [Fact]
    public void GetData_TestFilesFolder_ContainsFiles()
    {
        var result = _fileProvider.GetData("TestFiles");
        _testOutputHelper.WriteLine(result.ToString());
        (string name, string content)[] expects = new (string name, string content)[]
        {
            new("1", "This is a Text document !"),
            new("2", "Hello What a great day it is"),
            new("3", "Please put this into the microwave oven thank you")
        };

        foreach (var expected in expects)
        {
            Assert.Contains(expected, result);
        }

    }
}