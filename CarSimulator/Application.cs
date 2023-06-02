using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CarSimulator.Infrastructure;
using CarSimulator.Simulation;

namespace CarSimulator
{
    public class Application
    {
        public void Run()
        {
            var services = new ServiceCollection();

            // Register the interface and its implementation as a transient service
            services.AddTransient<IMyInterface, MyImplementation>();


            var carSimulation = new CarSimulationController();
            carSimulation.Execute();

        }
    }
}
