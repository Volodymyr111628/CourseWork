namespace Classes.Common.Logger
{
    public interface ILogger<T>
    {
        void WriteMessage(object value, LevelOfDetalization levelOfDetalization);
    }
}
