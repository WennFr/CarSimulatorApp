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
            var car = new Car();
            var driver = new Driver();

            var status = new Status
            {
                Car = car,
                Driver = driver,

            };


            while (!exit)
            {
                Menu.DisplaySelectionMenu();

                var userInput = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                Menu.DisplaySelectedAction(userInput);



                Console.ReadKey();
            }

        }

    }
}
