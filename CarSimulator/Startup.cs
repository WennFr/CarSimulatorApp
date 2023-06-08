using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIServiceLibrary.Services;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.Infrastructure.Enums;
using DataLogicLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using ValidationServiceLibrary.Services;

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
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IAPIService, APIService>();

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


    }
}
