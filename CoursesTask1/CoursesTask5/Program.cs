using Classes.Common.Logger;
using Classes.Common.Printer;
using CoursesTask5.Tasks;
using Autofac;
using CoursesTask5.Common;
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

            builder.RegisterType<FilePrinter>().As<IPrinter>().WithParameter("path", "AssemblyInfo.txt");

            builder.RegisterType<ExceptionLogger<Task1>>().As<ILogger<Task1>>();

            builder.RegisterType<ExceptionLogger<AssemblyInfoVisualizer>>().As<ILogger<AssemblyInfoVisualizer>>();

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter("path", "Exception.txt");

            builder.RegisterType<AssemblyInfoVisualizer>().AsSelf().WithParameter("assemblyName", "Classes.Common");

            return builder.Build();
        } 

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Task1>().Run();
        }
    }
}
