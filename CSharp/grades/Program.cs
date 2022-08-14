namespace Grades;
using System.IO;
public class Program
{
    
    static void Main(string [] args)
    {
        const int numberOfStudentsToPrint = 3;
        const string studentsFilePath = "students.json";
        const string gradesFilePath = "grades.json";

        JsonDeserializer jsonDeserializer = new JsonDeserializer();
        Student [] students = jsonDeserializer.Deserialize<Student[]>(File.ReadAllText(studentsFilePath));
        Grade [] grades = jsonDeserializer.Deserialize<Grade[]>(File.ReadAllText(gradesFilePath));

        var studentDictionary = new StudentDictionaryMaker().MakeDictionary(students, grades);

        Console.WriteLine(new TopStudents().Calculate(students, numberOfStudentsToPrint));
    }
}
