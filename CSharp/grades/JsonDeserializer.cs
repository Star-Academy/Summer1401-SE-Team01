namespace grades;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonDeserializer : IDeserializer
{
    public T Deserialize<T>(String input)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(input);
    }
}
