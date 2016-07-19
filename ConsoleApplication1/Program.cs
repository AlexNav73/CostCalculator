using System;
using DiamondCostCalculator.DependencyResolver;
using DiamondCostCalculator.Documents.Excel;
using DiamondCostCalculator.Documents.Excel.Documents;
using DiamondCostCalculator.Documents.Word;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var excel = Resolver.Resolve<ExcelHelper>();
            //excel.Open("123.xlsx", "Лист1");
            //var doc = new SmallDocument(excel);

            var word = Resolver.Resolve<ReportGenerator>();
            word.CreateReport("Test.docx");
        }
    }
}
