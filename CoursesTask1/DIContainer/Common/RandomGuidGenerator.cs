using System;

namespace DIContainer.Common
{
    public class RandomGuidGenerator
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}
