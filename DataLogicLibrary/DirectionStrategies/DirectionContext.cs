using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLibrary.DirectionStrategies
{
    public class DirectionContext : IDirectionContext
    {
        private IDirectionStrategy _strategy;

        public void SetStrategy(IDirectionStrategy strategy)
        {
            _strategy = strategy;
        }

        public IAreaPerimeter ExecuteStrategy(double x, double y, double z)
        {
            return _strategy.Execute(x, y, z);
        }

    }
}
