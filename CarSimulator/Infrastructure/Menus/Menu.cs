using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator.Infrastructure.Menus
{
    public static class Menu
    {
        public static void DisplaySelectionMenu()
        {
            Console.WriteLine("(1) Turn left");
            Console.WriteLine("(2) Turn right");
            Console.WriteLine("(3) Drive forward");
            Console.WriteLine("(4) Reverse");
            Console.WriteLine("(5) Take a rest");
            Console.WriteLine("(6) Refuel the car");
            Console.WriteLine($"(7) Exit {Environment.NewLine}");
        }

    }
}
