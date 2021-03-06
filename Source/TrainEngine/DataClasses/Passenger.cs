using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainEngine
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        const string FilePath = @"C:\Users\doman\OneDrive\Desktop\RailwayPro\Source\TrainEngine\Data\passengers.txt";
        

        public static Passenger CreateFromLine(string line)
        {
            string[] parts = line.Split(',',':',' ');
            Passenger p = new Passenger(/*int.Parse(parts[0]), parts[1], parts[2]*/)
            {
                PassengerId = int.Parse(parts[0]),
                FirstName = parts[1],
                LastName = parts[2],              
            };
            return p;
        }

        public static List<Passenger> GetPassenger()
        {
            List<Passenger> ListOfPassengers = new List<Passenger>();
             string[] lines = File.ReadAllLines(FilePath);
            
            foreach (string line in lines)
            {
                Passenger p = Passenger.CreateFromLine(line);
                ListOfPassengers.Add(p);
            }
            return ListOfPassengers;
        }



        
        



    }
}
