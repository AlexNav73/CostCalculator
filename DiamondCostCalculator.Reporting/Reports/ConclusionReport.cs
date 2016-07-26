using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.DocumentContract.Commands;

namespace DiamondCostCalculator.Reporting.Reports
{
    public class ConclusionReport : Report
    {
        protected override string GetReportName()
        {
            return ReportType.Conclusion.ToString();
        }

        public void InsertTable(List<List<string>> data)
        {
            var insertTable = GetCommand(typeof(ITableCommand));
            insertTable.Context = data;
        }
    }
}
