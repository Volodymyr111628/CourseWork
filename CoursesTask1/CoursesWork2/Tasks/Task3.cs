using System;
using Classes.Common.Runner;
using Classes.Common.Printer;
using CoursesTask2.Common;

namespace CoursesTask2.Tasks
{
    public class Task3 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task3()
        {
            _printer = new ConsolePrinter();
        }

        public void Run()
        {
            _printer.Print(string.Format("\nTask3\n"));

            int a = 10;
            int b = 20;

            try
            {
                Functions.DoSomeMath(a, b);
            }
            catch (ArgumentException ex) when (a < 0 || b > 0)
            {
                _printer.Print(string.Format("Exception: {0}\n", ex.Message));
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format("Exception: {0}\n", ex.Message));
                throw;
            }
        }
    }
}