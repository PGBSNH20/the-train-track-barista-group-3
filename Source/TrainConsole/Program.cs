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
                      
           
            TravelPlane travel = new TravelPlane();           
            List<Train> train1 = Train.GetTrain();
           // travel.NewTrip(train1[1]);
           //travel.NewTrip(train1[2]);
           // travel.Save();
            travel.Load();
            
            Console.ReadKey();
        }
    }
}
