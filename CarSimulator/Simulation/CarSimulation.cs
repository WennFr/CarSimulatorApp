using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIServiceLibrary.Services;
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
        public CarSimulation(IAPIService apiService, IValidationService validationService, ISimulationLogicService simulationLogicService, IColorService colorService, IMessageService messageService)
        {
            _apiService = apiService;
            _validationService = validationService;
            _simulationLogicService = simulationLogicService;
            _colorService = colorService;
            _messageService = messageService;
        }

        private readonly IAPIService _apiService;
        private readonly IValidationService _validationService;
        private readonly ISimulationLogicService _simulationLogicService;
        private readonly IColorService _colorService;
        private readonly IMessageService _messageService;

        public void Execute()
        {
            var resultDTO = _apiService.GetOneDriver();

            var car = new Car();
            var driver = new Driver();
            var currentStatus = new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Forward,
                GasValue = 20,
                EnergyValue = 20
            };



            var userInput = 0;

            while (true)
            {
                Console.Clear();
                car.CardinalDirection = currentStatus.CardinalDirection;
                car.GasValue = currentStatus.GasValue;
                driver.EnergyValue = currentStatus.EnergyValue;
                StatusPrompt(car, driver);

                _messageService.DisplayCarStatusMessage(car.GasValue);
                _messageService.DisplayDriverStatusMessage(driver.EnergyValue);
                _messageService.DisplaySelectedAction(userInput);

                Menu.DisplaySelectionMenu();
                userInput = _validationService.ValidateMenuSelection(7);

                if (userInput == 7)
                    break;

                currentStatus = _simulationLogicService.UpdateStatusValues(userInput, currentStatus);
                currentStatus = _simulationLogicService.PerformAction(userInput, currentStatus);
            }
        }


        public void StatusPrompt(Car car, Driver driver)
        {

            _colorService.ConsoleWriteLineWhite($"Direction: {car.CardinalDirection}");
            _simulationLogicService.ColorStatusTextBasedOnValue($"Gas: {car.GasValue}/20", car.GasValue);
            _simulationLogicService.ColorStatusTextBasedOnValue($"Drivers energy: {driver.EnergyValue}/20 {Environment.NewLine}", driver.EnergyValue);

        }

    }
}
