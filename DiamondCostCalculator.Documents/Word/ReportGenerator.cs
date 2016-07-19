using DiamondCostCalculator.DocumentContract.DTO;
using DiamondCostCalculator.DocumentContract.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Documents.Word
{
    public class ReportGenerator
    {
        private IReport _report;

        public ReportGenerator(IReport report)
        {
            _report = report;
        }

        public void CreateReport(string fileName)
        {
            _report.Open(fileName);
            _report.Header();
            _report.Body();
            _report.Footer();
            _report.Dispose();
        }
    }
}
