using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Classes.Common.Printer;
using System.IO;

namespace Classes.Common.Serializer
{
    public class XmlSerializer<T> : ISerializable<T>
    {
        public string Path { get; set; }
        public T ItemToSerialize { get; set; }
        private readonly FilePrinter _filePrinter;

        public XmlSerializer()
        {
            Path = "";
            _filePrinter = new FilePrinter();
        }

        public XmlSerializer(string path,object item)
        {
            Path = path;
            _filePrinter = new FilePrinter(Path);
            ItemToSerialize = (T)item;
        }

        public void Serialize()
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fs, ItemToSerialize);
            }
        }
    }
}
