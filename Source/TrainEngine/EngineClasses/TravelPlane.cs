using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace TrainEngine
{
    public class TravelPlane 
    {
        private ClockSimulator clockSim = new ClockSimulator(100, 60);
        private List<Schedule> timeTable = Schedule.GetSchedule();
        

        public TravelPlane()
        { 
            clockSim.SetTime(new TimeSpan(10,00,00));
            clockSim.StartClock();
        }

       

        public void OperateTrain(Train train)
        {
            Thread trainThr = new Thread(() => Start(train, timeTable, clockSim));
            trainThr.Start();
        }

        

        public void Start(Train train, List<Schedule> timeTable, ClockSimulator clockSim)
        {
            timeTable = timeTable.Where(x => x.TrainId == train.TrainId).ToList();

            
            while (timeTable.Any())
            {
                
                if (!train.IsRunning() && timeTable[0].DepartureTime.TimeOfDay <= clockSim.GetDateTime().TimeOfDay)
                {
                    train.StartTrain();
                    Console.WriteLine($"Log {clockSim.TimeToString()} : {train.TrainName} : departing from {Station.GetStation().Find(s => s.StationId == timeTable[0].DepStationId).StationName} station");
                }
                if (train.IsRunning() && timeTable[0].ArrivalTime.TimeOfDay <= clockSim.GetDateTime().TimeOfDay)
                {
                    train.StopTrain();
                    Console.WriteLine($"Log {clockSim.TimeToString()} : {train.TrainName} : arriving at {Station.GetStation().Find(s => s.StationId == timeTable[0].ArrvStationId).StationName} station");
                    timeTable.Remove(timeTable[0]);
                }
            }
        }


    }
}
