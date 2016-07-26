using System.Collections.Generic;
using System.Data;

namespace DiamondCostCalculator.DocumentContract.Excel
{
    public interface IExcelReader<TSheet>
    {
        DataTable ReadSheet(TSheet sheet);
    }
}
