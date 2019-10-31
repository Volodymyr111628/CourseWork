using System.Xml.Serialization;
using System.IO;

namespace Classes.Common.Serializer
{
    public class XmlSerializer<T> : ISerializer<T>
    {

        public string Path { get; set; }
        public T ItemToSerialize { get; set; }

        public XmlSerializer()
        {
            Path = "";
        }

        public XmlSerializer(string path, object item = null)
        {
            Path = path;
            ItemToSerialize = (T)item;
        }

        public void Serialize()
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(T));

            FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
            xmlFormatter.Serialize(fs, ItemToSerialize);

            fs.Close();
        }

        public T Deserialize()
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(Path, FileMode.Open);

            var deserializedItem = (T)xmlFormatter.Deserialize(fs);

            fs.Close();

            return deserializedItem;
        }
    }
}
