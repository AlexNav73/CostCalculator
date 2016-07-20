using System;
using DiamondCostCalculator.DependencyResolver;
using DiamondCostCalculator.Documents.Excel;
using DiamondCostCalculator.Documents.Excel.Documents;
using DiamondCostCalculator.Documents.Word;
using DiamondCostCalculator.Documents.CSV;

namespace ConsoleApplication1
{
    class Program
    {
        class MyClass
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public double Height { get; set; }
        }

        static void Main(string[] args)
        {
            //var excel = Resolver.Resolve<ExcelHelper>();
            //excel.Open("123.xlsx", "Лист1");
            //var doc = new SmallDocument(excel);

            //using (var word = Resolver.Resolve<ReportGenerator>())
            //    word.CreateReport("Test.docx");

            //var list = CSVParser.Parse<MyClass>("qwe.csv");

            var deps = new Deps();
        }
    }
}
