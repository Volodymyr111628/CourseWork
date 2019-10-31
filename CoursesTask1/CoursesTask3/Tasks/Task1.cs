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
        private readonly ILogger<Task1> _logger;
        private DirectoryVisualizer directoryVisualizer;

        public Task1(IPrinter printer,ILogger<Task1> logger,DirectoryVisualizer directoryVisualizer)
        {
            _printer = printer;
            _logger = logger;
            this.directoryVisualizer = directoryVisualizer;
        }

        public void Run()
        {
            _printer.Print("TASK1\n");

            string path = @"C:\Users\vova1\Videos\Desktop\Course\CourseWork\CoursesTask1\CoursesWork2";

            try
            {
                directoryVisualizer.VisualizeDirectory(path);
            }
            catch(IOException ex)
            {
                _printer.Print(string.Format(($"{ex.ToString()}\n")));
                _logger.WriteMessage(ex.ToString(),LevelOfDetalization.Error);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format(($"{ex.ToString()}\n")));
                _logger.WriteMessage(ex.Message,LevelOfDetalization.Error);
            }
        }
    }
}
