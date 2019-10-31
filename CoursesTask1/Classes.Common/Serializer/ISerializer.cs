
namespace Classes.Common.Serializer
{
    public interface ISerializer<T>
    {
        void Serialize();
        T Deserialize();
    }
}
