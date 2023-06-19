using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIServiceLibrary.Services;
using CarSimulator.Factories;
using CarSimulator.Menus;
using CarSimulator.Models;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Factories;
using DataLogicLibrary.Infrastructure.Enums;
using DataLogicLibrary.Services;
using DataLogicLibrary.Services.Interfaces;
using ValidationServiceLibrary.Services;

namespace CarSimulator.Simulation
{
    public class CarSimulation
    {
        public CarSimulation(IMenu menu, IAPIService apiService, IValidationService validationService, ISimulationLogicService simulationLogicService,
                             IMessageService messageService, ICarFactory carFactory, IDriverFactory driverFactory, IStatusFactory statusFactory)
        {
            _menu = menu;
            _apiService = apiService;
            _validationService = validationService;
            _simulationLogicService = simulationLogicService;
            _messageService = messageService;
            _carFactory = carFactory;
            _driverFactory = driverFactory;
            _statusFactory = statusFactory;
        }

        private readonly IMenu _menu;
        private readonly IAPIService _apiService;
        private readonly IValidationService _validationService;
        private readonly ISimulationLogicService _simulationLogicService;
        private readonly IMessageService _messageService;
        private readonly ICarFactory _carFactory;
        private readonly IDriverFactory _driverFactory;
        private readonly IStatusFactory _statusFactory;

        public async Task Execute()
        {
            var resultDTO = await _apiService.GetOneDriver();
            var car = _carFactory.CreateCar();
            var driver = _driverFactory.CreateDriver(resultDTO);
            var currentStatus = _statusFactory.CreateStatus();

            var userInput = 0;
            _menu.OpeningPrompt(driver);

            while (true)
            {
                Console.Clear();
                car.CardinalDirection = currentStatus.CardinalDirection;
                car.GasValue = currentStatus.GasValue;
                driver.EnergyValue = currentStatus.EnergyValue;

                _menu.StatusPrompt(car, driver);

                _messageService.DisplayCarStatusMessage(car.GasValue);
                _messageService.DisplayDriverStatusMessage(driver.EnergyValue, driver.First);
                _messageService.DisplaySelectedAction(userInput);

                _menu.DisplaySelectionMenu();
                userInput = _validationService.ValidateMenuSelection(7);

                if (userInput == 7)
                    break;

                currentStatus = _simulationLogicService.DecreaseStatusValues(userInput, currentStatus);
                currentStatus = _simulationLogicService.PerformAction(userInput, currentStatus);
            }
        }

   

    }
}
