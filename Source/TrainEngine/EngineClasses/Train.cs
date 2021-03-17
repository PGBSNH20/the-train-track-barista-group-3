using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainEngine
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public int MaxSpeed { get; set; }
        public bool Operated { get; set; }

        public IEngine Engine;
       
        
        



        const string FilePath = @"C:\Users\doman\OneDrive\Desktop\RailwayPro\Source\TrainEngine\Data\trains.txt";

        public Train(int trainid, string trainname, int maxspeed, bool operated, IEngine iEngin)
        {
            TrainId = trainid;
            TrainName = trainname;
            MaxSpeed = maxspeed;
            Operated = operated;
            this.Engine = iEngin;
           
        }





        public static Train CreateFromLine(string line)
        {
            string[] parts = line.Split(',');
            Train p = new Train(int.Parse(parts[0]), parts[1], int.Parse(parts[2]), bool.Parse(parts[3]), new Engine())

            {
                TrainId = int.Parse(parts[0]),
                TrainName = parts[1],
                MaxSpeed = int.Parse(parts[2]),
                Operated = bool.Parse(parts[3]),

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


        public void StartTrain()
        {           
                Engine.Start();            
        }

        public void StopTrain()
        {
            Engine.Stop();            
        }

        public bool IsRunning()
        {
            return Engine.IsRunning();
        }

       

        
    }


}

