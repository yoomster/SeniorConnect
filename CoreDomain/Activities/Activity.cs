using CoreDomain;
using SeniorConnect.Domain.Users;
using System.Xml.Linq;

namespace SeniorConnect.Domain.Activities;

public class Activity
{
    //This allows the DAL to access the data it needs without violating encapsulation
    //public string Name => _name;
    //public string Description => _description;
    //public DateOnly Date => _date;
    //public TimeOnly StartTime => _startTime;
    //public TimeOnly EndTime => _endTime;
    //public int MaxParticipants => _maxParticipants;

    //private readonly int _id;
    //private readonly string _name;
    //private readonly string _description;
    //private readonly DateOnly _date;
    //private readonly TimeOnly _startTime;
    //private readonly TimeOnly _endTime;
    //private readonly int _maxParticipants;
    //private readonly List<Participant> _participants = new();

    public required int ActivityId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateOnly Date { get; set; }
    public required TimeOnly StartTime { get; set; }
    public required TimeOnly EndTime { get; set; }
    public required int MaxParticipants { get; set; }

    public required string StreetName { get; set; }
    public required string HouseNumber { get; set; }
    public required string Zipcode { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }


    //public Activity(
    //    int id,
    //    string name,
    //    string description,
    //    DateOnly date,
    //    TimeOnly startTime,
    //    TimeOnly endTime,
    //    int maxParticipants)
    //{
    //    _id = id;
    //    _name = name;
    //    _description = description;
    //    _date = date;
    //    _startTime = startTime;
    //    _endTime = endTime;
    //    _maxParticipants = maxParticipants;
    //}

    public bool IsValid()
    {
        return Date > DateOnly.FromDateTime(DateTime.Now);
    }

    //public void CancelReservation(Participant participant)
    //    {
    //        var utcTimeNow = DateTime.UtcNow;
    //        const int minHours = 24;
    //        bool canNotCancel = (_date.ToDateTime(_startTime) - utcTimeNow).TotalHours < minHours;

    //        if (canNotCancel)
    //        {
    //            //button for canceling reservation is disabled
    //            throw new Exception("Cannot cancel reservation too close to session");
    //        }

    //        _participants.Remove(participant);
    //    }

    //public void ReserveSpot(Participant participant)
    //{
    //    if (_participants.Count() >= _maxParticipants)
    //    {
    //        //todo: he system displays a message indicating that the activity is full. 
    //        throw new InvalidOperationException ("maximum participants reached");
    //    }
    //    else
    //    {
    //        _participants.Add(participant);
    //        //Add the activity ID to participant 
    //        participant.AddActivityToList(_id);
    //    }
    //}
}
