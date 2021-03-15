using System;
using Xunit;

namespace TrainEngine.Tests
{
    public class PassengerTests
    {
        [Fact]
        public void AddPassengers_ById_FromIdToId_ReturnObjectOfPassengers()
        {             
            TravelPlane passengers = new TravelPlane();
         
            var Firstpassenger = Passenger.GetPassenger()[0];
            var passenger = passengers.AddPassengerIdFromTo(0, 1);
            var getindex = passenger[0];        

            Assert.Equal(Firstpassenger.FirstName, getindex.FirstName);
        }



    }
}
