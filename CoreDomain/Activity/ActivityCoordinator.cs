﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Domain.Activity
{
    public class ActivityCoordinator
    {
        private readonly Guid _id;
        private readonly Guid _userId;
        private readonly List<Guid> _activityIds = new();

    }
}