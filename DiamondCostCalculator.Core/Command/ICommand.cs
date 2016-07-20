using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.Core.Command
{
    public interface ICommand
    {
        double Execute(Order order);
    }
}
