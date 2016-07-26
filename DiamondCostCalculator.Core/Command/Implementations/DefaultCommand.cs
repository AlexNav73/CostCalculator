using DiamondCostCalculator.Core.Excel;
using DiamondCostCalculator.DependencyResolver;
using DiamondCostCalculator.DocumentContract.Excel;
using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.Reporting;
using DiamondCostCalculator.Reporting.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.Core.Command.Implementations
{
    public class DefaultCommand : ICommand
    {
        public double Execute(Order order)
        {
            //var excel = Resolver.Resolve<ExcelHelper>();
            //excel.Open("123.xlsx", "Лист1");
            //var doc = new SmallDocument(excel);

            //using (var word = Resolver.Resolve<ReportGenerator>())
            //    word.CreateReport("Test.docx");

            //var list = CSVParser.Parse<MyClass>("qwe.csv");

            //var excel = new ExcelHelper();
            //var t = excel.Read("123.xlsx");

            var generator = new ReportGenerator();
            generator.CreateReport("Conclusion.docx", ReportType.Conclusion);

            return default(double);
        }
    }
}
