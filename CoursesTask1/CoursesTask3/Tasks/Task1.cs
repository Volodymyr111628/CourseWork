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
            _logger = new ExceptionLogger(new FilePrinter("Exception.txt"),"INFO");
        }

        public void Run()
        {
            _printer.Print("TASK1\n");

            string path = "C:\\Users\\vova1\\Videos\\Desktop\\Course\\CourseWork\\CoursesTask1\\CoursesWork2";
            try
            {
                DirectoryVisualizer.VisualizeDirectory(path);
            }
            catch(IOException ex)
            {
                _printer.Print(string.Format(($"{ex.ToString()}\n")));
                _logger.WriteMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format(($"{ex.ToString()}\n")));
                _logger.WriteMessage(ex.Message);
            }
        }
    }
}
