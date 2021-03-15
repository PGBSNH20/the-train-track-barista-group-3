using System;
using Xunit;

namespace TrainEngine.Tests
{
    public class EngineTests
    {
        [Fact]
        public void WhenStartingEngine_CheckIf_EngineIsRunning_ReturnTrue()
        {
          
            Engine engine = new Engine();
            
            engine.Start();
            var check = engine.IsRunning();          

            Assert.True(check);
        }

        [Fact]
        public void WhenStopingEngine_CheckIf_EngineIsRunning_ReturnFalse()
        {

            Engine engine = new Engine();

            engine.Stop();
            var check = engine.IsRunning();

            Assert.False(check);
        }

        [Fact]
        public void CheckIf_EngineIsRunning_InDefault_ReturnFalse()
        {
        
            Engine engine = new Engine();
       
            engine.IsRunning();
            var check = engine.IsRunning();  

            Assert.False(check);
        }

    }
}
