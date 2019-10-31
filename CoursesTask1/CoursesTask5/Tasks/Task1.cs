using System;
using Classes.Common.Logger;
using Classes.Common.Runner;
using Classes.Common.Printer;
using System.Configuration;
using CoursesTask5.Common;

namespace CoursesTask5.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly ILogger<Task1> _logger;
        private readonly IPrinter _printer;
        private AssemblyInfoVisualizer visualizer;

        public Task1(IPrinter printer, ILogger<Task1> logger, AssemblyInfoVisualizer visualizer)
        {
            _printer = printer;
            _logger = logger;
            this.visualizer = visualizer;
        }

        public void Run()
        {
            try
            {
                visualizer.VisualizeAssemblyInfo();
            }
            catch (ArgumentException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString(),LevelOfDetalization.Error);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString(),LevelOfDetalization.Error);
            }
        }
    }
}
