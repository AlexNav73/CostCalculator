using DiamondCostCalculator.Documents.Word.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Documents.Word
{
    internal static class ReportFactory
    {
        public static Report Create(ReportType type)
        {
            switch (type)
            {
                case ReportType.Conclusion:
                    return new ConclusionReport();
                default:
                    throw new NotSupportedException(string.Format("{0} report type is not supported.", type));
            }
        }
    }
}
