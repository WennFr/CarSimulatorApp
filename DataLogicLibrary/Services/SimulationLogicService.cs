using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLibrary.DTO;

namespace DataLogicLibrary.Services
{
    public class SimulationLogicService
    {


        public StatusDTO PerformAction(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    _geometryContext.SetStrategy(_rectangleStrategy);
                    break;

                case Shape.shape.Parallelogram:
                    _geometryContext.SetStrategy(_parallelogramStrategy);
                    break;

                case Shape.shape.Triangle:
                    _geometryContext.SetStrategy(_triangleStrategy);
                    break;

                case Shape.shape.Rhombus:
                    _geometryContext.SetStrategy(_rhombusStrategy);
                    break;
            }


        }


    }
}
