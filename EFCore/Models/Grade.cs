using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models;

public class Grade
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Lesson { get; set; }
    public double Score { get; set; }
    
    public int StudentNumber { get; set; }
    

    public override string ToString()
    {
        return Id + " " + Lesson + " " + Score + "\n";
    }
}