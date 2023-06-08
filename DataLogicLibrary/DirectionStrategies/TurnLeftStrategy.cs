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
    public class TurnLeftStrategy : IDirectionStrategy
    {
        public StatusDTO Execute(StatusDTO currentStatus)
        {
            CardinalDirection newDirection;

            if (currentStatus.MovementAction != MovementAction.Backward)
            {

                switch (currentStatus.CardinalDirection)
                {
                    case CardinalDirection.North:
                        newDirection = CardinalDirection.West;
                        break;
                    case CardinalDirection.South:
                        newDirection = CardinalDirection.East;
                        break;
                    case CardinalDirection.East:
                        newDirection = CardinalDirection.North;
                        break;
                    case CardinalDirection.West:
                        newDirection = CardinalDirection.South;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(currentStatus.CardinalDirection), "Error: currentCardinalDirection not set");
                }
            }
            else
            {
                switch (currentStatus.CardinalDirection)
                {
                    case CardinalDirection.North:
                        newDirection = CardinalDirection.East;
                        break;
                    case CardinalDirection.South:
                        newDirection = CardinalDirection.West;
                        break;
                    case CardinalDirection.East:
                        newDirection = CardinalDirection.South;
                        break;
                    case CardinalDirection.West:
                        newDirection = CardinalDirection.North;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(currentStatus.CardinalDirection), "Error: currentCardinalDirection not set");
                }
            }


            currentStatus.CardinalDirection = newDirection;
            currentStatus.MovementAction = MovementAction.Left;

            return currentStatus;
        }

    }
}
