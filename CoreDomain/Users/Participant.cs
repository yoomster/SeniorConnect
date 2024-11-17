using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Domain.Users
{
    public class Participant
    {
        private readonly int _id;
        private readonly int _userId;
        private readonly int _subscriptionId;
        private readonly List<int> _activityIds = new();

        public void AddActivityToList (int id)
        {
            //verification needed
            _activityIds.Add(id);
        }
    }
}
