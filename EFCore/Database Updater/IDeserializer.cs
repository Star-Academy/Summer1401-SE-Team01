namespace Database_Updater;

interface IDeserializer
{
    public T Deserialize<T>(String input);
}