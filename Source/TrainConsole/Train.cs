using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainConsole
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public double MaxSpeed { get; set; }
        public bool Operated { get; set; }

        const string FilePath = @"C:\Users\doman\OneDrive\Desktop\RailWayProject\Source\TrainConsole\Data\trains.txt";

        public Train(int trainid, string trainname, int maxspeed, bool operated)
        {
            TrainId = trainid;
            TrainName = trainname;
            MaxSpeed = maxspeed;
            Operated = operated;
        }



        public static Train CreateFromLine(string line)
        {
            string[] parts = line.Split(',');
            Train p = new Train(int.Parse(parts[0]), parts[1], int.Parse(parts[2]), bool.Parse(parts[3]))
            {
                TrainId = int.Parse(parts[0]),
                TrainName = parts[1],
                MaxSpeed = int.Parse(parts[2]),
                Operated=bool.Parse(parts[3])
            };
            return p;
        }

        public static List<Train> GetTrain()
        {
            List<Train> ListOfTrains = new List<Train>();
            string[] lines = File.ReadAllLines(FilePath);

            foreach (string line in lines)
            {
                Train p = Train.CreateFromLine(line);
                ListOfTrains.Add(p);
            }
            return ListOfTrains;
        }

        //public void Print()
        //{
        //    foreach (var item in Train.GetPassenger())
        //    {
        //        Console.WriteLine(item.TrainName);
        //    }
        //}


    }
}
