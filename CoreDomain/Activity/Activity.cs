using SeniorConnect.Domain.Users;

namespace SeniorConnect.Domain.Activity;

public class Activity
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly string _description;
    private readonly DateOnly _date;
    private readonly TimeOnly _startTime;
    private readonly TimeOnly _endTime;
    private readonly int _maxParticipants;
    private readonly ActivityCoordinatorId _activityCoordinatorId;
    private readonly List<Participant> _participants = new();
    private readonly LocationId _locationId;


    public Activity(
        DateOnly dateOfActivity,
        TimeOnly startTime,
        TimeOnly endTime,
        int maxParticipants,
        ActivityCoordinatorId activityCoordinatorId,
        LocationId locationId
        )
    {
        _date = dateOfActivity;
        _startTime = startTime;
        _endTime = endTime;
        _maxParticipants = maxParticipants;
        _activityCoordinatorId = activityCoordinatorId;
        _locationId = locationId;
    }

    public void CancelReservation(Participant participant)
    {
        //check if allowed
        //session time - current time <24h
      
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
