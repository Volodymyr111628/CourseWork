using Classes.Common.Runner;
using CoursesTask2.Common;
using Classes.Common.Printer;
using System;

namespace CoursesTask2.Tasks
{
    public class Task2 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task2()
        {
            _printer = new ConsolePrinter();
        }

        public void Run()
        {
            _printer.Print(string.Format("\nTask2\n"));

            try
            {
                Functions.Iteration();
            }
            catch (IndexOutOfRangeException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message}\n"));
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message}\n"));
                throw;
            }
        }
    }
}