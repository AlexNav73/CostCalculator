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
        public void CreateReport(string fileName, ReportType type, IWordProcessor creator)
        {
            creator.LoadTemplate(fileName);
            var report = ReportFactory.Create(type);
            report.BuildReport(creator);
            creator.Save();
        }
    }
}
