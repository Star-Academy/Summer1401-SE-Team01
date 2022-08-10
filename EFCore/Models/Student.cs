using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models;

public class Student
{
    [Key]
    public int StudentNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();

}