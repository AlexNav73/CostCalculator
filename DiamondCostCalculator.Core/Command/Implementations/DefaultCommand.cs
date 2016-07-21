using DiamondCostCalculator.DependencyResolver;
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
            var deps = Resolver.Resolve<Deps>();

            //var excel = Resolver.Resolve<ExcelHelper>();
            //excel.Open("123.xlsx", "Лист1");
            //var doc = new SmallDocument(excel);

            //using (var word = Resolver.Resolve<ReportGenerator>())
            //    word.CreateReport("Test.docx");

            //var list = CSVParser.Parse<MyClass>("qwe.csv");

            return default(double);
        }
    }
}
