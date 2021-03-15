using System;
using TrainEngine;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace TrainConsole
{

    
    class Program
    {
        
        
        static void Main(string[] args)
        {
                      
            ClockSimulator sim = new ClockSimulator(100, 60);
            sim.StartClock();
            TravelPlane travel1 = new TravelPlane();           
            List<Train> train1 = Train.GetTrain();          
            travel1.NewTrip(train1[1]);
            travel1.NewTrip(train1[2]);
            travel1.SaveToFile();
            travel1.Load();

            Console.ReadKey();
        }
    }
}
