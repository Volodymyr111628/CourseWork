using System;
using Classes.Common.Runner;
using Classes.Common.Printer;
using Classes.Common.Logger;
using CoursesTask8.Common;
using Classes.Common.Reader;

namespace CoursesTask8.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger<Task1> _logger;
        private readonly ICalculator _calculator;
        private readonly IReader _reader;

        public Task1(IPrinter printer, ILogger<Task1> logger, ICalculator calculator, IReader reader)
        {
            _logger = logger;
            _printer = printer;
            _calculator = calculator;
            _reader = reader;
        }

        public void Run()
        {
            try
            {
                string expression = string.Empty;

                if (_printer is ConsolePrinter)
                {
                    _printer.Print("Input expression to calculate: \n");
                }

                expression = _reader.Read();

                var result = _calculator.Calculate(expression);

                _printer.Print($"Result = {result} \n");
            }
            catch (DivideByZeroException ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
        }
    }
}
