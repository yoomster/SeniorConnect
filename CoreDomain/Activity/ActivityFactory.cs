namespace SeniorConnect.Domain.Activity
{
    public static class ActivityFactory
    {
        public static Activity CreateActivity(
            DateOnly? date = null,
            TimeOnly? startTime = null,
            TimeOnly? endTime = null,
            int maxParticipants = Activity.MaxParticipants,
            Guid? activityCoordinatorId = null,
            Guid? locationId = null,
            Guid? id = null)
        {
            return new Activity {
            date ?? Activity.Date,
            startTime ?? Activity.StartTime,
            endTime ?? Activity.Activity.EndTime,
            maxParticipants,
            ActivityCoordinatiorId
            id: id ?? Activity.Id;
            };
        }
    }
}
