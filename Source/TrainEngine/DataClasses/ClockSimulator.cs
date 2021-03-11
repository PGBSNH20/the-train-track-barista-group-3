using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TrainEngine
{
    public class ClockSimulator
    {
        private DateTime time;
        public Thread clockRun;
        public int secondsPerTick;
        public int milliSecPerTick;
        private bool Running=false;
        


        public ClockSimulator(int milliecPertick , int secondspertick = 1, DateTime settime = new DateTime())
        {
            time = settime;
            milliSecPerTick = milliecPertick;
            secondsPerTick = secondspertick;
        }

        public void SetTime(TimeSpan timeOfDay)
        {

            time = time.Date + timeOfDay;
            //TimeSpan time = TimeSpan.Parse(timeToset);
            //this.time = this.time.Date + time;


            //time = time + timeToset;
        }

        public void StartClock()
        {
            Running = true;

            clockRun = new Thread(RunClock);
            clockRun.Name = "clockRunThread";
            clockRun.Start();
        }

        public void RunClock()
        {           
                while (Running)
                {
                    IncreaseSeconds(secondsPerTick);
                    Thread.Sleep(milliSecPerTick);
                }
   
        }
        
            private void IncreaseSeconds(int secondIncrease = 1)
            {
                if (secondIncrease < 1) secondIncrease = 1;
                this.time = time.AddSeconds(secondIncrease);
            }
        

        public void Stop()
        {
            Running = false;
        }

        public DateTime GetDateTime()
        {
            return time;
        }

        public string TimeToString()
        {
            return time.ToShortTimeString();
        }

        //public void PrintClock()
        //{           
        //  Console.WriteLine(TimeToString());                        
        //}

        public bool IsRunning()
        {
            return Running;
        }

        


    }
}
