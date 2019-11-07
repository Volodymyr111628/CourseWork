using System;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask10.Common;

namespace CoursesTask10.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly ILogger<Task1> _logger;
        private readonly IPrinter _printer;
        private MatrixParallel _matrixParallel;

        public Task1(ILogger<Task1> logger, IPrinter printer, MatrixParallel matrixParallel)
        {
            _logger = logger;
            _printer = printer;
            _matrixParallel = matrixParallel;
        }

        public void Run()
        {
            try
            {
                _printer.Print((string.Format($"Sum of matrix elements: {_matrixParallel.GetSumOfElements()} \n")));
            }
            catch (ArgumentException ex)
            {
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
                _printer.Print((string.Format($"Exception occured: {ex.Message} \n")));
            }
            catch (Exception ex)
            {
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
                _printer.Print((string.Format($"Exception occured: {ex.Message} \n")));

            }
        }
    }
}
