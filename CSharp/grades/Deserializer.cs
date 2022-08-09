namespace Grades;

interface IDeserializer
{
    public T Deserialize<T>(String input);
}