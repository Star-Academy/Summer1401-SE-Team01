using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Models;

public class Student
{
    [JsonIgnore]
    public int Id { get; set; }
    public int StudentNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    [JsonIgnore]
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public override string ToString()
    {
        return $"{FirstName} {LastName} : {Grades.Average(g=>g.Score)}";
    }
}