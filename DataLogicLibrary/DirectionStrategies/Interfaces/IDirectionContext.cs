using DataLogicLibrary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.DirectionStrategies.Interfaces
{
    public interface IDirectionContext
    {
        void SetStrategy(IDirectionStrategy strategy);

        CardinalDirection ExecuteStrategy(CardinalDirection currentCardinalDirection, MovementAction movementAction);

    }
}
