using CoreDomain;
using SeniorConnect.Domain.Users;
using System.Xml.Linq;

namespace SeniorConnect.Domain.Activity;

public class Activity
{
    //This allows the DAL to access the data it needs without violating encapsulation
    public string Name => _name;
    public string Description => _description;
    public DateOnly Date => _date;
    public TimeOnly StartTime => _startTime;
    public TimeOnly EndTime => _endTime;
    public int MaxParticipants => _maxParticipants;
    public int AddressId => _addressId;

    private readonly int _id;
    private readonly string _name;
    private readonly string _description;
    private readonly DateOnly _date;
    private readonly TimeOnly _startTime;
    private readonly TimeOnly _endTime;
    private readonly int _maxParticipants;
    private readonly List<Participant> _participants = new();
    private readonly int _addressId;

    public Activity(
        int id,
        string name,
        string description,
        DateOnly date,
        TimeOnly startTime,
        TimeOnly endTime,
        int maxParticipants,
        int addressId)
    {
        _id = id;
        _name = name;
        _description = description;
        _date = date;
        _startTime = startTime;
        _endTime = endTime;
        _maxParticipants = maxParticipants;
        _addressId = addressId;
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

    //public record struct LocationId(int Value)
    //{
    //    public static LocationId From(int value) =>
    //        new LocationId(value);
    //}

    //public record struct ActivityCoordinatorId(int Value)
    //{
    //    public static ActivityCoordinatorId From(int value) =>
    //        new ActivityCoordinatorId(value);
    //}
}
