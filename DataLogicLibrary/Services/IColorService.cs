using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.Services
{
    public interface IColorService
    {
        void ConsoleWriteLineYellow(string stringToColor);

        void ConsoleWriteLineRed(string stringToColor);

        void ConsoleWriteRed(string stringToColor);

        void ConsoleWriteLineGreen(string stringToColor);

        void ConsoleWriteLineWhite(string stringToColor);

    }
}
