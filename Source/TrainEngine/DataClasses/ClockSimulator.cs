using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TrainEngine
{
    public class ClockSimulator
    {
        private DateTime Time;
        public Thread ClockRun;
        public int SecondsPerTick;
        public int MilliSecPerTick;
        private bool Running=false;
        


        public ClockSimulator(int milliecPertick , int secondspertick , DateTime settime = new DateTime())
        {
            Time = settime;
            MilliSecPerTick = milliecPertick;
            SecondsPerTick = secondspertick;
        }

        public void SetTime(TimeSpan timeOfDay)
        {

            Time = Time + timeOfDay;
            
        }

        public void StartClock()
        {
            Running = true;

            ClockRun = new Thread(RunClock);
            ClockRun.Name = "clockRunThread";
            ClockRun.Start();
        }

        public void RunClock()
        {           
                while (Running)
                {
                    IncreaseSeconds(SecondsPerTick);
                    Thread.Sleep(MilliSecPerTick);
                }
   
        }
        
            private void IncreaseSeconds(int secondIncrease = 1)
            {
                if (secondIncrease < 1) secondIncrease = 1;
                this.Time = Time.AddSeconds(secondIncrease);
            }
        

        public void Stop()
        {
            Running = false;
        }

        public DateTime GetDateTime()
        {
            return Time;
        }

        public string TimeToString()
        {
            return Time.ToShortTimeString();
        }

        public bool IsRunning()
        {
            return Running;
        }

        


    }
}
