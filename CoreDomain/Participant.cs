﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain
{
    public class Participant
    {
        private readonly Guid _id;
        private readonly Guid _userId;
        private readonly Guid _subscriptionId;
        private readonly List<Guid> _activityIds;

    }
}
