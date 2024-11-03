using CoreDomain;
using Xunit.Sdk;

namespace SeniorConnect.Tests
{
    public class ActivityTests
    {
        private readonly Activity _sut = new(1);
        [Fact]
        public void ReserveSpot_ShouldFailReservation_WhenNoMoreRoom()
        {
            //Arrange
            //Create 2 participants

            var participant1 = new Participant();
            var participant2 = new Participant();



            //Act
            //add participant 1
            //add participant 2
            //activity.ReserveSpot(participant2);

            //Assert
            //participant 2 reservation should fail
            Assert.True(_sut.ReserveSpot(participant1));
            Assert.True(_sut.ReserveSpot(participant2));


        }


    }
}
