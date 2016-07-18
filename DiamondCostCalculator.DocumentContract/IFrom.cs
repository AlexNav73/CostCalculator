using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentContract
{
    public interface IFrom<F, T>
    {
        T Into(F obj);
    }
}
