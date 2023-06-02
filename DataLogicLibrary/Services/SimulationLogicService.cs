using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;

namespace DataLogicLibrary.Services
{
    public class SimulationLogicService
    {

        public SimulationLogicService(IDirectionContext directionContext, IDirectionStrategy turnLeftStrategy,
            IDirectionStrategy turnRightStrategy, IDirectionStrategy driveForwardStrategy,
            IDirectionStrategy reverseStrategy )
        {
            _directionContext = directionContext;
            _turnLeftStrategy = turnLeftStrategy;
            _turnRightStrategy = turnRightStrategy;
            _driveForwardStrategy = driveForwardStrategy;
            _reverseStrategy = reverseStrategy;
        }

        private readonly IDirectionContext _directionContext;
        private readonly IDirectionStrategy _turnLeftStrategy;
        private readonly IDirectionStrategy _turnRightStrategy;
        private readonly IDirectionStrategy _driveForwardStrategy;
        private readonly IDirectionStrategy _reverseStrategy;


        public StatusDTO PerformAction(int userInput, StatusDTO currentStatus)
        {
            MovementAction movementAction;

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
                    return currentStatus;
                case 6:
                    return currentStatus;
               
            }
            
            currentStatus.CardinalDirection = _directionContext.ExecuteStrategy(currentStatus.CardinalDirection, movementAction);


            return currentStatus;

        }


    }
}
