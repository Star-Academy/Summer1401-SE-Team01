namespace grades;

interface IDeserializer
{
    public Student[] DeserializeToStudent(string input);
    public Grade[] DeserializeToGrade(string input) ;
}