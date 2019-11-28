using System;
using System.Collections.Generic;
using System.Text;

namespace DIContainer.Common
{
    public class SomeService : ISomeService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;
        

        public SomeService(IRandomGuidProvider randomGuidprovider)
        {
            _randomGuidProvider = randomGuidprovider;
        }

        public void Print()
        {
            Console.WriteLine(_randomGuidProvider.RandomGuid);
        }
    }
}
