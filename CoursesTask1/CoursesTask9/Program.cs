using CoursesTask9.Tasks;
using Autofac;
using CoursesTask9.Common;
using Classes.Common.Logger;
using Classes.Common.Printer;
using System.Configuration;

namespace CoursesTask9
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

            builder.RegisterType<ExceptionLogger<FilesManager>>().As<ILogger<FilesManager>>();

            builder.RegisterType<ExceptionLogger<Task1>>().As<ILogger<Task1>>();

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter(
                "path", ConfigurationManager.AppSettings["ExceptionsFile"].ToString());
                
            builder.RegisterType<FilesManager>().AsSelf();

            return builder.Build();
        }

        static void Main(string[] args)
        {
                CompositionRoot().Resolve<Task1>().Run();
        }
    }
}