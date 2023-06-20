﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.Services.Interfaces
{
    public interface IMessageService
    {
        void DisplaySelectedAction(int userInput, int gasValue);
        void DisplayDriverStatusMessage(int value, string driverName);
        void DisplayCarStatusMessage(int value);
    }
}
