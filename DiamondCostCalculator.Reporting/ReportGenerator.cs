using DiamondCostCalculator.DocumentContract.DTO;
using DiamondCostCalculator.DocumentContract.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Reporting
{
    public class ReportGenerator
    {
        public void CreateReport(string fileName, ReportType type, IWordProcessor creator)
        {
            var report = ReportFactory.Create(type);
            creator.Create(report.GetTemplateFilePath(), fileName);
            report.BuildReport(creator);
            creator.Save();
        }
    }
}
