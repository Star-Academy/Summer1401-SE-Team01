

using Bogus.DataSets;

namespace SearchTDD.Test
{
    using Bogus;
    using FluentAssertions;
    using SearchTDD;
    
    public class DirectoryManagerTest
    {
        private readonly string FolderPath = @"..\SearchTDD\TestFolder";
        private DirectoryManager _directoryManager;
        private List<Doc> _fileList;

        public DirectoryManagerTest()
        { 
            _directoryManager = new DirectoryManager(FolderPath);
            _fileList = _directoryManager.GetFiles();
        }

        [Fact]
        public void GetFiles_TestFolder_SizeIs8()
        {
            Assert.Equal(8, _fileList.Count);
        }

        [Fact]
        public void GetFiles_TestFolder_FileNamesBetween0To7()
        {
            foreach (var document in _fileList)
            {
                string name = document.Name;
                Assert.InRange(Int32.Parse(name.Substring(name.Length - 1)), 0, 7);
            }
        }
    }
}