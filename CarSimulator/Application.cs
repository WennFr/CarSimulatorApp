using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CarSimulator.Infrastructure;
using CarSimulator.Simulation;
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
            var serviceProvider = services.BuildServiceProvider();
            var validationService = serviceProvider.GetService<IValidationService>();

            var carSimulation = new CarSimulation(validationService);
            carSimulation.Execute();

        }
    }
}
