using CarSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.Services.Interfaces;

namespace CarSimulator.Menus
{
    public class Menu : IMenu
    {
        public Menu(IColorService colorService, ISimulationLogicService simulationLogicService)
        {
            _colorService = colorService;
            _simulationLogicService = simulationLogicService;
        }

        private readonly IColorService _colorService;
        private readonly ISimulationLogicService _simulationLogicService;


        public void DisplaySelectionMenu()
        {
            Console.WriteLine("(1) Turn left");
            Console.WriteLine("(2) Turn right");
            Console.WriteLine("(3) Drive forward");
            Console.WriteLine("(4) Reverse");
            Console.WriteLine("(5) Take a rest");
            Console.WriteLine("(6) Refuel the car");
            Console.WriteLine($"(7) Exit {Environment.NewLine}");
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
            _simulationLogicService.ColorStatusTextBasedOnValue($"{driver.First} {driver.Last} energy: {driver.EnergyValue}/20 {Environment.NewLine}", driver.EnergyValue);

        }



    }
}
