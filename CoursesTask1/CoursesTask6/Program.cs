using CoursesTask6.Tasks;
using Autofac;
using Classes.Common.Logger;
using Classes.Common.Printer;

namespace CoursesTask6
{
    class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter("path", "Exceptions.txt");

            builder.RegisterType<Task1>();

            builder.RegisterType<Task2>();

            builder.RegisterType<ExceptionLogger<Task1>>().As<ILogger<Task1>>();

            builder.RegisterType<ExceptionLogger<Task2>>().As<ILogger<Task2>>();

            builder.RegisterType<ConsolePrinter>().As<IPrinter>();

            return builder.Build();
        }

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Task1>().Run();
            CompositionRoot().Resolve<Task2>().Run();
        }
    }
}