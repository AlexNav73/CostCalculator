using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.Documents.Excel;
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
        public IWordProcessor Word { get; set; }
    }
}
