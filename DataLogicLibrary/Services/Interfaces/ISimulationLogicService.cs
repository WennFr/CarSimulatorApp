using DataLogicLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.Services.Interfaces
{
    public interface ISimulationLogicService
    {
        StatusDTO PerformAction(int userInput, StatusDTO currentStatus);

        StatusDTO DecreaseStatusValues(int userInput, StatusDTO currentStatus);

        void ColorStatusTextBasedOnValue(string stringToColor, int currentValue);

    }
}
