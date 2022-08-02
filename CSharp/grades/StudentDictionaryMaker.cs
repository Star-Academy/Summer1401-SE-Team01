namespace grades;

public class StudentDictionaryMaker
{
    public Dictionary<int,Student> MakeDictionary(Student[] students)
    {
        Dictionary<int, Student> answer = new Dictionary<int, Student> ();
        foreach (var student in students)
        {
            answer.Add(student.StudentNumber, student);
        }

        return answer;
    }
}
