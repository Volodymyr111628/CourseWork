using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Runner;
using System.IO;
using Classes.Common.Printer;
using CoursesTask3.Common;

namespace CoursesTask3.Tasks
{
    class Task1 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task1()
        {
            _printer = new ConsolePrinter();
        }

        public void Run()
        {
            string path = "C:\\Users\\Hp\\Desktop\\СШІ";
            DirectoryVisualizer.VisualizeDirectory(path);
        }
    }
}
