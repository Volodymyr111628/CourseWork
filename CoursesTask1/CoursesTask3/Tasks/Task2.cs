using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask3.Common;

namespace CoursesTask3.Tasks
{
    class Task2 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger _logger;

        public Task2()
        {
            _printer = new ConsolePrinter();
            _logger = new ExceptionLogger(new FilePrinter("Exceptions.txt"), "INFO");
        }

        public void Run()
        {
            _printer.Print("\n---------------TASK2-----------------\n");
            string path = @"C:\Users\vova1\Videos\Desktop\glew";
            string fileName = "LI";

            try
            {
                FileSearcher.FindTxtFileByPartialName(path, fileName);
            }
            catch (IOException ex)
            {
                _logger.WriteMessage(ex.Message);
                _printer.Print(string.Format($"{ex.Message}\n"));
            }
            catch (Exception ex)
            {
                _logger.WriteMessage(ex.Message);
                _printer.Print(string.Format($"{ex.Message}\n"));
            }
        }
    }
}
