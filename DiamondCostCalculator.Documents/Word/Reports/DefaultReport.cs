using DiamondCostCalculator.DocumentContract.DTO;
using DiamondCostCalculator.DocumentContract.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Documents.Word.Reports
{
    public class DefaultReport : IReport
    {
        private IWordReportCreator _reportCreator;

        public DefaultReport(IWordReportCreator creator)
        {
            _reportCreator = creator;
        }

        public void Body()
        {
            var rows = new List<Row>();
            var rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                var row = new Row() { Cells = new List<Cell>() };
                for (int j = 0; j < 10; j++)
                {
                    row.Cells.Add(new Cell(rand.Next() % 1000));
                }
                rows.Add(row);
            }

            _reportCreator.AddTable(rows);
        }

        public void Footer() { }

        public void Header() { }

        public void Open(string fileName)
        {
            _reportCreator.Open(fileName);
        }

        public void Dispose()
        {
            _reportCreator.Save();
            _reportCreator.Dispose();
        }
    }
}
