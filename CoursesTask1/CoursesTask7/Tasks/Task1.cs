using System;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using System.Diagnostics;
using Classes.Common.Reader;
using CoursesTask7.Common;
using System.Configuration;
using System.IO;

namespace CoursesTask7.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger<Task1> _logger;
        private IFileReader excelReader;

        public Task1(IPrinter printer, ILogger<Task1> logger, IFileReader excelReader)
        {
            _printer = printer;
            _logger = logger;
            this.excelReader = excelReader;
        }

        public void Run()
        {
            Stopwatch swTotal = new Stopwatch();
            swTotal.Start();

            try
            {
                string path = ConfigurationManager.AppSettings["ExcelFilePath"].ToString();

                string data = excelReader.Read();

                TimeSpan ts = swTotal.Elapsed;

                string elapsedTime = string.Format(
                    "{0:00}h: {1:00}m: {2:00}s: {3:00}ms",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);

                _printer.Print(string.Format($"Time used for reading: {elapsedTime} \n"));


                var uniqueValues = Functions.GetUniqueValues(data);

                _printer.Print(string.Format("UNIQUE VALUES:\n"));

                foreach (var item in uniqueValues)
                {
                    _printer.Print(string.Format($"{item}, "));
                }
            }
            catch (IOException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
        }
    }
}
