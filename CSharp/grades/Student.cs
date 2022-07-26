using System.Linq;
namespace grades;

public class Student
{
    public int StudentNumber {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public List<Grade> Grades {get; set;}

    public Student(int studentNumber, string firstName, string lastName) {
        StudentNumber = studentNumber;
        FirstName = firstName;
        LastName = lastName;
        Grades = new List<Grade>();
    }

    public override string ToString()
    {
        return FirstName + " " + LastName + " " + Grades.Select(x => x.Score).Average();
    }
}
