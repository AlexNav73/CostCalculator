using System.Collections.Generic;
using DiamondCostCalculator.DocumentContract;
using DiamondCostCalculator.DocumentContract.DTO;
using DiamondCostCalculator.DocumentContract.Excel;

namespace DiamondCostCalculator.Core.Excel
{
    public class ExcelHelper
    {
        private IExcelDocument _document;
        private IEnumerator<Row> _rows;

        public ExcelHelper(IExcelDocument document)
        {
            _document = document;
        }

        public void Open(string fileName, string sheetName)
        {
            _document.Open(fileName);
            var reader = _document.GetReader(sheetName);

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
