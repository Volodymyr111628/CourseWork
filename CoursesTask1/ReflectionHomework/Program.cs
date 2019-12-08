using ReflectionHomework.Task;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Autofac;

namespace CoursesTask9
{
    class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Task>();

            builder.RegisterType<ExceptionLogger<Task>>().As<ILogger<Task>>();

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter(
                "path", "ExceptionsReflectionHomework.txt");

            builder.RegisterType<ConsolePrinter>().As<IPrinter>();

            return builder.Build();
        }

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Task>().Run();
        }
    }
}