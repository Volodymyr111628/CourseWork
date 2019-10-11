using System;
using System.Collections.Generic;
using CoursesTask2.Tasks;
using Classes.Common.Runner;
using Classes.Common.Printer;

namespace CoursesTask2
{
    class Program
    {
        private static readonly IPrinter _printer = new ConsolePrinter();
        static void Main(string[] args)
        {
            List<IRunnable> tasks = new List<IRunnable>()
            {
                new Task2(),
                new Task3(),
                new Task1()
            };
            try
            {
                foreach (var task in tasks)
                {
                    task.Run();
                }
            }
            catch (Exception ex)
            {
                _printer.Print(ex.Message);
            }
        }
    }
}
