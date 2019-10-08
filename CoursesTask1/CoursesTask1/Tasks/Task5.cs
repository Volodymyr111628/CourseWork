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
    class Task5:IRunnable
    {
        private readonly IPrinter _printer;

        enum LongRange : long { Max = long.MaxValue, Min = long.MinValue };

        public Task5()
        {
            _printer = new ConsolePrinter();
        }

        public void Run()
        {
            _printer.Print("\nTask5\n");
            foreach (long value in Enum.GetValues(typeof(LongRange)))
            {
                _printer.Print(string.Format("{0}\n",value));
            }
        }
    }
}
