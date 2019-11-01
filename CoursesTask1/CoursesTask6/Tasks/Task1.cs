using System;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask6.Common;

namespace CoursesTask6.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger<Task1> _logger;

        public Task1(IPrinter printer, ILogger<Task1> logger)
        {
            _logger = logger;
            _printer = printer;
        }

        public void Run()
        {
            var firstRectangle = new Rectangle(new Point(10,10),new Point(20,20));
            var secondRectangle = new Rectangle(new Point(11, 11), new Point(21, 21));

            try
            {
                _printer.Print("First Rectangle: \n");

                firstRectangle.Draw();

                secondRectangle.Move(5, 5);

                _printer.Print("Second Rectangle: \n");

                secondRectangle.Draw();

                _printer.Print(string.Format("\nResult of intersection:\n"));
                var resultOfIntersection = new Rectangle().GetShapesIntersection(firstRectangle, secondRectangle);
                resultOfIntersection?.Draw();

                _printer.Print(string.Format("\nResult of containing:\n"));
                var resultOfContaining = new Rectangle().GetShapeContainsTwo(firstRectangle, secondRectangle);
                resultOfContaining?.Draw();

                secondRectangle.Move(5, 5);
                _printer.Print(string.Format("\nResult of intersection after moving second rectangle:\n"));
                resultOfIntersection = new Rectangle().GetShapesIntersection(firstRectangle, secondRectangle);
                resultOfIntersection?.Draw();

                _printer.Print(string.Format("\nResult of intersection after resizing first rectangle:\n"));
                firstRectangle.ChangeSize(1.2);
                resultOfIntersection = new Rectangle().GetShapesIntersection(firstRectangle, secondRectangle);
                resultOfIntersection?.Draw();
            }
            catch (NullReferenceException ex)
            {
                _printer.Print(string.Format("Exception occured:{0}\n", ex.Message));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format("Exception occured:{0}\n", ex.Message));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
        }
    }
}
