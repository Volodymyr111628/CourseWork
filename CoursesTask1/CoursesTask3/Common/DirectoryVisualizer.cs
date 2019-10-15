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


        public static void VisualizeDirectory(String path, DirectoryInfo parent = null, String space = null)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach (var item in directoryInfo.GetDirectories())
            {
                Console.WriteLine($"\t{space}+{item.Name}");
                VisualizeDirectory(item.FullName, item.Parent, "\t");
                foreach (var file in item.GetFiles())
                {
                    Console.WriteLine($"\t\t└{file.Name}");
                }
                Console.WriteLine();
            }
        }
    }
}
