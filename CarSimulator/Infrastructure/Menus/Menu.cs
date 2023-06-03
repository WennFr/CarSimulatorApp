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

        public static void DisplaySelectedAction(int input)
        {

            switch (input)
            {
                case 1:
                    Console.WriteLine($"{Environment.NewLine}Car turns and drives to the left{Environment.NewLine}");
                    break;
                case 2:
                    Console.WriteLine($"{Environment.NewLine}Car turns and drives to the right{Environment.NewLine}");
                    break;
                case 3:
                    Console.WriteLine($"{Environment.NewLine}Car drives forward{Environment.NewLine}");
                    break;
                case 4:
                    Console.WriteLine($"{Environment.NewLine}Car reverses{Environment.NewLine}");
                    break;
                case 5:
                    Console.WriteLine($"{Environment.NewLine}Driver takes a rest{Environment.NewLine}");
                    break;
                case 6:
                    Console.WriteLine($"{Environment.NewLine}Car refuels{Environment.NewLine}");
                    break;
                case 7:
                    Console.WriteLine($"{Environment.NewLine}Aborted simulation{Environment.NewLine}");
                    break;
            }



        }


    }
}
