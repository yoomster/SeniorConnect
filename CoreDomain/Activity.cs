namespace SeniorConnect.Domain;

public class Activity
{
    public Activity(
        string title,
        string description,
        DateOnly date,
        TimeOnly startTime,
        TimeOnly endTime,
        int maxParticipants,
        string streetName,
        string houseNumber,
        string zipcode,
        string city,
        string country)
    {
        ValidateInputs(date, startTime, endTime, maxParticipants);
        
        Title = title;
        Description = description;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        MaxParticipants = maxParticipants;
        StreetName = streetName;
        HouseNumber = houseNumber;
        Zipcode = zipcode;
        City = city;
        Country = country;
    }

    public Activity(
        int id,
        string title,
        string description,
        DateOnly date,
        TimeOnly startTime,
        TimeOnly endTime,
        int maxParticipants,
        string streetName,
        string houseNumber,
        string zipcode,
        string city,
        string country,
        int hostUserId)
    {
        Id = id;
        Title = title;
        Description = description;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        MaxParticipants = maxParticipants;
        StreetName = streetName;
        HouseNumber = houseNumber;
        Zipcode = zipcode;
        City = city;
        Country = country;
        HostUserId = hostUserId;
    }

    private void ValidateInputs(DateOnly date, TimeOnly startTime, TimeOnly endTime, int maxParticipants)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        if (date <= today)
            throw new ArgumentException("The date must be in the future.", nameof(date));

        if (endTime <= startTime)
            throw new ArgumentException("End time must be after start time.", nameof(endTime));

        if (maxParticipants <= 0)
            throw new ArgumentException("Max participants must be greater than zero.", nameof(maxParticipants));
    }

    public  int Id { get; init; }
    public  string Title { get; init; }
    public  string Description { get; init; }
    public  DateOnly Date { get; init; }
    public TimeOnly StartTime { get; init; }
    public  TimeOnly EndTime { get; init; }
    public  int MaxParticipants { get; init; }
    public  string StreetName { get; init; }
    public  string HouseNumber { get; init; }
    public  string Zipcode { get; init; }
    public  string City { get; init; }
    public  string Country { get; init; }
    public int HostUserId{ get; private set; } 

    public void AssignHostUser(int hostUserId)
    {
        //if (HostUserId != null)
        //    throw new InvalidOperationException("HostUserId has already been assigned.");
        HostUserId = hostUserId;
    }
}
