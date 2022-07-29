
using System.Text;
using System.Linq;

namespace grades;

public class TopStudents
{
    public string Calculate(Student[] students, int numberOfStudentToPrint) 
    {
        var newStudents = students.OrderByDescending(x => x.Grades.Select(y => y.Score).Average()).Take(numberOfStudentToPrint);

        StringBuilder answer = new StringBuilder("");
        foreach (var student in newStudents)
        {
            answer.Append(student.ToString());
        }

        return answer.ToString();
    }
}