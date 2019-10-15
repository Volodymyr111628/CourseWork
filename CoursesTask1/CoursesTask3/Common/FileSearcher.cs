using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Printer;
using Classes.Common.Logger;
using System.IO;

namespace CoursesTask3.Common
{
    public static class FileSearcher
    {
        private static readonly IPrinter _printer;
        private static readonly ILogger _logger;

        static FileSearcher()
        {
            _printer = new ConsolePrinter();
            _logger = new ExceptionLogger(new ConsolePrinter(),"INFO");
        }

        public static void FindTxtFileByPartialName(string path, string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(path);

            var files = info.GetFiles();

            foreach (var file in files)
            {
                if (Path.GetExtension(file.FullName) == ".txt" && file.Name.Contains(fileName))
                {
                    _printer.Print(string.Format($"{file.FullName} \n"));
                }
            }
            foreach (var item in info.GetDirectories())
            {
                FindTxtFileByPartialName(item.FullName, fileName);
            }
        }

    }
}
