using System;
using Xunit;
using System.Threading;

namespace TrainEngine.Tests
{
    public class ClockTests
    {
        
        [Fact]
        public void SetTimeTest_SetTime_ClockReturns_09_00_00()
        {
           
            ClockSimulator clockSim = new ClockSimulator(1, 60);

            clockSim.SetTime(new TimeSpan(09, 00, 00));

            Assert.Equal("09:00", clockSim.TimeToString());
        }


        [Fact]
        public void GetDateTimeTest_ReturnSetDateTime()
        {
           
            DateTime now = DateTime.Now;

            ClockSimulator clockSim = new ClockSimulator(1, 60, now);

            Assert.Equal(now, clockSim.GetDateTime());
        }


      
    }
}
