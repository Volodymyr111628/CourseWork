using System;
using System.Collections.Generic;
using System.Text;

namespace DIContainer.Common
{
    public class SomeService : ISomeService
    {
        private readonly Guid RandomGuid = Guid.NewGuid(); 
        public void Print()
        {
            Console.WriteLine(RandomGuid);
        }
    }
}
