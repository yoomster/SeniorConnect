namespace SeniorConnect.Domain.Activity
{
    public static class ActivityFactory
    {
        public static Activity CreateActivity(
            int id,
            string name,
            string description,
            DateOnly date,
            TimeOnly startTime,
            TimeOnly endTime,
            int maxParticipants
            )
        {
            return new Activity(
            id,
            name,
            description,
            date,
            startTime,
            endTime,
            maxParticipants
            );
        }
    }
}

public record struct LocationId(int Value)
{
    public static LocationId From(int value) =>
        new LocationId(value);
}

public record struct ActivityCoordinatorId(int Value)
{
    public static ActivityCoordinatorId From(int value) =>
        new ActivityCoordinatorId(value);
}