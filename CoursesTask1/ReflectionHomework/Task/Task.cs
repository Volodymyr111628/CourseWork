using System;
using System.IO;
using ReflectionHomework.Common;
using Classes.Common.Calculator;
using Classes.Common.Printer;
using Classes.Common.Logger;
using Classes.Common.Runner;

namespace ReflectionHomework.Task
{
    public class Task : IRunnable
    {
        private readonly ILogger<Task> _logger;
        private readonly IPrinter _printer;
        public Task(ILogger<Task> logger,IPrinter printer)
        {
            _logger = logger;
            _printer = printer;
        }
        public void Run()
        {
            try
            {
                string assemblyPath = @"C:\Users\vova1\Videos\Desktop\Course\CourseWork\CoursesTask1\Classes.Common\bin";

                var instances = DynamicClassInstanceLoader.LoadInstances<ICalculator>(assemblyPath);

                foreach (var instance in instances)
                {
                    _printer.Print(string.Format($"Result :{instance.Calculate(10, 20).ToString()}\n"));
                }
            }
            catch(DirectoryNotFoundException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message}"));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message}"));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
        }
    }
}
