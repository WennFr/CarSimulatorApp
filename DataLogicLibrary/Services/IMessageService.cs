using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.Services
{
    public interface IMessageService
    {
        void DisplaySelectedAction(int input);
        void DisplayDriverStatusMessage(int value, string driverName);
        void DisplayCarStatusMessage(int value);
    }
}
