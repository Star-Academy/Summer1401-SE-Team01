namespace grades;

public class Student
{
    public int StudentNumber {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public List<Grade> grades {get;}

    public Student(int studentNumber, string firstName, string lastName) {
        StudentNumber = studentNumber;
        FirstName = firstName;
        LastName = lastName;
        grades = new List<>();
    }
}
