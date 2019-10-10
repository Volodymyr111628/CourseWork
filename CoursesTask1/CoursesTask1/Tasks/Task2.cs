using System.Collections.Generic;
using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask1.Common;

namespace CoursesTask1.Tasks
{
    public class Task2 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task2()
        {
            _printer = new ConsolePrinter();
        }

        public void Run()
        {
            List<Rectangle> rectangles = new List<Rectangle>()
            {
                new Rectangle(0,0,20,15),
                new Rectangle(0,0,10,25),
                new Rectangle(0,0,882.1,123.21),
                new Rectangle(0,0,20.232,283.123),
                new Rectangle(0,0,40.2332,15.231)
            };

            _printer.Print("\nTask2\n");

            foreach (Rectangle rectangle in rectangles)
            {
                _printer.Print(string.Format("Perimeter: {0} \n", rectangle.Perimeter()));
            }
        }
    }
}
