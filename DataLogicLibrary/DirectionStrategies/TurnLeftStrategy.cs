using DataLogicLibrary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DirectionStrategies.Interfaces;

namespace DataLogicLibrary.DirectionStrategies
{
    public class TurnLeftStrategy : IDirectionStrategy
    {
        public CardinalDirection Execute(CardinalDirection currentCardinalDirection, MovementAction movementAction)
        {
            CardinalDirection newDirection;

            switch (currentCardinalDirection)
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
                    throw new ArgumentOutOfRangeException(nameof(currentCardinalDirection), "Error: currentCardinalDirection not set");
            }

            return newDirection;
        }

    }
}
