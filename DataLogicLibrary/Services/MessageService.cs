﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DTO;

namespace DataLogicLibrary.Services
{
    public class MessageService : IMessageService
    {
        public MessageService(IColorService colorService)
        {
            _colorService = colorService;
        }

        private readonly IColorService _colorService;

        public void DisplayDriverStatusMessage(int value)
        {
            if (value <= 10 && value > 5)
            {
                _colorService.ConsoleWriteLineWhite($"Driver is getting tired, consider taking a rest.{Environment.NewLine}");
            }

            else if (value <= 5 && value >= 1)
            {
                _colorService.ConsoleWriteLineRed($"Driver is struggling to stay awake!{Environment.NewLine}");
            }

            else if (value == 0)
            {
                _colorService.ConsoleWriteLineRed($"Driver has fallen asleep!!!! WATCH OUT! {Environment.NewLine}");
            }

        }

        public void DisplayCarStatusMessage(int value)
        {
            if (value <= 10 && value > 5)
            {
                _colorService.ConsoleWriteLineWhite($"Car is running out of gas, consider refueling the car.{Environment.NewLine}");
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