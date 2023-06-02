﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DirectionStrategies.Interfaces;
using DataLogicLibrary.Infrastructure.Enums;

namespace DataLogicLibrary.DirectionStrategies
{
    public class DirectionContext : IDirectionContext
    {
        private IDirectionStrategy _strategy;

        public void SetStrategy(IDirectionStrategy strategy)
        {
            _strategy = strategy;
        }

        public CardinalDirection ExecuteStrategy(CardinalDirection currentCardinalDirection, MovementAction movementAction)
        {
            return _strategy.Execute(currentCardinalDirection, movementAction);
        }

    }
}
