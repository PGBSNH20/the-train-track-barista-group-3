using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.IO;

namespace TrainEngine
{
   
    public class TravelPlane /*: ITravelPlane*/
    {        
        private ClockSimulator clockSim = new ClockSimulator(100, 60);
        private List<Schedule> timeTable = Schedule.GetSchedule();        
        private List<Passenger> passengerList = new List<Passenger>();
        private List<Passenger> allPassengers = Passenger.GetPassenger();
        private List<Schedule> save = new List<Schedule>();
        private List<Cart> loaded = Cart.GetLoadedSchedule();
        private Cart cartToSave = new Cart();
        private bool done = false;
        private List<string> trainId = new List<string>();
        const string filePpath = @"C:\Users\doman\OneDrive\Desktop\RailWayPro\Source\TrainEngine\Data\SavedTrips.txt";



        public TravelPlane()
        {
            clockSim.SetTime(new TimeSpan(10, 00, 00));
            clockSim.StartClock();
        }

        public List<Passenger> AddPassengerIdFromTo(int idFrom, int idTo)
        {
            var paxAdded = allPassengers.Where(x => x.PassengerId >= idFrom && x.PassengerId <= idTo);
            foreach (var item in paxAdded)
            {
                passengerList.Add(item );
            }
            return passengerList;
        }
        public void PrintAllPassengers()
        {
            Console.WriteLine("Passengers below added to train number: " + trainId[0]);
            foreach (var item in  passengerList)
            {
                
                Console.WriteLine(item.PassengerId + ":" + item.LastName);

            }
           
        }

        public void NewTrip(Train train)
        {
            
            Thread trainThr = new Thread(() => Start(train, timeTable, clockSim));
            trainThr.Start();
            
           
        }
       

        public void Start(Train train, List<Schedule> timeTable, ClockSimulator clockSim)
        {
            timeTable = timeTable.Where(x => x.TrainId == train.TrainId).ToList();
            foreach (var item in timeTable)
            {
                save.Add(item);
                trainId.Add(item.TrainId.ToString()); 
    
            }           
            
            while (timeTable.Any())
            {
                if (!train.IsRunning() && train.Operated == true && timeTable[0].DepartureTime.TimeOfDay <= clockSim.GetDateTime().TimeOfDay)
                {

                    train.StartTrain();
                    Console.WriteLine($"Train:{timeTable[0].TrainId} {clockSim.TimeToString()} : {train.TrainName} : departing from {Station.GetStation().Find(s => s.StationId == timeTable[0].DepStationId).StationName} station ");

                }
                if (train.IsRunning()  && timeTable[0].ArrivalTime.TimeOfDay <= clockSim.GetDateTime().TimeOfDay)
                {
                    train.StopTrain();
                    Console.WriteLine($"Train:{timeTable[0].TrainId} {clockSim.TimeToString()} : {train.TrainName} : arriving at {Station.GetStation().Find(s => s.StationId == timeTable[0].ArrvStationId).StationName} station ");
                    timeTable.Remove(timeTable[0]);
                }                
            }
            done = true;
        }


        public void Save()
        {
            while (done==false)
            {
                cartToSave.SaveToFile(save);
                
            }
            done = false;
        }
        public void Load( )
        {            
                cartToSave.Load(loaded);
        }
       
        

    }
}
