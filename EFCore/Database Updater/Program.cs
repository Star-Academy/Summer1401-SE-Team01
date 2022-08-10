// See https://aka.ms/new-console-template for more information

using Database_Updater;
using Models;

const string studentsFilePath = @"students.json";
const string gradesFilePath = @"grades.json";

JsonDeserializer jsonDeserializer = new JsonDeserializer();
Student [] students = jsonDeserializer.Deserialize<Student[]>(File.ReadAllText(studentsFilePath));
Grade [] grades = jsonDeserializer.Deserialize<Grade[]>(File.ReadAllText(gradesFilePath));

Console.WriteLine("Enter your postgres password:");
string password = Console.ReadLine();

using (var context = new SchoolContext(password))
{
    context.UpdateRange(students);
    context.UpdateRange(grades);
    context.SaveChanges();
}