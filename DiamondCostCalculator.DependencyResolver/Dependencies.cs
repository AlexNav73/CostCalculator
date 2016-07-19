using DiamondCostCalculator.DocumentContract.Excel;
using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.DocumentProvider.Excel;
using DiamondCostCalculator.DocumentProvider.Word;
using DiamondCostCalculator.Documents.Excel;
using DiamondCostCalculator.Documents.Word;
using DiamondCostCalculator.Documents.Word.Reports;
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

            Bind<IWordReportCreator>().To<WordReportCreator>();
            Bind<IReport>().To<DefaultReport>();
            Bind<ReportGenerator>().ToSelf();
        }
    }
}
