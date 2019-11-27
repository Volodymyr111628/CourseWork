using System;
using System.Collections.Generic;
using System.Text;

namespace DIContainer.Common
{
    public class RandomGuidGenerator
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}
