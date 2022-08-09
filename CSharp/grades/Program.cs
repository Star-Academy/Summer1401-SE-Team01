namespace Grades;
using System.IO;
public class Program
{
    
    static void Main(string [] args)
    {
        const int NumberOfStudentsToPrint = 3;
        const string StudentsFilePath = "students.json";
        const string GradesFilePath = "grades.json";

        JsonDeserializer jsonDeserializer = new JsonDeserializer();
        Student [] students = jsonDeserializer.Deserialize<Student[]>(File.ReadAllText(StudentsFilePath));
        Grade [] grades = jsonDeserializer.Deserialize<Grade[]>(File.ReadAllText(GradesFilePath));

        var studentDictionary = new StudentDictionaryMaker().MakeDictionary(students, grades);

        Console.WriteLine(new TopStudents().Calculate(students, NumberOfStudentsToPrint));
    }
}
