using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using APIServiceLibrary.Services;
using CarSimulator.Factories;
using CarSimulator.Infrastructure;
using CarSimulator.Simulation;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.Factories;
using Microsoft.Extensions.DependencyInjection;
using ValidationServiceLibrary.Services;
using DataLogicLibrary.Infrastructure.Enums;
using DataLogicLibrary.Services;
using DataLogicLibrary.Services.Interfaces;

namespace CarSimulator
{
    public class Application
    {

        public async Task Run()
        {
            var startup = new Startup();
            var services = new ServiceCollection();

            startup.ConfigureServices(services);
            var carSimulation = startup.GetServices(services);
            await carSimulation.Execute();


        }
    }
}
