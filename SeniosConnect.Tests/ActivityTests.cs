using FluentAssertions;
using SeniorConnect.Domain.Activity;
using SeniorConnect.Domain.Users;

namespace SeniorConnect.Tests
{
    public class ActivityTests
    {
        private readonly Activity _sut = new(1, Guid.NewGuid(), Guid.NewGuid());
        [Fact]
        public void ReserveSpot_ShouldFailReservation_WhenNoMoreRoom()
        {
            //Arrange
            //Create 2 participants
            var participant1 = new Participant();
            var participant2 = new Participant();

            //Act
            //add both participants 
            Action result = () => _sut.ReserveSpot(participant1);
            Action result2 = () => _sut.ReserveSpot(participant2);
            //activity.ReserveSpot(participant2);

            //Assert
            //participant 2 reservation should fail
            result.Should().Throw<NotImplementedException>();
            result2.Should().Throw<NotImplementedException>();
            


        }



    }
}
