using DiamondCostCalculator.DocumentContract.Excel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.DocumentContract.Excel
{
    public interface IDocument : IDisposable
    {
        IExcelReader GetReader(string sheetName);
        void Close();
    }
}
