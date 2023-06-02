using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator.Infrastructure;
using CarSimulator.Simulation;

namespace CarSimulator
{
    public class Application
    {
        public void Run()
        {



            var carSimulation = new CarSimulationController();
            carSimulation.Execute();

        }
    }
}
