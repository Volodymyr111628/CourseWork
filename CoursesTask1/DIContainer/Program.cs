using DIContainer.Common;
using DIContainer.DependencyInjection;
using Classes.Common.Printer;

namespace DIContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new DiServiceCollection();

            services.RegisterSingleton<ISomeService, SomeService>();
            services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();
            services.RegisterSingleton<IPrinter, ConsolePrinter>();
             
            var container = services.GenerateContainer();

            var serviceFirst = container.GetService<ISomeService>();
            var serviceSecond = container.GetService<ISomeService>();

            serviceFirst.Print();
            serviceSecond.Print();
        }
    }
}
