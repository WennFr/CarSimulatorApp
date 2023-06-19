using CarSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator.Menus
{
    public interface IMenu
    {
        void DisplaySelectionMenu();
        void OpeningPrompt(Driver driver);
        void StatusPrompt(Car car, Driver driver);
    }
}
