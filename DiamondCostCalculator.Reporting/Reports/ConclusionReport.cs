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

        protected override void SetupCommands()
        {
            var insertTable = GetCommand(typeof(ITableCommand));
            insertTable.Context = new List<List<string>>()
            {
                new List<string>() { "11", "12", "13" },
                new List<string>() { "21", "22", "23" },
                new List<string>() { "31", "32", "33" },
                new List<string>() { "41", "42", "43" },
                new List<string>() { "51", "52", "53" }
            };
        }
    }
}
