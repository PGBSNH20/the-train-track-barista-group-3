using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public interface ITravelPlane
    {       
       
        ITravelPlane NewTrip(Train train);       
    }
}