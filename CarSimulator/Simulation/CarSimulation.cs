using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator.Infrastructure.Menus;
using CarSimulator.Models;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;
using DataLogicLibrary.Services;
using ValidationServiceLibrary.Services;

namespace CarSimulator.Simulation
{
    public class CarSimulation
    {
        public CarSimulation(IValidationService validationService, ISimulationLogicService simulationLogicService)
        {
            _validationService = validationService;
            _simulationLogicService = simulationLogicService;
        }

        private readonly IValidationService _validationService;
        private readonly ISimulationLogicService _simulationLogicService;

        public void Execute()
        {
            var car = new Car();
            var driver = new Driver();
            var currentStatus = new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20
            };

            while (true)
            {
                Console.Clear();
                Menu.DisplaySelectionMenu();
                var userInput = _validationService.ValidateMenuSelection(7);

                Menu.DisplaySelectedAction(userInput);

                if (userInput == 7)
                    break;

                currentStatus = _simulationLogicService.PerformAction(userInput, currentStatus);

                car.CardinalDirection = currentStatus.CardinalDirection;
                car.GasValue = currentStatus.GasValue;
                driver.EnergyValue = currentStatus.EnergyValue;


                Console.WriteLine($"Direction: {car.CardinalDirection}");
                Console.WriteLine($"Gas: {car.GasValue}/20");
                Console.WriteLine($"Drivers energy:{driver.EnergyValue}/20");

                Console.ReadLine();

            }

        }

    }
}
