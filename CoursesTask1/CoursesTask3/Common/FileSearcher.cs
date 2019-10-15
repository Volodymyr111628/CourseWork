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
            _logger = new ExceptionLogger("Exception.txt");
        }

        public static void FindTxtFileByPartialName(string path,string fileName)
        {

        }
    }
}
