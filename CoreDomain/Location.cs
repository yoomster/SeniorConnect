﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain
{
    public class Location
    {
        private readonly int _id;
        private readonly List<int> _activityIds = new();
    }
}
