using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public interface ITravelPlane
    {       
        ITravelPlane AddPassengerIdFromTo(int idFrom, int idTo, int trainId);
        ITravelPlane PrintAllPassengers();
        ITravelPlane NewTrip(Train train);       
    }
}