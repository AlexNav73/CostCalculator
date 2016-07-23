using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.DocumentContract.Commands;

namespace DiamondCostCalculator.Reporting.Reports
{
    internal class ConclusionReport : Report
    {
        protected override string GetReportName()
        {
            return ReportType.Conclusion.ToString();
        }

        protected override void SetupCommands()
        {
            var insertTable = GetCommand(typeof(ITableCommand));
            insertTable.Context = new List<List<string>>();
        }
    }
}
