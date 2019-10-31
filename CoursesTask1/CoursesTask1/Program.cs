using System.Collections.Generic;
using Classes.Common.Runner;
using CoursesTask1.Tasks;

namespace CoursesTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<IRunnable>
            {
                new Task1(),
                new Task2(),
                new Task3(),
                new Task4(),
                new Task5()
            };

            foreach (var task in tasks)
            {
                task.Run();
            }
        }
    }
}
