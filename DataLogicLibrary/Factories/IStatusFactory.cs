using DataLogicLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.Factories
{
    public interface IStatusFactory
    {
        public StatusDTO CreateStatus();
    }
}
