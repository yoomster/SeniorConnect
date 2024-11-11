namespace SeniorConnect.Domain.Activity
{
    public static class ActivityFactory
    {
        public static Activity CreateActivity(
            DateOnly dateOfActivity,
            TimeOnly startTime,
            TimeOnly endTime,
            int maxParticipants,
            Guid locationId,
            Guid activityCoordinatorId
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

public record struct LocationId(Guid Value)
{
    public static LocationId From(Guid value) =>
        new LocationId(value);
}

public record struct ActivityCoordinatorId(Guid Value)
{
    public static ActivityCoordinatorId From(Guid value) =>
        new ActivityCoordinatorId(value);
}