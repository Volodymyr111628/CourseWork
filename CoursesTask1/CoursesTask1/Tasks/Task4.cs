using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask1.Common;

namespace CoursesTask1.Tasks
{
    public class Task4 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task4()
        {
            _printer = new ConsolePrinter();
        }

        public void Run()
        {
            var sortedValues = Color.Green.Sort();

            _printer.Print("\nTask4\n");

            foreach (var value in sortedValues)
            {
                _printer.Print(string.Format("{0} : {1}\n", value, (int)value));
            }
        }
    }
}
