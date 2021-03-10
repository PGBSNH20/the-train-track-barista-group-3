using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainConsole
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        const string FilePath = @"C:\Users\doman\OneDrive\Desktop\RailWayProject\Source\TrainConsole\Data\passengers.txt";

        public Passenger(int passengerid, string firstname, string lastname)
        {
            PassengerId = passengerid;
            FirstName = firstname;
            LastName = lastname;
        }


       
        public static Passenger CreateFromLine(string line)
        {

            string[] parts = line.Split(',',':',' ');
            Passenger p = new Passenger(int.Parse(parts[0]), parts[1], parts[2])
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

        //public void Print()
        //{
        //    foreach (var item in Passenger.GetPassenger())
        //    {
        //        Console.WriteLine(item.PassengerId + ":" + item.FirstName + ":" + item.LastName);
        //    }
        //}

    }
}
