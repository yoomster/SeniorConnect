using FluentAssertions;
using SeniorConnect.Domain.Activity;
using SeniorConnect.Domain.Users;

namespace SeniorConnect.Tests
{
    public class ActivityTests
    {
       
        [Fact]
        public void ReserveSpot_ShouldFailReservation_WhenNoMoreRoom()
        {
            //Arrange
            var activity = ActivityFactory.CreateActivity();
                //new Activity(1, Guid.NewGuid(), Guid.NewGuid());

            var participant1 = new Participant (Guid.NewGuid());
            var participant2 = new Participant(Guid.NewGuid());

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
            var activity = new Activity(1, Guid.NewGuid(), Guid.NewGuid());

            var participant = new Participant(Guid.NewGuid());

            //Act
            //cancel reservation within 24h of activity


            //Assert
            //Cancelation fails
        }
    }
}
