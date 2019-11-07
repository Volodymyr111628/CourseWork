using System;
using Autofac;
using Classes.Common.Logger;
using Classes.Common.Printer;
using CoursesTask10.Common;
using CoursesTask10.Tasks;
using System.Configuration;

namespace CoursesTask10
{
    class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Task1>().AsSelf();

            builder.RegisterType<ExceptionLogger<Task1>>().As<ILogger<Task1>>();

            int rows = Convert.ToInt32(ConfigurationManager.AppSettings["Rows"].ToString());
            int columns = Convert.ToInt32(ConfigurationManager.AppSettings["Columns"].ToString());

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = 1;
                }
            }

            builder.RegisterType<MatrixParallel>().AsSelf()
                .WithParameter("threadsCount", Convert.ToInt32(ConfigurationManager.AppSettings["ThreadsCount"].ToString()))
                .WithParameter("matrix",matrix);

            builder.RegisterType<FilePrinter>().As<ILogPrinter>().WithParameter("path", "Exceptions.txt");

            builder.RegisterType<ConsolePrinter>().As<IPrinter>();
            
            return builder.Build();
        }

        static void Main(string[] args)
        {
            try
            {
                CompositionRoot().Resolve<Task1>().Run();
            }
            catch (Exception ex)
            {
                new ConsolePrinter().Print(ex.Message);
            }
        }
    }
}
