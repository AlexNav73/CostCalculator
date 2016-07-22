using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiamondCostCalculator.DocumentContract.Word;

namespace DiamondCostCalculator.Documents.Word.Reports
{
    internal class ConclusionReport : Report
    {
        public override void BuildReport(IWordProcessor creator)
        {
        }

        protected override string GetReportName()
        {
            return ReportType.Conclusion.ToString();
        }
    }
}
