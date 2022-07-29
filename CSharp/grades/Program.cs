namespace grades;
using System.IO;
public class Program
{
    
    static void Main(string [] args)
    {
        const int NUMBER_OF_STUDENT_TO_PRINT = 3;

        JsonDeserializer jsonDeserializer = new JsonDeserializer();
        Student [] students = jsonDeserializer.DeserializeToStudent(File.ReadAllText("students.json"));
        Grade [] grades = jsonDeserializer.DeserializeToGrade(File.ReadAllText("grades.json"));

        var studentDictionary = new StudentDictionaryMaker().MakeDictionary(students);
        new GradeAssigner().AssignGrades(grades, studentDictionary);

        Console.WriteLine(new PrintTopStudents().Calculate(students, NUMBER_OF_STUDENT_TO_PRINT));
    }
}
