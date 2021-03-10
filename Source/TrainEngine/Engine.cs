using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    class Engine : IEngine
    {
        private bool isRunning;

        public Engine()
        {
            isRunning = false;
        }

        public void Start()
        {
            isRunning = true;
        }

        public void Stop()
        {
            isRunning = false;
        }

        public bool IsRunning()
        {
            return isRunning;
        }
    }
}
