using System.Collections.Generic;
using Classes.Common.Runner;
using CoursesTask7.Tasks;
using Autofac;
using CoursesTask7.Common;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Reader;

namespace CoursesTask5
{
    class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Task1>();

            builder.RegisterType<ExcelReader>().As<IFileReader>();

            builder.RegisterType<ExceptionLogger<Task1>>().As<ILogger<Task1>>();

            builder.RegisterType<ExceptionLogger<ExcelReader>>().As<ILogger<ExcelReader>>();

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter("path", "Exceptions.txt");

            //builder.RegisterType<FilePrinter>().As<IPrinter>().WithParameter("path","Data.txt");

            builder.RegisterType<ConsolePrinter>().As<IPrinter>();

            return builder.Build();
        }

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Task1>().Run();
        }
    }
}