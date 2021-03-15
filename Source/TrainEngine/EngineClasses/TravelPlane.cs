﻿using System;
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

        private List<Passenger> passengerList = new List<Passenger>();
        private List<Passenger> allPassengers = Passenger.GetPassenger();
        private List<Schedule> Save = new List<Schedule>();
        private List<Cart> Loaded = Cart.GetLoadedSchedule();
        private Cart CartToSave = new Cart();
        public bool Done = false;
       
       
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
            foreach (var item in  passengerList)
            {
                Console.WriteLine(item.PassengerId + ":" + item.LastName);

            }
           
        }

        public ITravelPlane NewTrip(Train train)
        {
            
            Thread trainThr = new Thread(() => Start(train, timeTable, clockSim));
            trainThr.Start();
            return this;
           
        }

        public void Start(Train train, List<Schedule> timeTable, ClockSimulator clockSim)
        {
            timeTable = timeTable.Where(x => x.TrainId == train.TrainId).ToList();
            foreach (var item in timeTable)
            {
                Save.Add(item);
                
            }           
            
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
            Done = true;
        }


        public void SaveToFile()
        {
            while (Done==false)
            {
                CartToSave.SaveToFile(Save);
                
            }
           
        }
        public void Load( )
        {         
                CartToSave.Load(Loaded);                        
        }

    }
}
