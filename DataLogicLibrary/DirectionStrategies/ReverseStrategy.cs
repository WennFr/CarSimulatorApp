using DataLogicLibrary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DirectionStrategies.Interfaces;

namespace DataLogicLibrary.DirectionStrategies
{
    public class ReverseStrategy : IDirectionStrategy
    {
        public CardinalDirection Execute(CardinalDirection currentCardinalDirection, MovementAction movementAction)
        {
            CardinalDirection oppositeDirection;

            switch (currentCardinalDirection)
            {
                case CardinalDirection.North:
                    oppositeDirection = CardinalDirection.South;
                    break;
                case CardinalDirection.South:
                    oppositeDirection = CardinalDirection.North;
                    break;
                case CardinalDirection.East:
                    oppositeDirection = CardinalDirection.West;
                    break;
                case CardinalDirection.West:
                    oppositeDirection = CardinalDirection.East;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentCardinalDirection), "Error: currentCardinalDirection not set");
            }

            return oppositeDirection;
        }

    }
}
