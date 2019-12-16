using System;

namespace DIContainer.Common
{
    public interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }
}
