using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeniorConnect.Domain.Users;

namespace SeniorConnect.Domain.Activity
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
            Guid activityCoordinatorId,
            Guid locationId,
            Guid? id = null )
        {
            _id = id ?? Guid.NewGuid();
            _maxParticipants = maxParticipants;
            _activityCoordinatorId = activityCoordinatorId;
            _locationId = locationId;
        }

        //public Activity(int maxParticipants)
        //{
        //    _maxParticipants = maxParticipants;
        //}



        public void ReserveSpot(Participant participant)
        {
            //bool isFullyBooked;

            if (_participants.Count() >= _maxParticipants)
            {
                //The system displays a message indicating that the activity is full. 
                throw new InvalidOperationException ("maximum participants reached");
            }
            else
            {
                _participants.Add(participant);
                //Add the activity ID to participant 
                participant.AddActivityToList(_id);
            }
        }
    }
}
