using DiamondCostCalculator.DocumentContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentContract.Word
{
    public interface IWordReportCreator : IDisposable
    {
        IWordReportCreator Open(string fileName);
        void Save();
        IWordReportCreator AddTable(ICollection<Row> rows);
    }
}
