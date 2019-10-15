using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesTask3.Tasks;
using Classes.Common.Runner;
using Classes.Common.Logger;
using Classes.Common.Printer;

namespace CoursesTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger _logger = new ExceptionLogger();
            List<IRunnable> tasks = new List<IRunnable>()
            {
                new Task1(),
                new Task2()
            };
            try
            {
                foreach (var task in tasks)
                {
                    task.Run();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
