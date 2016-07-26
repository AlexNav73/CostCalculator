using DiamondCostCalculator.DependencyResolver;
using DiamondCostCalculator.DocumentContract.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Reporting
{
    public class ReportGenerator
    {
        public void CreateReport(string fileName, ReportType type)
        {
            using (var word = Container.Resolve<IWordProcessor>())
            {
                var report = ReportFactory.Create(type);
                word.Create(report.GetTemplateFilePath(), fileName);
                report.BuildReport(word);
            }
        }
    }
}
