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

            var report = new ConclusionReport();
            report.InsertTable(new List<List<string>>()
            {
                new List<string>() { "11", "12", "13" },
                new List<string>() { "21", "22", "23" },
                new List<string>() { "31", "32", "33" },
                new List<string>() { "41", "42", "43" },
                new List<string>() { "51", "52", "53" }
            });
            ReportGenerator.CreateReport("Conclusion.docx", report);

            return default(double);
        }
    }
}
