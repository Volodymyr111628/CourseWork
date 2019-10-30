using System;
using Classes.Common.Printer;
using Classes.Common.Logger;
using System.Configuration;

namespace CoursesTask8.Common
{
    public class ConsoleCalc : ICalc
    {
        private static readonly IPrinter _printer = new ConsolePrinter();
        private readonly ILogger _logger = new ExceptionLogger(
            new FilePrinter(ConfigurationManager.AppSettings["FileToWrite"].ToString()),
            ConfigurationManager.AppSettings["LevelOfDetalization"].ToString());

        public void Calculation(double a, double b, char operation)
        {
            try
            {
                switch (operation)
                {
                    case '+':
                        _printer.Print(string.Format($"{a + b} \n"));
                        break;

                    case '-':
                        _printer.Print(string.Format($"{a - b} \n"));
                        break;

                    case '*':
                        _printer.Print(string.Format($"{a * b} \n"));
                        break;

                    case '/':
                        if (b == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        else
                        {
                            _printer.Print(string.Format($"{a / b} \n"));
                        }
                        break;

                    default:
                        _printer.Print("Unknown operation");
                        break;
                }
            }
            catch(DivideByZeroException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString());
            }
            catch(Exception ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                throw;
            }
        }
    }
}
