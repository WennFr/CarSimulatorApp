using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CarSimulator.Infrastructure;
using CarSimulator.Simulation;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using ValidationServiceLibrary.Services;

namespace CarSimulator
{
    public class Application
    {
        public void Run()
        {
            var services = new ServiceCollection();
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient<ISimulationLogicService, SimulationLogicService>();
        



            var serviceProvider = services.BuildServiceProvider();
            var validationService = serviceProvider.GetService<IValidationService>();
            var simulationLogicService = serviceProvider.GetService<ISimulationLogicService>();


            var carSimulation = new CarSimulation(validationService, simulationLogicService);
            carSimulation.Execute();

        }
    }
}
