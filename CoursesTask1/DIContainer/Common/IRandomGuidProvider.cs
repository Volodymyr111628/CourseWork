using System;
using System.Collections.Generic;
using System.Text;

namespace DIContainer.Common
{
    public interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }
}
