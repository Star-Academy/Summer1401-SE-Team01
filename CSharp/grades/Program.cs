namespace grades;
using System.IO;
public class Program
{
    
    static void Main(string [] args)
    {
        const int NumberOfStudentsToPrint = 3;

        JsonDeserializer jsonDeserializer = new JsonDeserializer();
        Student [] students = jsonDeserializer.Deserialize<Student[]>(File.ReadAllText("students.json"));
        Grade [] grades = jsonDeserializer.Deserialize<Grade[]>(File.ReadAllText("grades.json"));

        var studentDictionary = new StudentDictionaryMaker().MakeDictionary(students);
        new GradeAssigner().AssignGrades(grades, studentDictionary);

        Console.WriteLine(new TopStudents().Calculate(students, NumberOfStudentsToPrint));
    }
}
