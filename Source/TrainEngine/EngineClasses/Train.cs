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
        public IPassengerCart PassengerCart;
        
        



        const string FilePath = @"C:\Users\doman\OneDrive\Desktop\Railway\Source\TrainEngine\Data\trains.txt";

        public Train(int trainid, string trainname, int maxspeed, bool operated, IEngine iEngin, IPassengerCart ipassengerCart)
        {
            TrainId = trainid;
            TrainName = trainname;
            MaxSpeed = maxspeed;
            Operated = operated;
            this.Engine = iEngin;
            this.PassengerCart = ipassengerCart;
        }





        public static Train CreateFromLine(string line)
        {
            string[] parts = line.Split(',');
            Train p = new Train(int.Parse(parts[0]), parts[1], int.Parse(parts[2]), bool.Parse(parts[3]), new Engine(), new PassengerCart())

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
           
           // Console.WriteLine("Engine started.");
        }

        public void StopTrain()
        {
            Engine.Stop();
            //Console.WriteLine("Engine stopped.");
        }

        public bool IsRunning()
        {
            return Engine.IsRunning();
        }

        public void AddPassengers(int amount)
        {
            PassengerCart.AddPassengers(amount);

            Console.WriteLine
            (
                $"{amount} passengers embarked train.\n" +
                $"{GetPassengerAmount()} currently on train."
            );

        }

        public void RemovePassengers(int amount)
        {
            PassengerCart.RemovePassengers(amount);
            Console.WriteLine
            (
                $"{amount} passengers disembarked train.\n" +
                $"{GetPassengerAmount()} currently on train."
            );
        }

        public int GetPassengerAmount()
        {
            return PassengerCart.GetPassengerAmount();
        }
    }


}

