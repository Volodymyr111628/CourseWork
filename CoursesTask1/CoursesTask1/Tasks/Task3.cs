using System;
using Classes.Common.Printer;
using Classes.Common.Runner;
using Classes.Common.Reader;
using CoursesTask1.Common;

namespace CoursesTask1.Tasks
{
    public class Task3 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly IReader _reader;

        public Task3()
        {
            _printer = new ConsolePrinter();
            _reader = new ConsoleReader();
        }

        public void Run()
        {
            _printer.Print("\nTask3\n");
            _printer.Print("Input n:");

            try
            {
                int monthNumber = Int32.Parse(_reader.Read());

                if (monthNumber < 0 || monthNumber >= 12)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    _printer.Print(string.Format("Your month: {0}\n", Enum.GetName(typeof(Month), monthNumber)));
                }
            }

            catch (ArgumentNullException ex)
            {
                _printer.Print(string.Format("{0}\n", ex.Message));
            }

            catch (FormatException ex)
            {
                _printer.Print(string.Format("{0}\n", ex.Message));
            }

            catch (IndexOutOfRangeException ex)
            {
                _printer.Print(string.Format("{0}\n", ex.Message));
            }
        }
    }
}
