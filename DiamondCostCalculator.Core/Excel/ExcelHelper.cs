using System.Collections.Generic;
using DiamondCostCalculator.DocumentContract;
using DiamondCostCalculator.DocumentContract.Excel;
using DiamondCostCalculator.DependencyResolver;

namespace DiamondCostCalculator.Core.Excel
{
    public class ExcelHelper
    {
        public ExcelTable Read(string fileName)
        {
            using (var excel = Container.Resolve<IExcelDocument>())
            {
                excel.Open(fileName);
                return new ExcelTable(excel.ReadFirstSheet());
            }
        }
    }
}
