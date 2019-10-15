using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Runner;
using System.IO;
using Classes.Common.Printer;
using CoursesTask3.Common;
using Classes.Common.Logger;

namespace CoursesTask3.Tasks
{
    class Task1 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger _logger;

        public Task1()
        {
            _printer = new ConsolePrinter();
            _logger = new ExceptionLogger();
        }

        public void Run()
        {
            string path = "C:\\Users\\vova1\\Video\\Desktop\\Course\\CourseWork\\CoursesTask1\\CoursesWork2";
            try
            {
                int k = 0;
                int c = 0 / k;
                DirectoryVisualizer.VisualizeDirectory(path);
            }
            catch(IOException ex)
            {
                _printer.Print(string.Format(($"{ex.Message}\n")));
                _logger.Log(ex);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format(($"{ex.Message}\n")));
                _logger.Log(ex);
            }
        }
    }
}
