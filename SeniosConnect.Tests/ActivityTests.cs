using FluentAssertions;
using SeniorConnect.Domain;
using SeniorConnect.Application.Services;

namespace SeniorConnect.Tests
{
    public class ActivityTests
    {
        Activity futureActivity = new Activity(
    id: 1,
    title: "Tech Conference",
    description: "A conference about new technologies.",
    date: DateOnly.FromDateTime(DateTime.Now.AddDays(10)), // Future date
    startTime: TimeOnly.Parse("09:00"),
    endTime: TimeOnly.Parse("17:00"),
    maxParticipants: 100,
    streetName: "Conference Road",
    houseNumber: "45B",
    zipcode: "56789",
    city: "Amsterdam",
    country: "Netherlands"
)
        { };

        // This will throw an exception
        Activity pastActivity = new Activity(
            id: 2,
            title: "Past Event",
            description: "An event that already happened.",
            date: DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), // Past date
            startTime: TimeOnly.Parse("10:00"),
            endTime: TimeOnly.Parse("15:00"),
            maxParticipants: 50,
            streetName: "History Lane",
            houseNumber: "12A",
            zipcode: "12345",
            city: "Eindhoven",
            country: "Netherlands"
        );

        ActivityRegistration participant1 = new ActivityRegistration();

        [Fact]
        public void ReserveSpot_ShouldFailReservation_WhenNoMoreRoom()
        {
            //Arrange
            var dateOfActivity = DateOnly.Parse("2024-12-01");
            var startTime = TimeOnly.Parse("10:00");
            var endTime = TimeOnly.Parse("12:00");
            int maxParticipants = 1;  
            int locationId = 100;
            int activityCoordinatorId = 200;

            var activity = CreateActivity(dateOfActivity, startTime, endTime, maxParticipants, locationId, activityCoordinatorId);

            var participant1 = new ActivityRegistration();
            var participant2 = new ActivityRegistration();

            //Act
            activity.ReserveSpot(participant1);
            var action = () => activity.ReserveSpot(participant2);

            //Assert
            action.Should().ThrowExactly<InvalidOperationException>();
        }

        //[Fact]
        //public void CancelReservation_WhenCancellationIsWithin24HoursToActivity_ShouldFailCancellation()
        //{
        //    //Arrange
        //    //create activity
        //    //create participant
        //    //Reserve a spot 
        //    var activity = ActivityFactory.CreateActivity(
        //        date: DateOnly.FromDateTime(DateTime.UtcNow),
        //        startTime: TimeOnly.Parse("22:00"),
        //        endTime: TimeOnly.Parse("23:00"));

        //    var participant = new Participant();

        //    activity.ReserveSpot(participant);

        //    //set a test date to the same date as the activity
        //    var cancelationDateTime = DateTime.UtcNow.Date.Add(TimeOnly.Parse("12:00").ToTimeSpan());
        //    //var cancelDateTime = activity.Date.ToDateTime(TimeOnly.MinValue - TimeOnly.Parse("5:00"));

        //    //Act
        //    //cancel reservation within 24h of activity, so on the same date
        //    var action = () => activity.CancelReservation(participant);


        //    //Assert
        //    //Cancelation fails
        //    action.Should().ThrowExactly<Exception>();
        //}
    }
}
