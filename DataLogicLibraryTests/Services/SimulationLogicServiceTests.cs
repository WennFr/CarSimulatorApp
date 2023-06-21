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
using DataLogicLibrary.Services.Interfaces;
using Moq;
using static System.Net.Mime.MediaTypeNames;
using static DataLogicLibrary.Services.SimulationLogicService;

namespace DataLogicLibraryTests.Services
{
    [TestClass]
    public class SimulationLogicServiceTests
    {
        private SimulationLogicService _sut;
        private DirectionContext directionContext;
        private DirectionStrategyResolver directionStrategyResolver;
        private ColorService colorService;
        private readonly Mock<IHungerService> _hungerServiceMock;


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
            _hungerServiceMock = new Mock<IHungerService>();
            _sut = new SimulationLogicService(directionContext, directionStrategyResolver, colorService, _hungerServiceMock.Object);

        }

        [TestMethod]
        public void Driver_Gets_Full_After_Eating_Moq_Test()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20,
                HungerValue = 11,
                HungerStatus = HungerStatus.Starving,
            };
            var userInputEat = 8;
            var expectedHungerValue = 0;

            _hungerServiceMock.Setup(h => h.ResetHunger()).Returns(0);

            // Act
            var result = _sut.PerformAction(userInputEat, status);

            // Assert
            Assert.AreEqual(expectedHungerValue, result.HungerValue);
        }


        [TestMethod]
        public void Driver_Gets_Hungrier_After_Action_Hunger_Value_Moq_Test()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20,
                HungerValue = 5,
                HungerStatus = HungerStatus.Full
            };
            var userInputEat = 8;
            var expectedHungerValue = 7;

            _hungerServiceMock.Setup(h => h.IncreaseHunger(status.HungerValue)).Returns(status.HungerValue + 2);

            // Act
            var result = _sut.DecreaseStatusValues(userInputEat, status);

            // Assert
            Assert.AreEqual(expectedHungerValue, result.HungerValue);
        }

        [TestMethod]
        public void Driver_Gets_Hungrier_After_Action_Hunger_Status_Moq_Test()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20,
                HungerValue = 5,
                HungerStatus = HungerStatus.Full
            };
            var userInputEat = 8;
            var expectedHungerStatus = HungerStatus.Hungry;

            _hungerServiceMock.Setup(h => h.IncreaseHunger(It.IsAny<int>())).Returns((int hungerValue) => hungerValue + 2);
            _hungerServiceMock.Setup(h => h.GetHungerStatus(It.IsAny<int>())).Returns(HungerStatus.Hungry);

            // Act
            var result = _sut.DecreaseStatusValues(userInputEat, status);

            // Assert
            Assert.AreEqual(expectedHungerStatus, result.HungerStatus);
        }

        [TestMethod]
        public void Driver_Gets_Starved_After_Action_Hunger_Status_Moq_Test()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20,
                HungerValue = 14,
                HungerStatus = HungerStatus.Starving
            };
            var userInputEat = 8;
            var expectedHungerStatus = HungerStatus.Starved;

            _hungerServiceMock.Setup(h => h.IncreaseHunger(It.IsAny<int>())).Returns((int hungerValue) => hungerValue + 2);
            _hungerServiceMock.Setup(h => h.GetHungerStatus(It.IsAny<int>())).Returns(HungerStatus.Starved);

            // Act
            var result = _sut.DecreaseStatusValues(userInputEat, status);

            // Assert
            Assert.AreEqual(expectedHungerStatus, result.HungerStatus);
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
            var result = _sut.DecreaseStatusValues(userInputTurnLeft, status);

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
            var result = _sut.DecreaseStatusValues(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedEnergyValue, result.EnergyValue);
        }


        [TestMethod]
        public void Gas_Gets_Consumed_After_Decrease_Status_Values_When_Driver_Is_Not_Resting()
        {
            // Arrange
            var status = new StatusDTO()
            {
                GasValue = 20,
                EnergyValue = 20
            };
            var userInputReverse = 4;

            // Act
            var result = _sut.DecreaseStatusValues(userInputReverse, status);

            // Assert
            Assert.IsTrue(result.GasValue < 20);
        }

        [TestMethod]
        public void Gas_Does_Not_Get_Consumed_After_Decrease_Status_Values_When_Driver_Is_Resting()
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
            var result = _sut.DecreaseStatusValues(userInputRefuel, status);

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
            var result = _sut.DecreaseStatusValues(userInputDriveForward, status);

            // Assert
            Assert.AreEqual(expectedGasValue, result.GasValue);
        }




        [TestMethod]
        public void Forward_Action_CardinalDirection_Remains_North_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Left
            };
            var userInputForward = 3;

            var expectedDirection = CardinalDirection.North;

            // Act
            var result = _sut.PerformAction(userInputForward, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);

        }


        [TestMethod]
        public void No_Gas_And_Not_Refueling_Makes_Car_Stay_Still()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.East,
                GasValue = 0,
                EnergyValue = 20,
                MovementAction = MovementAction.Left
            };
            var userInputRight = 3;

            var expectedDirection = status.CardinalDirection;

            // Act
            var result = _sut.PerformAction(userInputRight, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);

        }





        [TestMethod]
        public void Forward_Action_CardinalDirection_Remains_East_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.East,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Left
            };
            var userInputForward = 3;

            var expectedDirection = CardinalDirection.East;

            // Act
            var result = _sut.PerformAction(userInputForward, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);

        }

        [TestMethod]
        public void Forward_Action_CardinalDirection_Remains_South_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Left
            };
            var userInputForward = 3;

            var expectedDirection = CardinalDirection.South;

            // Act
            var result = _sut.PerformAction(userInputForward, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);

        }

        [TestMethod]
        public void Forward_Action_CardinalDirection_Remains_West_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.West,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Left
            };
            var userInputForward = 3;

            var expectedDirection = CardinalDirection.West;

            // Act
            var result = _sut.PerformAction(userInputForward, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);

        }

        [TestMethod]
        public void Forward_Action_CardinalDirection_Changes_To_North_From_South_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward
            };
            var userInputForward = 3;

            var expectedDirection = CardinalDirection.North;

            // Act
            var result = _sut.PerformAction(userInputForward, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);

        }

        [TestMethod]
        public void Forward_Action_CardinalDirection_Changes_To_East_From_West_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.West,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward
            };
            var userInputForward = 3;

            var expectedDirection = CardinalDirection.East;

            // Act
            var result = _sut.PerformAction(userInputForward, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);

        }

        [TestMethod]
        public void Forward_Action_CardinalDirection_Changes_To_South_From_North_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward
            };
            var userInputForward = 3;

            var expectedDirection = CardinalDirection.South;

            // Act
            var result = _sut.PerformAction(userInputForward, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);

        }


        [TestMethod]
        public void Forward_Action_CardinalDirection_Changes_To_West_From_East_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.East,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward
            };
            var userInputForward = 3;

            var expectedDirection = CardinalDirection.West;

            // Act
            var result = _sut.PerformAction(userInputForward, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);

        }


        [TestMethod]
        public void Reverse_Action_CardinalDirection_Changes_To_South_From_North_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInputReverse = 4;

            var expectedDirection = CardinalDirection.South;

            // Act
            var result = _sut.PerformAction(userInputReverse, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Reverse_Action_CardinalDirection_Changes_To_West_From_East_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.East,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInputReverse = 4;

            var expectedDirection = CardinalDirection.West;

            // Act
            var result = _sut.PerformAction(userInputReverse, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Reverse_Action_CardinalDirection_Changes_To_North_From_South_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInputReverse = 4;

            var expectedDirection = CardinalDirection.North;

            // Act
            var result = _sut.PerformAction(userInputReverse, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }


        [TestMethod]
        public void Reverse_Action_CardinalDirection_Changes_To_East_From_West_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.West,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInputReverse = 4;

            var expectedDirection = CardinalDirection.East;

            // Act
            var result = _sut.PerformAction(userInputReverse, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Reverse_Action_CardinalDirection_Remains_South_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInputReverse = 4;

            var expectedDirection = CardinalDirection.South;

            // Act
            var result = _sut.PerformAction(userInputReverse, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Reverse_Action_CardinalDirection_Remains_West_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.West,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInputReverse = 4;

            var expectedDirection = CardinalDirection.West;

            // Act
            var result = _sut.PerformAction(userInputReverse, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Reverse_Action_CardinalDirection_Remains_North_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInputReverse = 4;

            var expectedDirection = CardinalDirection.North;

            // Act
            var result = _sut.PerformAction(userInputReverse, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }


        [TestMethod]
        public void Reverse_Action_CardinalDirection_Remains_East_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.East,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInputReverse = 4;

            var expectedDirection = CardinalDirection.East;

            // Act
            var result = _sut.PerformAction(userInputReverse, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }


        [TestMethod]
        public void Turn_Left_Action_CardinalDirection_Changes_To_West_From_North_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward
            };
            var userInputTurnLeft = 1;

            var expectedDirection = CardinalDirection.West;

            // Act
            var result = _sut.PerformAction(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Turn_Left_Action_CardinalDirection_Changes_To_South_From_West_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.West,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInputTurnLeft = 1;

            var expectedDirection = CardinalDirection.South;

            // Act
            var result = _sut.PerformAction(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Turn_Left_Action_CardinalDirection_Changes_To_East_From_South_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInputTurnLeft = 1;

            var expectedDirection = CardinalDirection.East;

            // Act
            var result = _sut.PerformAction(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Turn_Left_Action_CardinalDirection_Changes_To_North_From_East_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.East,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInputTurnLeft = 1;

            var expectedDirection = CardinalDirection.North;

            // Act
            var result = _sut.PerformAction(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }


        [TestMethod]
        public void Turn_Left_Action_CardinalDirection_Changes_To_West_From_South_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInputTurnLeft = 1;

            var expectedDirection = CardinalDirection.West;

            // Act
            var result = _sut.PerformAction(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Turn_Left_Action_CardinalDirection_Changes_To_North_From_West_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.West,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInputTurnLeft = 1;

            var expectedDirection = CardinalDirection.North;

            // Act
            var result = _sut.PerformAction(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }


        [TestMethod]
        public void Turn_Left_Action_CardinalDirection_Changes_To_East_From_North_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInputTurnLeft = 1;

            var expectedDirection = CardinalDirection.East;

            // Act
            var result = _sut.PerformAction(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }

        [TestMethod]
        public void Turn_Left_Action_CardinalDirection_Changes_To_South_From_East_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.East,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInputTurnLeft = 1;

            var expectedDirection = CardinalDirection.South;

            // Act
            var result = _sut.PerformAction(userInputTurnLeft, status);

            // Assert
            Assert.AreEqual(expectedDirection, result.CardinalDirection);
        }


        [TestMethod]
        public void Turn_Right_Action_CardinalDirection_Changes_To_North_From_West_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.West,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInput = 2;

            var expected = CardinalDirection.North;

            // Act
            var result = _sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }




        [TestMethod]
        public void Turn_Right_Action_CardinalDirection_Changes_To_East_From_North_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInput = 2;

            var expected = CardinalDirection.East;

            // Act
            var result = _sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }


        [TestMethod]
        public void Turn_Right_Action_CardinalDirection_Changes_To_South_From_East_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.East,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward

            };
            var userInput = 2;

            var expected = CardinalDirection.South;

            // Act
            var result = _sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }



        [TestMethod]
        public void Turn_Right_Action_CardinalDirection_Changes_To_West_From_South_When_Previous_Movement_Is_Not_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Forward
                
            };
            var userInput = 2;

            var expected = CardinalDirection.West;

            // Act
            var result = _sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }



        [TestMethod]
        public void Turn_Right_Action_CardinalDirection_Changes_To_South_From_West_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.West,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInput = 2;

            var expected = CardinalDirection.South;

            // Act
            var result = _sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }


        [TestMethod]
        public void Turn_Right_Action_CardinalDirection_Changes_To_West_From_North_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.North,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInput = 2;

            var expected = CardinalDirection.West;

            // Act
            var result = _sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }

        [TestMethod]
        public void Turn_Right_Action_CardinalDirection_Changes_To_North_From_East_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.East,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInput = 2;

            var expected = CardinalDirection.North;

            // Act
            var result = _sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);
        }


        [TestMethod]
        public void Turn_Right_Action_CardinalDirection_Changes_To_East_From_South_When_Previous_Movement_Is_Backward()
        {
            // Arrange
            var status = new StatusDTO()
            {
                CardinalDirection = CardinalDirection.South,
                GasValue = 20,
                EnergyValue = 20,
                MovementAction = MovementAction.Backward

            };
            var userInput = 2;

            var expected = CardinalDirection.East;

            // Act
            var result = _sut.PerformAction(userInput, status);

            // Assert
            Assert.AreEqual(expected, result.CardinalDirection);



        }

    }
}
