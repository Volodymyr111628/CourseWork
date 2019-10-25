
namespace Classes.Common.Serializer
{
    public interface ISerializable<T>
    {
        void Serialize();
        T Deserialize();
    }
}
