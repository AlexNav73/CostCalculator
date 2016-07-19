using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Documents.Word
{
    public interface IReport : IDisposable
    {
        void Open(string fileName);
        void Header();
        void Body();
        void Footer();
    }
}
