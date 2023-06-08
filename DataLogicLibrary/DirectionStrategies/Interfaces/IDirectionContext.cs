using DataLogicLibrary.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DTO;

namespace DataLogicLibrary.DirectionStrategies.Interfaces
{
    public interface IDirectionContext
    {
        void SetStrategy(IDirectionStrategy strategy);

        StatusDTO ExecuteStrategy(StatusDTO currentStatus);

    }
}
