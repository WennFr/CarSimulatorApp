﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator.Infrastructure.Menus;
using CarSimulator.Models;
using ValidationServiceLibrary.Services;

namespace CarSimulator.Simulation
{
    public class CarSimulation
    {
        public CarSimulation(IValidationService validationService)
        {
            _validationService = validationService;
        }

        private readonly IValidationService _validationService;


        public void Execute()
        {
            var car = new Car();
            var driver = new Driver();

            var status = new Status
            {
                Car = car,
                Driver = driver,
            };


            while (true)
            {
                Console.Clear();
                Menu.DisplaySelectionMenu();

                var userInput = _validationService.ValidateMenuSelection(7);


                Menu.DisplaySelectedAction(userInput);

                if (userInput == 7)
                    break;

                Console.WriteLine(Convert.ToString(status.Car.Direction));
                Console.WriteLine(Convert.ToString(status.Driver.EnergyValue));
                Console.WriteLine(Convert.ToString(status.Car.GasValue));

                Console.ReadLine();

            }

        }

    }
}
