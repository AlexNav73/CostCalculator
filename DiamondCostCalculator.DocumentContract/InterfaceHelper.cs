using DiamondCostCalculator.DocumentContract.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentContract
{
    public static class InterfaceHelper
    {
        public static Type GetInterfaceType(string type)
        {
            return Type.GetType(type);
        }
    }
}
