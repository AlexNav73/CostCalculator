using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentContract.Commands
{
    public interface ICommand
    {
        object Context { get; set; }
        object Execute();
    }
}
