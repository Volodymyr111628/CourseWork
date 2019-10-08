using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Printer;
using Classes.Common.Runner;
using Classes.Common.Reader;

namespace CoursesTask1.Tasks
{
    public class Task3 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly IReader _reader;

        enum Months { January, February, March, April, May, June, July, August, September, October, November, December };

        public Task3()
        {
            _printer = new ConsolePrinter();
            _reader = new ConsoleReader();
        }

        public void Run()
        {
            _printer.Print("\nTask3\n");
            _printer.Print("Input n:");

            int n=-1;
            Int32.TryParse(_reader.Read(),out n);

            if (n==-1||n < 0 || n >= 12)
            {
                _printer.Print("Invalid argument \n");
            }
            else
            {
                _printer.Print(string.Format("Your month: {0}\n", Enum.GetName(typeof(Months), n)));
            }
        }
    }

}
