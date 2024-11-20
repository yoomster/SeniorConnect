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
        private readonly DateOnly _date;
        private readonly TimeOnly _startTime;
        private readonly TimeOnly _endTime;
        private readonly Guid _id;
        private readonly int _maxParticipants;
        private readonly Guid _activityCoordinatorId;
        private readonly List<Participant> _participants = new();
        private readonly Guid _locationId;


        public Activity(
            DateOnly date,
            TimeOnly startTime,
            TimeOnly endTime,
            int maxParticipants,
            Guid activityCoordinatorId,
            Guid locationId,
            Guid? id = null )
        {
            _date = date;
            _startTime = startTime;
            _endTime = endTime;
            _id = id ?? Guid.NewGuid();
            _maxParticipants = maxParticipants;
            _activityCoordinatorId = activityCoordinatorId;
            _locationId = locationId;
        }

        public void CancelReservation(Participant participant)
        {
            var utcTimeNow = DateTime.UtcNow;
            const int minHours = 24;
            bool canNotCancel = (_date.ToDateTime(_startTime) - utcTimeNow).TotalHours < minHours;

            if (canNotCancel)
            {
                //button for canceling reservation is disabled
                throw new Exception("Cannot cancel reservation too close to session");
            }

            _participants.Remove(participant);
        }



        public void ReserveSpot(Participant participant)
        {
            //bool isFullyBooked;

            if (_participants.Count() >= _maxParticipants)
            {
                //todo: he system displays a message indicating that the activity is full. 
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
