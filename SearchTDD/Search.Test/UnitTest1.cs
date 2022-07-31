using Search;
namespace Search.Test;

public class FileProviderTest
{
    private FileProvider _fileProvider;

    private static (string name, string content) expected = new("1", "This is a Text document !");

    public FileProviderTest()
    {
        _fileProvider = new FileProvider();
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

    [Theory]
    [InlineData(expected)]
    [InlineData(new ("2", "Hello What a great day it is"))]
    [InlineData(new ("3", "Please put this into the microwave oven thank you"))]
    public void GetData_TestFilesFolder_ContainsFiles((string name, string context) expected)
    {
        var result = _fileProvider.GetData("TestFiles");
        
    }
}