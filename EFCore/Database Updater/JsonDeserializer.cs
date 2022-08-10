using System.Text.Json;
using System.Text.Json.Serialization;

namespace Database_Updater;

public class JsonDeserializer : IDeserializer
{
    public T Deserialize<T>(String input)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(input);
    }
}
