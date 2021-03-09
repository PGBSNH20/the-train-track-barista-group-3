using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainConsole
{
    public class Station
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }
        const string FilePath = @"C:\Users\doman\OneDrive\Desktop\RailWayProject\Source\TrainConsole\Data\stations.txt";

        public Station(int stationid, string stationname,  bool endstation)
        {
            StationId = stationid;
            StationName = stationname;
            EndStation = endstation;
           
        }


        public static Station CreateFromLine(string line)
        {
            string[] parts = line.Split(',');
            Station p = new Station(int.Parse(parts[0]), parts[1], bool.Parse(parts[2]))
            {
                StationId = int.Parse(parts[0]),
                StationName = parts[1],               
                EndStation = bool.Parse(parts[2])
            };
            return p;
        }

        public static Station[] GetPassenger()
        {
            List<Station> ListOfTrains = new List<Station>();
            string[] lines = File.ReadAllLines(FilePath);

            foreach (string line in lines)
            {
                Station p = Station.CreateFromLine(line);
                ListOfTrains.Add(p);
            }
            return ListOfTrains.ToArray();
        }





    }
}
