﻿using DataLogicLibrary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.DTO
{
    public class StatusDTO
    {
        public CardinalDirection CardinalDirection { get; set; }
        public MovementAction MovementAction { get; set; }
        public HungerStatus HungerStatus { get; set; }
        public int GasValue { get; set; }
        public int EnergyValue { get; set; }
        public int HungerValue { get; set; }

    }
}
