using FluentAssertions;
using FluentAssertions.Common;
using SeniorConnect.Domain.Activity;
using SeniorConnect.Domain.Users;

namespace SeniorConnect.Tests
{
    public class ActivityTests
    {

        //Activity activity = new Activity();

        Participant participant1 = new Participant();

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

            var participant1 = new Participant();
            var participant2 = new Participant();

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
