using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIServiceLibrary.Services;
using CarSimulator.Factories;
using CarSimulator.Menus;
using CarSimulator.Simulation;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.Factories;
using DataLogicLibrary.Infrastructure.Enums;
using DataLogicLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using ValidationServiceLibrary.Services;
using DataLogicLibrary.Services.Interfaces;
using Moq;

namespace CarSimulator
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient<ISimulationLogicService, SimulationLogicService>();
            services.AddTransient<IDirectionContext, DirectionContext>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IMenu, Menu>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IAPIService, APIService>();
            services.AddTransient<ICarFactory, CarFactory>();
            services.AddTransient<IDriverFactory, DriverFactory>();
            services.AddTransient<IStatusFactory, StatusFactory>();
            services.AddTransient<IHungerService>(provider => Mock.Of<IHungerService>());
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

        }

        public CarSimulation GetServices(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var menu = serviceProvider.GetService<IMenu>();
            var apiService = serviceProvider.GetService<IAPIService>();
            var validationService = serviceProvider.GetService<IValidationService>();
            var simulationLogicService = serviceProvider.GetService<ISimulationLogicService>();
            var colorService = serviceProvider.GetService<IColorService>();
            var messageService = serviceProvider.GetService<IMessageService>();
            var carService = serviceProvider.GetService<ICarFactory>();
            var driverService = serviceProvider.GetService<IDriverFactory>();
            var statusService = serviceProvider.GetService<IStatusFactory>();

            return new CarSimulation(menu, apiService, validationService, simulationLogicService, colorService, messageService, carService, driverService, statusService);
        }

    }
}
