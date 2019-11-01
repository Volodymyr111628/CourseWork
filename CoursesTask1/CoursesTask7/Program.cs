using CoursesTask7.Tasks;
using Autofac;
using CoursesTask7.Common;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Reader;
using System.Configuration;

namespace CoursesTask7
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
            }
            else
            {
                builder.RegisterType<ConsolePrinter>().As<IPrinter>();
            }

            builder.RegisterType<ExcelReader>().As<IFileReader>().WithParameter(
                "path", ConfigurationManager.AppSettings["ExcelFilePath"].ToString());

            builder.RegisterType<ExceptionLogger<Task1>>().As<ILogger<Task1>>();

            builder.RegisterType<ExceptionLogger<ExcelReader>>().As<ILogger<ExcelReader>>();

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter(
                "path", ConfigurationManager.AppSettings["ExceptionsFile"].ToString());
            
            return builder.Build();
        }

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Task1>().Run();
        }
    }
}