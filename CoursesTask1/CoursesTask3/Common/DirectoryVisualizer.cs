using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Printer;
using System.IO;


namespace CoursesTask3.Common
{
    public static class DirectoryVisualizer
    {
        private static readonly IPrinter _printer = new ConsolePrinter();

        public static void VisualizeDirectory(string path, int level = 0)
        {
            DirectoryInfo info = new DirectoryInfo(path);
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
