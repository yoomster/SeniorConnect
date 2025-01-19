using FluentAssertions;
using SeniorConnect.Domain;
using SeniorConnect.Application.Services;
using NSubstitute;
using SeniorConnect.Application.Interfaces;
using System.Diagnostics;

namespace SeniorConnect.Tests
{

    public class ActivityTests
    {

        private readonly IActivityRepository _activityRepository = Substitute.For<IActivityRepository>();
        private readonly ActivityService _sut;

        public ActivityTests()
        {
            _sut = new ActivityService(_activityRepository);
        }

        //Activity futureActivity = new Activity(
        //    title: "Tech Conference",
        //    description: "An event about unit testing.",
        //    date: DateOnly.FromDateTime(DateTime.Now.AddDays(10)),
        //    startTime: TimeOnly.Parse("09:00"),
        //    endTime: TimeOnly.Parse("17:00"),
        //    maxParticipants: 1,
        //    streetName: "Conference Road",
        //    houseNumber: "45B",
        //    zipcode: "56789",
        //    city: "Amsterdam",
        //    country: "Netherlands");

        [Fact(Skip = "Service layer not finished")]
        public void ReserveSpot_ShouldFailReservation_WhenNoMoreRoom()
        {
            ////Arrange
            //var activity = 
            //_activityRepository.ReserveSpot(futureActivity);

            //var activity = _sut.CreateActivity(futureActivity, 1002);

            //var participant1 = new ActivityRegistration();
            //var participant2 = new ActivityRegistration();

            ////Act
            //activity.ReserveSpot(participant1);
            //var action = () => activity.ReserveSpot(participant2);

            //Assert
            //action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact(Skip = "Service layer not finished")]
        public void CancelReservation_WhenCancellationIsWithin24HoursToActivity_ShouldFailCancellation()
        {
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
        }
    }
}

