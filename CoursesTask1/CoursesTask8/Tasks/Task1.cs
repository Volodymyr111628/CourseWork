using System;
using Classes.Common.Runner;
using System.Configuration;
using Classes.Common.Printer;
using Classes.Common.Logger;
using CoursesTask8.Common;

namespace CoursesTask8.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer = new ConsolePrinter();
        private readonly ILogger _logger = new ExceptionLogger(
            new FilePrinter(ConfigurationManager.AppSettings["FileToWrite"].ToString()),
            ConfigurationManager.AppSettings["LevelOfDetalization"].ToString());

        public void Run()
        {
            ICalc calcultor = new FileCalc();
            try
            {
                calcultor.Calculation(10, 20, '+');
            }
            catch(DivideByZeroException ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                _logger.WriteMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                _logger.WriteMessage(ex.ToString());
            }

            calcultor = new ConsoleCalc();

            try
            {
                calcultor.Calculation(20, 8, '/');
            }
            catch (DivideByZeroException ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                _logger.WriteMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                _logger.WriteMessage(ex.ToString());
            }
        }
    }
}
