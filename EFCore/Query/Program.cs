using Models;

const int numberOfTopStudents = 3;

Console.WriteLine("Enter your postgres password:");
string password = Console.ReadLine();

using (var context = new SchoolContext(password))
{
    var answer = context.Students
        .OrderByDescending(s => s.Grades.Average(g => g.Score))
        .Take(numberOfTopStudents);
    foreach (var student in answer)
    {
        Console.WriteLine(student.FirstName);
        Console.WriteLine(student.LastName);
    }
}