using Classes.Common.Printer;

namespace DIContainer.Common
{
    public class SomeService : ISomeService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;
        private readonly IPrinter _printer;


        public SomeService(IRandomGuidProvider randomGuidprovider, IPrinter printer)
        {
            _randomGuidProvider = randomGuidprovider;
            _printer = printer;
        }

        public void Print()
        {
            _printer.Print(string.Format($"Random generated guid {_randomGuidProvider.RandomGuid.ToString()}\n"));
        }
    }
}
