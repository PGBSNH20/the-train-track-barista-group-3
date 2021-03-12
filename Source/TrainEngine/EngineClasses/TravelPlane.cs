using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.IO;

namespace TrainEngine
{
    public class TravelPlane : ITravelPlane
    {
        private ClockSimulator clockSim = new ClockSimulator(100, 60);
        private List<Schedule> timeTable = Schedule.GetSchedule();

        Dictionary<Passenger, int> passengerList = new Dictionary<Passenger, int>();
        private List<Passenger> allPassengers = Passenger.GetPassenger();
        private List<Schedule> Saved = new List<Schedule>();
        List<string> TrainIdSaved = new List<string>();

        const string filePath = @"C:\Users\doman\OneDrive\Desktop\Railway\Source\TrainEngine\Data\SavedTrips.txt";

        public TravelPlane()
        {
            clockSim.SetTime(new TimeSpan(10, 00, 00));
            clockSim.StartClock();
        }

        public ITravelPlane AddPassengerIdFromTo(int idFrom, int idTo, int trainId)
        {
            var paxAdded = allPassengers.Where(x => x.PassengerId >= idFrom && x.PassengerId <= idTo);
            foreach (var item in paxAdded)
            {
                passengerList.Add(item, trainId);
            }
            return this;
        }
        public ITravelPlane PrintAllPassengers()
        {
            foreach (KeyValuePair<Passenger, int> pax in passengerList)
            {
                Console.WriteLine((pax.Key.PassengerId + ":" + pax.Key.LastName, $"train ID :{ pax.Value}"));

            }
            return this;
        }

        public ITravelPlane NewTrip(Train train)
        {
            TrainIdSaved.Add(train.TrainId.ToString());
            Thread trainThr = new Thread(() => Start(train, timeTable, clockSim));
            trainThr.Start();
            return this;
        }

        public void Start(Train train, List<Schedule> timeTable, ClockSimulator clockSim)
        {


            timeTable = timeTable.Where(x => x.TrainId == train.TrainId).ToList();




            while (timeTable.Any())
            {

                if (!train.IsRunning() && train.Operated == true && timeTable[0].DepartureTime.TimeOfDay <= clockSim.GetDateTime().TimeOfDay)
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




        public void SaveToFile()
        {
            // Create an empty list of text lines that we will fill with strings and then write to a textfile using `WriteAllLines`.
            List<string> linesLinesToSave = new List<string>();


            foreach (var item in TrainIdSaved)
            {
                linesLinesToSave.Add(item);
            }


            File.WriteAllLines(filePath, linesLinesToSave); ;
            // For each product, we only save the code and the amount.
            // The other info (name, price, description) is already in "Products.csv" and we can look it up when we load the cart.

            Console.WriteLine("Din varukorg har sparats: ");
            Console.WriteLine();
            Console.WriteLine(ToString());
        }


        public void Load()
        {
            foreach (var item in TrainIdSaved)
            {
                Saved.Add(Schedule.GetSchedule().Find(x => x.TrainId == int.Parse(item)));
            }

            //timeTable = timeTable.Where(x => x.TrainId == train.TrainId).ToList();
            // Saved = Saved.Where(x => x.TrainId == train.TrainId).ToList();
            foreach (var item in Saved)
            {
                Console.WriteLine(item.TrainId +":"+ Train.GetTrain().Find(s => s.TrainId == item.TrainId).TrainName +":"+ item.DepartureTime.TimeOfDay+":"+ Station.GetStation().Find(s => s.StationId == item.DepStationId).StationName + ":"+ item.ArrivalTime.TimeOfDay+":"+ Station.GetStation().Find(s => s.StationId == item.ArrvStationId).StationName);
            }
            




        }
    }
}
