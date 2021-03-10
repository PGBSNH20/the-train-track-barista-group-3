using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    class PassengerCart : IPassengerCart
    {
        private int passengerAmount;


        public PassengerCart(int passengers=0)
        {
            if (passengers<0)
            {
                passengerAmount = 0;
            }
            else
            {
                passengerAmount = passengers;
            }
        }

        public void AddPassengers(int amount)
        {
            passengerAmount += amount;
        }

        

        public void RemovePassengers(int amount)
        {
            if (passengerAmount-amount<0)
            {
                passengerAmount = 0;
            }
            else
            {
                passengerAmount -= amount;
            }
        }

        public int GetPassengerAmount()
        {
            return passengerAmount;
        }
    }
}
