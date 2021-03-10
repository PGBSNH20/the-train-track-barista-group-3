using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    interface IPassengerCart
    {
        void AddPassengers(int amount);
        void RemovePassengers(int amount);
        int GetPassengerAmount();
    }
}
