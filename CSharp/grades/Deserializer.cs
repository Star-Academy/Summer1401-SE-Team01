namespace grades;

interface IDeserializer
{
    public T Deserialize<T>(String input);
}