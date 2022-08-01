namespace Grades;

public class StudentDictionaryMaker
{
    public Dictionary<int, Student> MakeDictionary(Student[] students, Grade[] grades)
    {
        Dictionary<int, Student> answer = new Dictionary<int, Student>();
        foreach (var student in students)
        {
            answer.Add(student.StudentNumber, student);
            answer[student.StudentNumber].Grades.AddRange(grades.Where(x => x.StudentNumber == student.StudentNumber));
        }

        return answer;
    }
}