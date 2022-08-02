namespace grades;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonDeserializer : IDeserializer
{
    public Student[] DeserializeToStudent(string input)
    {
        return System.Text.Json.JsonSerializer.Deserialize<Student[]>(input);
    }

    public Grade[] DeserializeToGrade(string input) 
    {
        return System.Text.Json.JsonSerializer.Deserialize<Grade[]>(input);
    }
}
