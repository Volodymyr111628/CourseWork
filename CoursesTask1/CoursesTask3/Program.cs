using Classes.Common.Logger;
using Classes.Common.Printer;
using CoursesTask3.Tasks;
using Autofac;
using System.Diagnostics.CodeAnalysis;
using CoursesTask3.Common;

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

            builder.RegisterType<ConsolePrinter>().As<IPrinter>();

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter("path", "Exceptions.txt");

            builder.RegisterType<ExceptionLogger<Task1>>().As<ILogger<Task1>>();

            builder.RegisterType<ExceptionLogger<Task2>>().As<ILogger<Task2>>();

            builder.RegisterType<ExceptionLogger<FileSearcher>>().As<ILogger<FileSearcher>>();

            builder.RegisterType<ExceptionLogger<DirectoryVisualizer>>().As<ILogger<DirectoryVisualizer>>();

            builder.RegisterType<DirectoryVisualizer>().AsSelf();

            builder.RegisterType<FileSearcher>().AsSelf();
           
            return builder.Build();
        }

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Task1>().Run();
            CompositionRoot().Resolve<Task2>().Run();
        }
    }
}
