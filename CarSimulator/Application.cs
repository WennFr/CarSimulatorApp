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
using DataLogicLibrary.Infrastructure.Enums;

namespace CarSimulator
{
    public class Application
    {

        public void Run()
        {
            var services = new ServiceCollection();
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient<ISimulationLogicService, SimulationLogicService>();
            services.AddTransient<IDirectionContext, DirectionContext>();

            services.AddTransient<TurnLeftStrategy>();
            services.AddTransient<TurnRightStrategy>();
            services.AddTransient<DriveForwardStrategy>();
            services.AddTransient<ReverseStrategy>();

            services.AddTransient<SimulationLogicService.DirectionStrategyResolver>(serviceProvider => movementAction =>
            {
                switch (movementAction)
                {
                    case MovementAction.Left:
                        return serviceProvider.GetService<TurnLeftStrategy>();
                    case MovementAction.Right:
                        return serviceProvider.GetService<TurnRightStrategy>();
                    case MovementAction.Forward:
                        return serviceProvider.GetService<DriveForwardStrategy>();
                    case MovementAction.Backward:
                        return serviceProvider.GetService<ReverseStrategy>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            var serviceProvider = services.BuildServiceProvider();
            var validationService = serviceProvider.GetService<IValidationService>();
            var simulationLogicService = serviceProvider.GetService<ISimulationLogicService>();

            var carSimulation = new CarSimulation(validationService, simulationLogicService);
            carSimulation.Execute();


        }
    }
}
