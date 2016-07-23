﻿using DiamondCostCalculator.DependencyResolver;
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
            var deps = Resolver.Resolve<Deps>();

            //var excel = Resolver.Resolve<ExcelHelper>();
            //excel.Open("123.xlsx", "Лист1");
            //var doc = new SmallDocument(excel);

            //using (var word = Resolver.Resolve<ReportGenerator>())
            //    word.CreateReport("Test.docx");

            //var list = CSVParser.Parse<MyClass>("qwe.csv");

            var generator = new ReportGenerator();
            using (var word = Resolver.Resolve<IWordProcessor>())
            {
                generator.CreateReport("Conclusion", ReportType.Conclusion, word);
            }
            return default(double);
        }
    }
}
