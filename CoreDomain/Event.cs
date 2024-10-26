using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain
{
    public class Event
    {
        private readonly Guid _locationId;
        private readonly Guid _EventCoordinatorId;
        private readonly List<Guid> _participants;
    }
}
