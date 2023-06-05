using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.Services
{
    public interface IMessageService
    {

        void DisplayDriverStatusMessage(int value);
        void DisplayCarStatusMessage(int value);
    }
}
