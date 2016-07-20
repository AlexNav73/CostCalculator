using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.Core.Command.Implementations
{
    public class DefaultCommand : ICommand
    {
        public double Execute(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
