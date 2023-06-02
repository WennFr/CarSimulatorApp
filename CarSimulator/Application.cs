using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator.Infrastructure;

namespace CarSimulator
{
    public class Application
    {
        public void Run()
        {
            var carSimulatorLoop = new CarSimulatorLoop();
            carSimulatorLoop.Start();

        }
    }
}
