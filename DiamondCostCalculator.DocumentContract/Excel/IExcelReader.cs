using DiamondCostCalculator.DocumentContract.Excel.DTO;
using System.Collections.Generic;

namespace DiamondCostCalculator.DocumentContract.Excel
{
    public interface IExcelReader : IEnumerator<Row>
    {
        IEnumerator<Row> GetEnumerator();
    }
}
