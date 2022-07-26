namespace grades;
using System.IO;
public class Program
{
    
    static void Main(string [] args)
    {
        JsonDeserializer jsonDeserializer = new JsonDeserializer();
        Student [] students = jsonDeserializer.DeserializeToStudent(File.ReadAllText("students.json"));
        Grade [] grades = jsonDeserializer.DeserializeToGrade(File.ReadAllText("grades.json"));

        var studentDictionary = new StudentDictionaryMaker().MakeDictionary(students);
        new GradeAssigner().AssignGrades(grades, studentDictionary);

        Console.WriteLine(new TopThreeQueryPrinter().Calculate(students));
    }
}
