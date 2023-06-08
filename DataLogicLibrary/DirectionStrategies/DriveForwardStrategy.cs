using DataLogicLibrary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.DTO;

namespace DataLogicLibrary.DirectionStrategies
{
    public class DriveForwardStrategy : IDirectionStrategy
    {

        public StatusDTO Execute(StatusDTO currentStatus)
        {
            CardinalDirection newDirection;

            if (currentStatus.MovementAction != MovementAction.Backward)
            {
                 newDirection = currentStatus.CardinalDirection;
            }
            else
            {
                switch (currentStatus.CardinalDirection)
                {
                    case CardinalDirection.North:
                        newDirection = CardinalDirection.South;
                        break;
                    case CardinalDirection.South:
                        newDirection = CardinalDirection.North;
                        break;
                    case CardinalDirection.East:
                        newDirection = CardinalDirection.West;
                        break;
                    case CardinalDirection.West:
                        newDirection = CardinalDirection.East;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(currentStatus.CardinalDirection), "Error: currentCardinalDirection not set");
                }
            }

            currentStatus.CardinalDirection = newDirection;
            currentStatus.MovementAction = MovementAction.Forward;
            return currentStatus;
        }

    }
}
