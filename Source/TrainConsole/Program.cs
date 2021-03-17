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
                      
            ClockSimulator sim = new ClockSimulator(100,60);
            sim.StartClock();
            TravelPlane travel = new TravelPlane();           
            List<Train> train1 = Train.GetTrain();
            travel.NewTrip(train1[1]);
            travel.NewTrip(train1[2]);
            
           






            Console.ReadKey();
        }
    }
}
