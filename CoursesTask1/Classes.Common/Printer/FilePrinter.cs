using System.IO;

namespace Classes.Common.Printer
{
    public class FilePrinter : IPrinter, ILogPrinter
    {
        private readonly string Path;

        public FilePrinter(string path)
        {
            Path = path;
        }

        public void Print(string value)
        {
            WriteToFile(value);
        }

        private void WriteToFile(string value, bool append = true)
        {
            using (var sw = new StreamWriter(Path, append))
            {
                if (!File.Exists(Path))
                {
                    File.Create(Path);
                }
                sw.WriteLine(string.Format("{0} \n", value));
            }
        }
    }
}
