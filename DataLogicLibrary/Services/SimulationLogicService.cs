using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;

namespace DataLogicLibrary.Services
{
    public class SimulationLogicService : ISimulationLogicService
    {
        public delegate IDirectionStrategy DirectionStrategyResolver(MovementAction movementAction);

        public SimulationLogicService(IDirectionContext directionContext, DirectionStrategyResolver directionStrategyResolver)
        {
            _directionContext = directionContext;
            _turnLeftStrategy = directionStrategyResolver(MovementAction.Left);
            _turnRightStrategy = directionStrategyResolver(MovementAction.Right);
            _driveForwardStrategy = directionStrategyResolver(MovementAction.Forward);
            _reverseStrategy = directionStrategyResolver(MovementAction.Backward);
        }

        private readonly IDirectionContext _directionContext;
        private readonly IDirectionStrategy _turnLeftStrategy;
        private readonly IDirectionStrategy _turnRightStrategy;
        private readonly IDirectionStrategy _driveForwardStrategy;
        private readonly IDirectionStrategy _reverseStrategy;


        public StatusDTO PerformAction(int userInput, StatusDTO currentStatus)
        {
            MovementAction movementAction = 0;

            switch (userInput)
            {
                case 1:
                    _directionContext.SetStrategy(_turnLeftStrategy);
                    movementAction = MovementAction.Left;
                    break;

                case 2:
                    _directionContext.SetStrategy(_turnRightStrategy);
                    movementAction = MovementAction.Right;
                    break;

                case 3:
                    _directionContext.SetStrategy(_driveForwardStrategy);
                    movementAction = MovementAction.Forward;
                    break;

                case 4:
                    _directionContext.SetStrategy(_reverseStrategy);
                    movementAction = MovementAction.Backward;
                    break;

                case 5:
                    currentStatus.EnergyValue = 20;
                    return currentStatus;
                case 6:
                    currentStatus.GasValue = 20;
                    return currentStatus;

            }

            currentStatus.CardinalDirection = _directionContext.ExecuteStrategy(currentStatus.CardinalDirection, movementAction);

            return currentStatus;

        }

        public StatusDTO UpdateStatusValues(int userInput, StatusDTO currentStatus)
        {
           
                Random random = new Random();
                int energyDecrease = random.Next(1, 6);
                int gasDecrease = random.Next(1, 6);

                currentStatus.EnergyValue -= energyDecrease;
                if (userInput != 5)
                    currentStatus.GasValue -= gasDecrease;


                if (currentStatus.EnergyValue < 0)
                    currentStatus.EnergyValue = 0;
                if (currentStatus.GasValue < 0)
                    currentStatus.GasValue = 0;

            return currentStatus;

        }



    }
}
