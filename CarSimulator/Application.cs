using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using APIServiceLibrary.Services;
using CarSimulator.Infrastructure;
using CarSimulator.Simulation;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using ValidationServiceLibrary.Services;
using DataLogicLibrary.Infrastructure.Enums;

namespace CarSimulator
{
    public class Application
    {

        public void Run()
        {
            var services = new ServiceCollection();
            var startup = new Startup();

            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var apiService = serviceProvider.GetService<IAPIService>();
            var validationService = serviceProvider.GetService<IValidationService>();
            var simulationLogicService = serviceProvider.GetService<ISimulationLogicService>();
            var colorService = serviceProvider.GetService<IColorService>();
            var messageService = serviceProvider.GetService<IMessageService>();

            var carSimulation = new CarSimulation(apiService, validationService, simulationLogicService, colorService, messageService);
            carSimulation.Execute();


        }
    }
}
