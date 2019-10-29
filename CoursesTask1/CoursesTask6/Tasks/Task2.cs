using System.Configuration;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask6.Common;

namespace CoursesTask6.Tasks
{
    class Task2:IRunnable
    {
        private readonly IPrinter _printer = new ConsolePrinter();
        private readonly ILogger _logger = new ExceptionLogger(
            new FilePrinter(ConfigurationManager.AppSettings["FileToWrite"].ToString()),
            ConfigurationManager.AppSettings["LevelOfDetalization"].ToString());

        public void Run()
        {
            Circle firstCircle = new Circle(new Point(10, 10), 20);
            Circle secondCircle = new Circle(new Point(20, 20), 5);

            firstCircle.Draw();
            secondCircle.Draw();

            _printer.Print("Circle which contains two circles:\n");
            Circle containsTwoCircle = new Circle().GetShapeContainsTwo(firstCircle, secondCircle);
            containsTwoCircle.Draw();
        }
    }
}
