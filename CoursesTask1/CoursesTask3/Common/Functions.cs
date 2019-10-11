using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Printer;
using System.IO;


namespace CoursesTask3.Common
{
    public static class Functions
    {
        private static readonly IPrinter _printer = new ConsolePrinter();

        public static void GetDirectories(string path)
        {
            if (Directory.Exists(path))
            {
                var dirs = Directory.GetDirectories(path);
                
                foreach (var dir in dirs)
                {
                    _printer.Print(String.Format("{0}\n",dir));
                    GetDirectories(dir);
                }
            }
        }
    }
}
