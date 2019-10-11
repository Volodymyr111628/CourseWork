using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesTask3.Tasks;
using Classes.Common.Runner;

namespace CoursesTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRunnable> tasks = new List<IRunnable>()
            {
                new Task1()
            };
            foreach (var task in tasks)
            {
                task.Run();
            }
        }
    }
}
