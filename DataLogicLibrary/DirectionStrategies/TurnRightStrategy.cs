using DataLogicLibrary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DirectionStrategies.Interfaces;

namespace DataLogicLibrary.DirectionStrategies
{
    public class TurnRightStrategy : IDirectionStrategy
    {
        public CardinalDirection Execute(CardinalDirection currentCardinalDirection, MovementAction movementAction)
        {
            CardinalDirection newDirection;

            switch (currentCardinalDirection)
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
                    throw new ArgumentOutOfRangeException(nameof(currentCardinalDirection), "Error: currentCardinalDirection not set");
            }

            return newDirection;
        }
    }
}
