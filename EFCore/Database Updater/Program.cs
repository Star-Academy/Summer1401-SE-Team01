// See https://aka.ms/new-console-template for more information

using Database_Updater;
using Models;

const string studentsFilePath = @"students.json";
const string gradesFilePath = @"grades.json";

JsonDeserializer jsonDeserializer = new JsonDeserializer();
Student [] students = jsonDeserializer.Deserialize<Student[]>(File.ReadAllText(studentsFilePath));
Grade [] grades = jsonDeserializer.Deserialize<Grade[]>(File.ReadAllText(gradesFilePath));