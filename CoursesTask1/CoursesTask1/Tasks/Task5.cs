using System;
using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask1.Common;

namespace CoursesTask1.Tasks
{
    class Task5 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task5()
        {
            _printer = new ConsolePrinter();
        }

        public void Run()
        {
            _printer.Print("\nTask5\n");

            var enumValues = Enum.GetValues(typeof(LongRange));

            foreach (var value in enumValues)
            {
                _printer.Print(string.Format("{0} : {1}\n", value, (long)value));
            }
        }
    }
}
