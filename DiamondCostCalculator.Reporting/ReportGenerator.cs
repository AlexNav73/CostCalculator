using DiamondCostCalculator.DependencyResolver;
using DiamondCostCalculator.DocumentContract.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Reporting
{
    public static class ReportGenerator
    {
        public static void CreateReport(string fileName, Report report)
        {
            using (var word = Container.Resolve<IWordProcessor>())
            {
                File.Copy(report.GetTemplateFilePath(), fileName, true);
                word.Open(fileName);
                report.BuildReport(word);
            }
        }
    }
}
