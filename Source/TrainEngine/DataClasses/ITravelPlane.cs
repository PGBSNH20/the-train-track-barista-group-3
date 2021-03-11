using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public interface ITravelPlane
    {
        //void OperateTrain(Train train);
        //void Start(Train train, List<Schedule> timeTable, ClockSimulator clockSim);

        ITravelPlane NewTrip(Train train);

        //ITravelPlane Start(Train train, List<Schedule> timeTable, ClockSimulator clockSim);
        ITravelPlane StopWhenDone(Train train, List<Schedule> timeTable, ClockSimulator clockSim);

        TravelPlane TravelPlane();




    }
}