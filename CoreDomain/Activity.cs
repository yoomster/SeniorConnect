using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain
{
    public class Activity
    {
        private readonly Guid _id;
        private readonly int _maxParticipants;
        private readonly Guid _activityCoordinatorId;
        private readonly List<Participant> _participants = new();
        private readonly Guid _locationId;


        public Activity(
            int maxParticipants,
            //Guid activityCoordinatorId,
            Guid? id = null)
        {
            _maxParticipants = maxParticipants;
            //_activityCoordinatorId = activityCoordinatorId;
            _id = id ?? Guid.NewGuid();
        }

        public bool ReserveSpot(Participant participant)
        {
            if (_participants.Count() <= _maxParticipants)
            {
                return false;
                //throw new NotImplementedException("maximum participants reached");
            }
            else
            {
                _participants.Add(participant);
                return true;
            }
        }
    }
}
