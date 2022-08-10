using Microsoft.EntityFrameworkCore;
using Models;

const int numberOfTopStudents = 3;


using (var context = new SchoolContext())
{
    var answer = context.Students.Include(s => s.Grades)
        .OrderByDescending(s => s.Grades.Average(g => g.Score))
        .Take(numberOfTopStudents);
    
    foreach (var student in answer)
    { 
        Console.WriteLine(student.ToString());
    }
}