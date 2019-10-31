using CoursesTask8.Tasks;
using Autofac;
using CoursesTask8.Common;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Reader;
using System.Configuration;

namespace CoursesTask5
{
    class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Task1>();
            
            if (ConfigurationManager.AppSettings["Output"].ToString() == "File")
            {
                builder.RegisterType<FilePrinter>().As<IPrinter>().WithParameter(
                    "path", ConfigurationManager.AppSettings["FilePath"].ToString());

                builder.RegisterType<FileReader>().As<IReader>().WithParameter(
                    "path", ConfigurationManager.AppSettings["SourceFile"].ToString());

                builder.RegisterType<ExceptionLogger<FileReader>>().As<ILogger<FileReader>>();
                
            }
            else
            {
                builder.RegisterType<ConsolePrinter>().As<IPrinter>();

                builder.RegisterType<ConsoleReader>().As<IReader>();
            }

            builder.RegisterType<ExceptionLogger<Calculator>>().As<ILogger<Calculator>>();

            builder.RegisterType<ExceptionLogger<Task1>>().As<ILogger<Task1>>();

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter(
                "path", ConfigurationManager.AppSettings["ExceptionsFile"].ToString());

            builder.RegisterType<Calculator>().As<ICalculator>();

            return builder.Build();
        }

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Task1>().Run();
        }
    }
}