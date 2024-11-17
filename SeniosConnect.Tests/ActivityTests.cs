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

            var activity = ActivityFactory.CreateActivity(dateOfActivity, startTime, endTime, maxParticipants, locationId, activityCoordinatorId);

            var participant1 = new Participant();
            var participant2 = new Participant();

            //Act
            activity.ReserveSpot(participant1);
            var action = () => activity.ReserveSpot(participant2);

            //Assert
            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact]
        public void CancelReservation_WhenCancellationIsWithin24HoursToActivity_ShouldFailCancellation()
        {
            //Arrange
            //create activity
            //create participant
            //Reserve a spot 
            //var activity = new Activity(1, Guid.NewGuid(), Guid.NewGuid());

            var participant = new Participant();

            //Act
            //cancel reservation within 24h of activity


            //Assert
            //Cancelation fails
        }
    }
}
