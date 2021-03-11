using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public interface ITravelPlane
    {
        //void OperateTrain(Train train);
        //void Start(Train train, List<Schedule> timeTable, ClockSimulator clockSim);

        ITravelPlane AddPassengerIdFromTo(int idFrom, int idTo, int trainId);
        ITravelPlane PrintAllPassengers();

        ITravelPlane NewTrip(Train train);


        //ITravelPlane Start(Train train, List<Schedule> timeTable, ClockSimulator clockSim);
        




    }
}