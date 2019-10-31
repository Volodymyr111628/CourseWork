using Classes.Common.Printer;
using System.IO;

namespace CoursesTask3.Common
{
    public class DirectoryVisualizer
    {
        private readonly IPrinter _printer;

        public DirectoryVisualizer(IPrinter printer)
        {
            _printer = printer;
        }

        public void VisualizeDirectory(string path, int level = 0)
        {
            var info = new DirectoryInfo(path);

            var indent = new string('\t', level);

            _printer.Print(string.Format($"{indent + "+" + info.Name}\n"));

            foreach (var item in info.GetDirectories())
            {
                VisualizeDirectory(item.FullName, level + 1);

                foreach (var file in item.GetFiles())
                {
                    indent = new string('\t', level + 2);

                    _printer.Print(string.Format($"{indent + "└" + file.Name}\n"));
                }
            }
        }
    }
}
