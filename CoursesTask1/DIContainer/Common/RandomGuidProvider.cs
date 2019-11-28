using System;

namespace DIContainer.Common
{
    public class RandomGuidProvider : IRandomGuidProvider
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}