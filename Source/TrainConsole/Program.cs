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
            // Console.WriteLine("Train track!");
            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

            // Step 2:
            // Make the trains run in treads


            // List<Train> train = Train.GetTrain();



            // Console.WriteLine(dt.ToShortTimeString());

            //ClockSimulator sim = new ClockSimulator(100, 60);
            // sim.StartClock();


            //TravelPlane plane = new TravelPlane();


            //plane.OperateTrain(train[2]);

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Hello" +i);
            //    Thread.Sleep(500);
            //}




            // TravelPlane a = new TravelPlane().NewTrip(train1[1]).Start().
           
            ClockSimulator sim = new ClockSimulator(100, 60);
            sim.StartClock();
            TravelPlane travel1 = new TravelPlane();
            TravelPlane travel2 = new TravelPlane();

            List<Train> train1 = Train.GetTrain();
            List<Train> train2 = Train.GetTrain();

            //travel1.AddAllPassengerTo(2);
            //travel1. OperateTrain(train1[1]);
            //travel1.PrintAllPassengers();
            //travel2.OperateTrain(train2[0]);


            //DateTime dt = DateTime.Now;

            // dt.TimeOfDay;

            travel1.NewTrip(train1[1]).PrintAllPassengers();
           






            Console.ReadKey();
        }
    }
}
