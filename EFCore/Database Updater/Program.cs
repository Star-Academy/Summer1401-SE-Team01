﻿
using Database_Updater;
using Models;

const string studentsFilePath = @"./students.json";
const string gradesFilePath = @"./grades.json";

var jsonDeserializer = new JsonDeserializer();
Student[] students = jsonDeserializer.Deserialize<Student[]>(File.ReadAllText(studentsFilePath));
Grade[] grades = jsonDeserializer.Deserialize<Grade[]>(File.ReadAllText(gradesFilePath));

foreach (var grade in grades)
{
    students.Single(s => s.StudentNumber == grade.StudentNumber).Grades.Add(grade);
}

using (var context = new SchoolContext())
{
    context.UpdateRange(students);
    context.SaveChanges();
}