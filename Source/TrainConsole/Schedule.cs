using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainConsole
{
    public class Schedule
    {
        public int TrainId { get; set; }
        public int DepStationId { get; set; }
        public string DepartureTime { get; set; }
        public int ArrvStationId { get; set; }
        public string ArrivalTime { get; set; }
        


        const string FilePath = @"C:\Users\doman\OneDrive\Desktop\RailWayProject\Source\TrainConsole\Data\timetable.txt";

        public Schedule(int trainid,int depstationid,string departuretime, int arrStationId,string arrivaltime)
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
            Schedule p = new Schedule(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], int.Parse(parts[3]), parts[4])
            {
                TrainId = int.Parse(parts[0]),
                DepStationId = int.Parse(parts[1]),
                DepartureTime = parts[2],
                ArrvStationId= int.Parse(parts[3]),
                ArrivalTime = parts[4]
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
