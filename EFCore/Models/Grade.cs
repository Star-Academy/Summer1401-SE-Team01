using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Grade
{
    public int Id { get; set; }
    public string Lesson { get; set; }
    public double Score { get; set; }
    
    public int StudentNumber { get; set; }
    public Student Student { get; set; }
}