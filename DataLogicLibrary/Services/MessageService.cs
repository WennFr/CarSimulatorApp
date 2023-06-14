using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DTO;
using DataLogicLibrary.Services.Interfaces;

namespace DataLogicLibrary.Services
{
    public class MessageService : IMessageService
    {
        public MessageService(IColorService colorService)
        {
            _colorService = colorService;
        }

        private readonly IColorService _colorService;


        public void DisplaySelectedAction(int input)
        {

            switch (input)
            {
                case 1:
                    _colorService.ConsoleWriteLineWhite($"{Environment.NewLine}Car turns and drives to the left{Environment.NewLine}");
                    break;
                case 2:
                    _colorService.ConsoleWriteLineWhite($"{Environment.NewLine}Car turns and drives to the right{Environment.NewLine}");
                    break;
                case 3:
                    _colorService.ConsoleWriteLineWhite($"{Environment.NewLine}Car drives forward{Environment.NewLine}");
                    break;
                case 4:
                    _colorService.ConsoleWriteLineWhite($"{Environment.NewLine}Car reverses and drives backwards{Environment.NewLine}");
                    break;
                case 5:
                    _colorService.ConsoleWriteLineWhite($"{Environment.NewLine}Driver takes a rest{Environment.NewLine}");
                    break;
                case 6:
                    _colorService.ConsoleWriteLineWhite($"{Environment.NewLine}Car refuels{Environment.NewLine}");
                    break;
                case 7:
                    _colorService.ConsoleWriteLineWhite($"{Environment.NewLine}Aborted simulation{Environment.NewLine}");
                    break;
                default:
                    _colorService.ConsoleWriteLineWhite($"{Environment.NewLine}Car is stationary.{Environment.NewLine}");
                    break;
            }


        }

        public void DisplayDriverStatusMessage(int value, string driverName)
        {
            if (value <= 10 && value > 5)
            {
                _colorService.ConsoleWriteLineYellow($"{driverName} is getting tired, consider taking a rest.{Environment.NewLine}");
            }

            else if (value <= 5 && value >= 1)
            {
                _colorService.ConsoleWriteLineRed($"{driverName} is struggling to stay awake!{Environment.NewLine}");
            }

            else if (value == 0)
            {
                _colorService.ConsoleWriteLineRed($"{driverName} has fallen asleep!!!! WATCH OUT {Environment.NewLine}");
            }

        }

        public void DisplayCarStatusMessage(int value)
        {
            if (value <= 10 && value > 5)
            {
                _colorService.ConsoleWriteLineYellow($"Car is running out of gas, consider refueling the car.{Environment.NewLine}");
            }

            else if (value <= 5 && value >= 1)
            {
                _colorService.ConsoleWriteLineRed($"Car is almost out of gas!{Environment.NewLine}");
            }

            else if (value == 0)
            {
                _colorService.ConsoleWriteLineRed($"Car is completely out of gas!! Refuel now! {Environment.NewLine}");
            }
        }

    }
}
