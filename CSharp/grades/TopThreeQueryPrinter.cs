using System.Text;
using System.Linq;

namespace grades;

public class TopThreeQueryPrinter : IQueryPrinter
{
    public string Calculate(Student[] students) 
    {
        var newStudents = students.OrderByDescending(x => x.Grades.Select(y => y.Score).Average()).Take(3);

        StringBuilder answer = new StringBuilder("");
        foreach (var student in newStudents)
        {
            answer.Append(student.ToString() + "\n");
        }

        return answer.ToString();
    }
}
