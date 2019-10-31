using Classes.Common.Logger;
using Classes.Common.Printer;
using CoursesTask4.Tasks;
using Autofac;
using CoursesTask4.Common;
using System.Diagnostics.CodeAnalysis;

namespace CoursesTask5
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Task1>();

            builder.RegisterType<Task2>();

            builder.RegisterType<Task3>();

            builder.RegisterType<FilePrinter>().As<IPrinter>().WithParameter("path", "Car.txt");

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter("path", "Exception");

            builder.RegisterType<ExceptionLogger<Task1>>().As<ILogger<Task1>>();

            builder.RegisterType<ExceptionLogger<Task2>>().As<ILogger<Task2>>();

            builder.RegisterType<ExceptionLogger<Task3>>().As<ILogger<Task3>>();
            
            return builder.Build();
        }

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Task1>().Run();
            CompositionRoot().Resolve<Task2>().Run();
            CompositionRoot().Resolve<Task3>().Run();
        }
    }
}
