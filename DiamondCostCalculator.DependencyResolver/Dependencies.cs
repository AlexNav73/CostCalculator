using DiamondCostCalculator.DocumentContract.Commands;
using DiamondCostCalculator.DocumentContract.Excel;
using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.DocumentProvider.Commands;
using DiamondCostCalculator.DocumentProvider.Excel;
using DiamondCostCalculator.DocumentProvider.Word;
using DiamondCostCalculator.Documents.Excel;
using Ninject.Modules;

namespace DiamondCostCalculator.DependencyResolver
{
    class Dependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<IExcelReader>().To<ExcelReader>();
            Bind<IExcelDocument>().To<ExcelDocument>();
            Bind<ExcelHelper>().ToSelf();

            Bind<IWordProcessor>().To<WordProcessor>();
            Bind<ITableCommand>().To<InsertTableCommand>();
        }
    }
}
