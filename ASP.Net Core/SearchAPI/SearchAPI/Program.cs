using Search;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string _filePath = Path.GetFullPath(@"TestFiles");
var fileProvider = new FileProvider();
var documents = fileProvider.GetData(_filePath);
var invertedIndex = new InvertedIndexBuilder().Build(documents);
var includeAllHandler = new IncludeAllHandler();
includeAllHandler.Next = new IncludeOneHandler();
includeAllHandler.Next.Next = new ExcludeAllHandler();

builder.Services.Add(new ServiceDescriptor(typeof(ISearchHandler), includeAllHandler));
builder.Services.Add(new ServiceDescriptor(typeof(InvertedIndex), invertedIndex));
builder.Services.AddSingleton<ISearchEngine, SearchEngine>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();