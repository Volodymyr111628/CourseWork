using System;
using System.Configuration;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask6.Common;

namespace CoursesTask6.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer = new ConsolePrinter();
        private readonly ILogger _logger = new ExceptionLogger(
            new FilePrinter(ConfigurationManager.AppSettings["FileToWrite"].ToString()),
            ConfigurationManager.AppSettings["LevelOfDetalization"].ToString());

        public void Run()
        {
            Rectangle firstRectangle = new Rectangle(new Point(10, 10), new Point(20, 20));
            Rectangle secondRectangle = new Rectangle(new Point(15, 15), new Point(25, 25));

            try
            {
                firstRectangle.Draw();
                secondRectangle.Draw();

                _printer.Print(string.Format("\nResult of intersection:\n"));
                Rectangle resultOfIntersection = new Rectangle().GetShapesIntersection(firstRectangle, secondRectangle);
                resultOfIntersection?.Draw();

                _printer.Print(string.Format("\nResult of containing:\n"));
                Rectangle resultOfContaining = new Rectangle().GetShapeContainsTwo(firstRectangle, secondRectangle);
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
                _logger.WriteMessage(ex.ToString());
            }
            catch(Exception ex)
            {
                _printer.Print(string.Format("Exception occured:{0}\n", ex.Message));
                _logger.WriteMessage(ex.ToString());
            }
        }
    }
}
