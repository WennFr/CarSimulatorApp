using CarSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator.Factories
{
    public interface ICarFactory
    {
        Car CreateCar();
    }
}
