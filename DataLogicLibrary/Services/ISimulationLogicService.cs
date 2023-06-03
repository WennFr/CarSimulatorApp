using DataLogicLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.Services
{
    public interface ISimulationLogicService
    {
        StatusDTO PerformAction(int userInput, StatusDTO currentStatus);

    }
}
