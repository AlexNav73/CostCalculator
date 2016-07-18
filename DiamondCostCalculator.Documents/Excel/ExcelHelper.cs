using DiamondCostCalculator.DocumentContract;
using DiamondCostCalculator.DocumentContract.Excel.DTO;
using DiamondCostCalculator.DocumentProvider.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiamondCostCalculator.Documents.Excel
{
    public class ExcelHelper
    {
        private IEnumerator<Row> _rows;

        public ExcelHelper(string fileName, string sheetName)
        {
            var doc = new ExcelDocument(fileName);
            var reader = doc.GetReader(sheetName);

            _rows = reader.GetEnumerator();
        }

        public bool Read<TRow>(ref TRow row) where TRow : IFrom<Row, TRow>, new()
        {
            bool canMove;
            if ((canMove = _rows.MoveNext()))
            {
                row = (new TRow()).Into(_rows.Current);
            }
            return canMove;
        }
    }
}
