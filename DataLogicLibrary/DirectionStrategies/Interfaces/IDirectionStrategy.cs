using DataLogicLibrary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DTO;

namespace DataLogicLibrary.DirectionStrategies.Interfaces
{
    public interface IDirectionStrategy
    {
        StatusDTO Execute(StatusDTO currentStatus);
    }
}
