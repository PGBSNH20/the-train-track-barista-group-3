using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public interface IEngine
    {

        void Start();
        void Stop();
        bool IsRunning();



    }
}
