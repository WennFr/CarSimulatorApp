using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator.Models;

namespace CarSimulator.Factories
{
    public class CarFactory
    {
        public Car CreateCar()
        {
            return new Car();
        }
    }
}
