namespace SeniorConnect.Domain;

public class Activity
{
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
        string country)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        if (date <= today)
            throw new ArgumentException("The date must be in the future.", nameof(date));

        if (endTime <= startTime)
            throw new ArgumentException("End time must be after start time.", nameof(endTime));

        if (maxParticipants <= 0)
            throw new ArgumentException("Max participants must be greater than zero.", nameof(maxParticipants));
        
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
    }

    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required DateOnly Date { get; init; }
    public required TimeOnly StartTime { get; init; }
    public required TimeOnly EndTime { get; init; }
    public required int MaxParticipants { get; init; }
    public required string StreetName { get; init; }
    public required string HouseNumber { get; init; }
    public required string Zipcode { get; init; }
    public required string City { get; init; }
    public required string Country { get; init; }
}
