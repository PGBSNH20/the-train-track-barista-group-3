using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainEngine
{
    public class Schedule
    {
        public int TrainId { get; set; }
        public int DepStationId { get; set; }
        public DateTime DepartureTime { get; set; }
        public int ArrvStationId { get; set; }
        public DateTime ArrivalTime { get; set; }
        


        const string FilePath = @"C:\Users\doman\OneDrive\Desktop\RailwayPro\Source\TrainEngine\Data\timetable.txt";

        public Schedule(int trainid,int depstationid, DateTime departuretime, int arrStationId, DateTime arrivaltime)
        {
            TrainId = trainid;
            DepStationId = depstationid;           
            DepartureTime = departuretime;
            ArrvStationId = arrStationId;
            ArrivalTime = arrivaltime;
            
        }

        public static Schedule CreateFromLine(string line)
        {
            string[] parts = line.Split(',');
            Schedule p = new Schedule(int.Parse(parts[0]), int.Parse(parts[1]), new DateTime(), int.Parse(parts[3]), new DateTime())
            {
                TrainId = int.Parse(parts[0]),
                DepStationId = int.Parse(parts[1]),
                DepartureTime = DateTime.Parse(parts[2]),
                ArrvStationId = int.Parse(parts[3]),
                ArrivalTime = DateTime.Parse(parts[4])
            };
            return p;
        }

        public static List<Schedule> GetSchedule()
        {
            List<Schedule> ListOfTrains = new List<Schedule>();
            string[] lines = File.ReadAllLines(FilePath);

            foreach (string line in lines)
            {
                Schedule p = Schedule.CreateFromLine(line);
                ListOfTrains.Add(p);
            }
            return ListOfTrains;
        }
    }
}
