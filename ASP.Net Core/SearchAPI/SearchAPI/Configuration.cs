using Search;

namespace SearchAPI;

public class Configuration
{
    public static void DependencyInjectionConfiguration(WebApplicationBuilder webApplicationBuilder)
    {
        string _filePath = Path.GetFullPath(@"TestFiles");
        var fileProvider = new FileProvider();
        var documents = fileProvider.GetData(_filePath);
        var includeAllHandler = new IncludeAllHandler();
        includeAllHandler.Next = new IncludeOneHandler();
        includeAllHandler.Next.Next = new ExcludeAllHandler();

        webApplicationBuilder.Services.AddSingleton<ISearchHandler>(includeAllHandler);
        webApplicationBuilder.Services.AddSingleton<InvertedIndex>(new InvertedIndexBuilder().Build(documents));
        webApplicationBuilder.Services.AddSingleton<ISearchEngine, SearchEngine>();
    }
}