using System.Configuration;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask6.Common;
using System;

namespace CoursesTask6.Tasks
{
    class Task2 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger<Task2> _logger;

        public Task2(IPrinter printer, ILogger<Task2> logger)
        {
            _logger = logger;
            _printer = printer;
        }

        public void Run()
        {
            var firstCircle = new Circle(new Point(10, 10), 5);
            var secondCircle = new Circle(new Point(15, 15), 4);

            try
            {
                _printer.Print("\n\n --- TASK2 --- \n\n");
                firstCircle.Draw();
                secondCircle.Draw();

                _printer.Print("Circle which contains two circles:\n");

                var containsTwoCircle = new Circle().GetShapeContainsTwo(firstCircle, secondCircle);
                containsTwoCircle.Draw();

                _printer.Print(string.Format("After moving:\n"));
                firstCircle.Move(10, 20);
                firstCircle.Draw();

                _printer.Print(string.Format("After resizing:\n"));
                firstCircle.ChangeSize(1.4);
                firstCircle.Draw();
            }
            catch (NullReferenceException ex)
            {
                _logger.WriteMessage(ex.Message, LevelOfDetalization.Error);
                _printer.Print(string.Format($"Exception occured {ex.Message}\n"));
            }
            catch (Exception ex)
            {
                _logger.WriteMessage(ex.Message, LevelOfDetalization.Error);
                _printer.Print(string.Format($"Exception occured {ex.Message}\n"));
            }
        }
    }
}
