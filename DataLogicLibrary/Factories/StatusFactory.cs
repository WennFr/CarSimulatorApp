using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Infrastructure.Enums;

namespace DataLogicLibrary.Factories
{
    public class StatusFactory : IStatusFactory
    {
        public StatusDTO CreateStatus()
        {
            return new StatusDTO
            {
                CardinalDirection = CardinalDirection.North,
                MovementAction = MovementAction.Forward,
                GasValue = 20,
                EnergyValue = 20
            };
        }

    }
}
