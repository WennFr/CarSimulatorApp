using DataLogicLibrary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.DirectionStrategies.Interfaces
{
    public interface IDirectionStrategy
    {
        CardinalDirection Execute(CardinalDirection currentCardinalDirection, MovementAction movementAction);
    }
}
