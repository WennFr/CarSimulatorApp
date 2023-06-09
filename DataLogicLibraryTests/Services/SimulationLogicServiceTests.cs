﻿using System;
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
        public void Driver_Gets_Tired_After_Decrease_Status_Values()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20
            };
            var userInputTurnLeft = 1;

            // Act
            var result = sut.DecreaseStatusValues(userInputTurnLeft, status);

            // Assert
            Assert.IsTrue(result.EnergyValue < 20);
        }

        [TestMethod]
        public void Driver_Energy_Value_Does_Not_Go_Below_Zero_After_Decrease_Status_Values()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 0
            };
            var userInputTurnLeft = 1;
            var expectedEnergyValue = 0;


            // Act
            var result = sut.DecreaseStatusValues(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedEnergyValue, result.EnergyValue);
        }


        [TestMethod]
        public void Gas_Gets_Consumed_After_Decrease_Status_Values_And_Driver_Is_Not_Resting()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20
            };
            var userInputReverse = 4;

            // Act
            var result = sut.DecreaseStatusValues(userInputReverse, status);

            // Assert
            Assert.IsTrue(result.GasValue < 20);
        }

        [TestMethod]
        public void Gas_Does_Not_Get_Consumed_After_Decrease_Status_Values_And_Driver_Is_Resting()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20
            };
            var userInputRefuel = 5;
            var expectedGasValue = 20;

            // Act
            var result = sut.DecreaseStatusValues(userInputRefuel, status);

            // Assert
            Assert.AreEqual(expectedGasValue, result.GasValue);

        }

        [TestMethod]
        public void Gas_Value_Does_Not_Go_Below_Zero_After_Decrease_Status_Values()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 0,
                EnergyValue = 20
            };
            var userInputDriveForward = 3;
            var expectedGasValue = 0;


            // Act
            var result = sut.DecreaseStatusValues(userInputDriveForward, status);

            // Assert
            Assert.AreEqual(expectedGasValue, result.GasValue);
        }




        [TestMethod]
        public void CardinalDirection_Remains_Same_When_Driving_Forward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20
            };
            var userInput = 3;

            var expected = CardinalDirection.South;

            // Act
            var result = sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);

        }

        [TestMethod]
        public void CardinalDirection_Changes_To_East_When_Turning_Left_From_South()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20
            };
            var userInput = 1;

            var expected = CardinalDirection.East;

            // Act
            var result = sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }


        [TestMethod]
        public void CardinalDirection_Changes_To_West_When_Turning_Right_From_South()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20
            };
            var userInput = 2;

            var expected = CardinalDirection.West;

            // Act
            var result = sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }

        [TestMethod]
        public void CardinalDirection_Changes_To_South_When_Reversing_From_North()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20
            };
            var userInput = 4;

            var expected = CardinalDirection.South;

            // Act
            var result = sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }
    }
}
