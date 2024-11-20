namespace SeniorConnect.Domain.Activity
{
    public static class ActivityFactory
    {
        public static Activity CreateActivity(
            DateOnly dateOfActivity,
            TimeOnly startTime,
            TimeOnly endTime,
            int maxParticipants,
            int locationId,
            int activityCoordinatorId
            )
        {
            return new Activity(
            dateOfActivity,
            startTime,
            endTime,
            maxParticipants,
            ActivityCoordinatorId.From(activityCoordinatorId),
            LocationId.From(locationId)
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