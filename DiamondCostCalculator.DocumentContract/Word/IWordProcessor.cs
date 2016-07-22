using DiamondCostCalculator.DocumentContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentContract.Word
{
    public interface IWordProcessor : IDisposable
    {
        void LoadTemplate(string fileName);
        IEnumerable<string> GetTokens();
        void AddTable(IEnumerable<IEnumerable<string>> rows);
        void Save();
    }
}
