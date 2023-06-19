using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIServiceLibrary.Services;
using CarSimulator.Factories;
using CarSimulator.Infrastructure.Menus;
using CarSimulator.Models;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;
using DataLogicLibrary.Services;
using DataLogicLibrary.Services.Interfaces;
using ValidationServiceLibrary.Services;

namespace CarSimulator.Simulation
{
    public class CarSimulation
    {
        public CarSimulation(IAPIService apiService, IValidationService validationService, ISimulationLogicService simulationLogicService,
                             IColorService colorService, IMessageService messageService, ICarFactory carFactory, IDriverFactory driverFactory)
        {
            _apiService = apiService;
            _validationService = validationService;
            _simulationLogicService = simulationLogicService;
            _colorService = colorService;
            _messageService = messageService;
            _carFactory = carFactory;
            _driverFactory = driverFactory;
        }

        private readonly IAPIService _apiService;
        private readonly IValidationService _validationService;
        private readonly ISimulationLogicService _simulationLogicService;
        private readonly IColorService _colorService;
        private readonly IMessageService _messageService;
        private readonly ICarFactory _carFactory;
        private readonly IDriverFactory _driverFactory;

        public async Task Execute()
        {
            var resultDTO = await _apiService.GetOneDriver();

            var car = _carFactory.CreateCar();
            var driver = _driverFactory.
            var currentStatus = new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Forward,
                GasValue = 20,
                EnergyValue = 20
            };

            var userInput = 0;

            OpeningPrompt(driver);

            while (true)
            {
                Console.Clear();
                car.CardinalDirection = currentStatus.CardinalDirection;
                car.GasValue = currentStatus.GasValue;
                driver.EnergyValue = currentStatus.EnergyValue;
                StatusPrompt(car, driver);

                _messageService.DisplayCarStatusMessage(car.GasValue);
                _messageService.DisplayDriverStatusMessage(driver.EnergyValue, driver.First);
                _messageService.DisplaySelectedAction(userInput);

                Menu.DisplaySelectionMenu();
                userInput = _validationService.ValidateMenuSelection(7);

                if (userInput == 7)
                    break;

                currentStatus = _simulationLogicService.DecreaseStatusValues(userInput, currentStatus);
                currentStatus = _simulationLogicService.PerformAction(userInput, currentStatus);
            }
        }

        public void OpeningPrompt(Driver driver)
        {
            _colorService.ConsoleWriteLineWhite($"Car Simulator! {Environment.NewLine}");
            _colorService.ConsoleWriteLineCyan($"Your driver: {driver.Title} {driver.First} {driver.Last} {Environment.NewLine}");
            _colorService.ConsoleWriteLineCyan($"City: {driver.City} {Environment.NewLine}");
            _colorService.ConsoleWriteLineCyan($"Country: {driver.Country} {Environment.NewLine}");

            _colorService.ConsoleWriteLineDarkCyan("Press enter to start!");
            Console.ReadKey();
        }

        public void StatusPrompt(Car car, Driver driver)
        {

            _colorService.ConsoleWriteLineWhite($"Direction: {car.CardinalDirection}");
            _simulationLogicService.ColorStatusTextBasedOnValue($"Gas: {car.GasValue}/20", car.GasValue);
            _simulationLogicService.ColorStatusTextBasedOnValue($"{driver.First} {driver.Last}'s energy: {driver.EnergyValue}/20 {Environment.NewLine}", driver.EnergyValue);

        }

    }
}
