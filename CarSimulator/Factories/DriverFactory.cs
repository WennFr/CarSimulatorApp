using APIServiceLibrary.DTO;
using CarSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator.Factories
{
    public class DriverFactory : IDriverFactory
    {
        public Driver CreateDriver(ResultsDTO resultDTO)
        {
            return new Driver
            {
                Title = resultDTO.Results[0].Name.Title,
                First = resultDTO.Results[0].Name.First,
                Last = resultDTO.Results[0].Name.Last,
                City = resultDTO.Results[0].Location.City,
                Country = resultDTO.Results[0].Location.Country,
                EnergyValue = 20
            };
        }

    }
}
