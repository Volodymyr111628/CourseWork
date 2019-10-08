using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Printer;
using Classes.Common.Reader;
using Classes.Common.Runner;


namespace CoursesTask1.Tasks
{
    public enum Colors { Green = 12, Red = 123, Purple = 9, Blue = 233, Yellow = 20 };

    public class Task4 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task4()
        {
            _printer = new ConsolePrinter();
        }

        public void Run()
        {
            var sortedValues = Colors.Green.Sort();

            _printer.Print("\nTask4\n");

            foreach (var value in sortedValues)
            {
                _printer.Print(string.Format("{0} - {1}\n",value,(int)value));
            }
        }
    }

    public static class Extensions
    {
        public static Array Sort(this Colors color)
        {
            var enumValues = Enum.GetValues(typeof(Colors));
            Array.Sort(enumValues);
            return enumValues;
        }
    }
}
