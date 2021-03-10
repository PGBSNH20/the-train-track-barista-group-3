using System;
using TrainEngine;

namespace TrainConsole
{

    
    class Program
    {
        

        static void Main(string[] args)
        {
            // Console.WriteLine("Train track!");
            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

            // Step 2:
            // Make the trains run in treads

            //string timee = "null";
            //TimeSpan time = TimeSpan.Parse(timee);

            DateTime dt = DateTime.Now;

           

           
           // Console.WriteLine(dt.ToShortTimeString());

            ClockSimulator a = new ClockSimulator(1000,600);

            a.SetTime("");
            a.StartClock();
            a.RunClock();
            a.PrintClock();
           
            
            


            Console.ReadKey();
        }
    }
}
