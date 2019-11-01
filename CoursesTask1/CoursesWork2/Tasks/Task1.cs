using System;
using Classes.Common.Runner;
using CoursesTask2.Common;
using Classes.Common.Printer;

namespace CoursesTask2.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task1()
        {
            _printer = new ConsolePrinter();
        }
        public void Run()
        {
            _printer.Print(string.Format("\nTask1\n"));

            _printer.Print("StackOverflowException object can't be caught by a try-catch block\n " +
                "and the corresponding process is terminated by default\n" +
                "Starting with 2.0 a StackOverflow Exception can only be caught in the following circumstances.\n" +
                "1) The CLR is being run in a hosted environment where the host specifically\n" +
                " allows for StackOverflow exceptions to be handled\n" +
                "2) The stackoverflow exception is thrown by user code and not\n" +
                "due to an actual stack overflow situation\n");

            try
            {
                Functions.RecursiveFunction(10);
            }
            catch (StackOverflowException ex)
            {
                _printer.Print(ex.Message);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format("Some exception happend here: {0}\n", ex.Message));
                throw;
            }
        }
    }
}
