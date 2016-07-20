using DiamondCostCalculator.Documents.Excel;
using DiamondCostCalculator.Documents.Word;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DependencyResolver
{
    public class Deps
    {
        [Inject]
        public ExcelHelper Excel { get; set; }

        [Inject]
        public ReportGenerator Word { get; set; }
    }
}
