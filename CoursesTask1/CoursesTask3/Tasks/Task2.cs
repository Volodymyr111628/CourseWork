using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;

namespace CoursesTask3.Tasks
{
    class Task2 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger _logger;

        public Task2()
        {
            _printer = new ConsolePrinter();
            _logger = new ExceptionLogger();
        }

        public void Run()
        {

        }
    }
}
