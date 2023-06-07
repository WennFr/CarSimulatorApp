using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DirectionStrategies;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;
using DataLogicLibrary.Services;
using static System.Net.Mime.MediaTypeNames;
using static DataLogicLibrary.Services.SimulationLogicService;

namespace DataLogicLibraryTests.Services
{
    [TestClass]
    public class SimulationLogicServiceTests
    {
        private SimulationLogicService sut;
        private DirectionContext directionContext;
        private DirectionStrategyResolver directionStrategyResolver;
        private ColorService colorService;

        public SimulationLogicServiceTests()
        {
            directionContext = new DirectionContext();
            directionStrategyResolver = movementAction =>
            { 
                switch (movementAction)
                {
                    case MovementAction.Left:
                        return new TurnLeftStrategy();  
                    case MovementAction.Right:
                        return new TurnRightStrategy();  
                    case MovementAction.Forward:
                        return new DriveForwardStrategy(); 
                    case MovementAction.Backward:
                        return new ReverseStrategy();  
                    default:
                        throw new KeyNotFoundException();
                }
            };
            colorService = new ColorService();
            sut = new SimulationLogicService(directionContext, directionStrategyResolver, colorService);
        }

        [TestMethod]
        public void Driver_Gets_Tired_After_Update_Status_Values()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20
            };
            var userInput = 1;

            // Act
            var result = sut.UpdateStatusValues(userInput, status);

            // Assert
            Assert.IsTrue(result.EnergyValue < 20);
        }

        [TestMethod]
        public void Gas_Gets_Consumed_After_Update_Status_Values_And_User_Is_Not_Refueling()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20
            };
            var userInput = 4;

            // Act
            var result = sut.UpdateStatusValues(userInput, status);

            // Assert
            Assert.IsTrue(result.GasValue < 20);
        }


    }
}
