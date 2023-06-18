using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.Infrastructure.Enums;

namespace DataLogicLibrary.Services.Interfaces
{
    public interface IHungerService
    {
        int IncreaseHunger(int hungerValue);
        int ResetHunger();
        HungerStatus GetHungerStatus(int hungerValue);

    }
}
