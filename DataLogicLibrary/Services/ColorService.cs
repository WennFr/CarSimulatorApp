using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.Services
{
    public class ColorService : IColorService
    {
        public void ConsoleWriteLineRed(string stringToColor)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(stringToColor);
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        public void ConsoleWriteRed(string stringToColor)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(stringToColor);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ConsoleWriteLineGreen(string stringToColor)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(stringToColor);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ConsoleWriteGreen(string stringToColor)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(stringToColor);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ConsoleWriteLineWhite(string stringToColor)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(stringToColor);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
