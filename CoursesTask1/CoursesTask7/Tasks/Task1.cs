using System;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using System.Diagnostics;
using Classes.Common.Reader;

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

            string path = "Sample.xlsx";
            
            string data = excelReader.Read(path);

            TimeSpan ts = swTotal.Elapsed;

            string elapsedTime = String.Format(
                "{0:00}h: {1:00}m: {2:00}s: {3:00}ms",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            _printer.Print(string.Format($"Time used: {elapsedTime} \n"));

            _printer.Print(data);
        }
    }
}
