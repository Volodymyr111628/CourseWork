using System;
using Classes.Common.Logger;
using Classes.Common.Runner;
using Classes.Common.Printer;
using System.Configuration;
using CoursesTask5.Common;
using NLog;

namespace CoursesTask5.Tasks
{
    public class Task1 : IRunnable
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Classes.Common.Logger.ILogger _exceptionLogger;
        private readonly IPrinter _consolePrinter;

        public Task1()
        {
            _consolePrinter = new ConsolePrinter();
            _exceptionLogger = new ExceptionLogger(new FilePrinter(ConfigurationManager.AppSettings["FileToWrite"].ToString()),
                ConfigurationManager.AppSettings["LevelOfDetalization"].ToString());
        }

        public void Run()
        {
            string assemblyName = "Classes.Commonn";

            AssemblyInfoVisualizer visualizeAssebly = new AssemblyInfoVisualizer(assemblyName);
            try
            {
                visualizeAssebly.VisualizeAssemblyInfo();
            }
            catch (ArgumentException ex)
            {
                _consolePrinter.Print(string.Format($"Exception occured {ex.Message} \n"));
                _exceptionLogger.WriteMessage(ex.ToString());
                logger.Error(ex);
            }
            catch (Exception ex)
            {
                _consolePrinter.Print(string.Format($"Exception occured {ex.Message} \n"));
                _exceptionLogger.WriteMessage(ex.ToString());
                logger.Error(ex);
            }
        }
    }
}
