using System;
using Xunit;

namespace TrainEngine.Tests
{
    public class TravelPlanTests
    {
        [Fact]
        public void AddPassengers_ById_FromIdToId_ReturnObjectOfPassengers()
        {
            var train1 = Train.GetTrain();
            TravelPlane passengers = new TravelPlane();

            var trip = passengers.NewTrip(train1[1]);
            

            Assert.NotNull(trip);
        }



    }
}
