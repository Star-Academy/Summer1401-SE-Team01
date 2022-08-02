namespace grades;

public class GradeAssigner
{
    public void AssignGrades(Grade[] grades, Dictionary<int, Student> students)
    {
        foreach (var grade in grades)
        {
            students[grade.StudentNumber].Grades.Add(grade);
        }
    }
}
