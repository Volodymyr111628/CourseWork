using System;
using DIContainer.Common;
using DIContainer.DependencyInjection;

namespace DIContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new DiServiceCollection();

            //services.RegisterSingleton<RandomGuidGenerator>();
            //services.RegisterSingleton<RandomGuidGenerator>();

            services.RegisterTransient<ISomeService, SomeService>();

            var container = services.GenerateContainer();

            var serviceFirst = container.GetService<RandomGuidGenerator>();
            var serviceSecond = container.GetService<RandomGuidGenerator>();

            Console.WriteLine(serviceFirst.RandomGuid);
            Console.WriteLine(serviceSecond.RandomGuid);
        }
    }
}
