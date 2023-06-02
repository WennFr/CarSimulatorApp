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
            var direction = currentCardinalDirection;

            return direction;
        }

    }
}
