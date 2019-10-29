using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using System.Configuration;

namespace CoursesTask7.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer = new ConsolePrinter();
        private readonly ILogger _logger = new ExceptionLogger(
            new FilePrinter(ConfigurationManager.AppSettings["FileToWrite"].ToString()),
            ConfigurationManager.AppSettings["LevelOfDetalization"].ToString());

        public void Run()
        {

        }
    }
}
