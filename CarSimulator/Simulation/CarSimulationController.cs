using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator.Infrastructure.Menus;
using CarSimulator.Models;

namespace CarSimulator.Simulation
{
    public class CarSimulationController
    {

        public void Execute()
        {
            var exit = false;

            while (!exit)
            {
                Menu.DisplaySelectionMenu();

                var status = new Status();



                Console.WriteLine(status.Car.GasValue);

                Console.ReadKey();
            }

        }

    }
}
