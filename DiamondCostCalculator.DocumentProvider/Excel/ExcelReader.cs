using DiamondCostCalculator.DocumentContract.Excel;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;
using DTORow = DiamondCostCalculator.DocumentContract.DTO;

namespace DiamondCostCalculator.DocumentProvider.Excel
{
    public class ExcelReader : IExcelReader
    {
        private IEnumerator<Row> _rows = null;

        public IEnumerator<DTORow.Row> GetEnumerator() { return this; }
        public DTORow.Row Current { get { return Convert(_rows.Current); } }
        object IEnumerator.Current { get { return Current; } }

        public ExcelReader(SheetData sheet)
        {
            _rows = sheet.Elements<Row>().GetEnumerator();
        }

        private DTORow.Row Convert(Row row)
        {
            return new DTORow.Row()
            {
                Cells = row.Elements<Cell>()
                           .Select(c => new DTORow.Cell(GetCellValue(c)))
                           .ToList()
            };
        }

        private object GetCellValue(Cell cell)
        {
            var cellValue = cell.CellValue != null ? cell.CellValue.InnerText : String.Empty;

            if (cell.DataType == null)
            {
                double numValue;
                if (double.TryParse(cellValue, out numValue))
                    return numValue;

                DateTime dateValue;
                if (DateTime.TryParse(cellValue, out dateValue))
                    return dateValue;

                return null;
            }

            var cellType = cell.DataType.Value;

            switch (cellType)
            {
                case CellValues.Boolean:
                case CellValues.SharedString:
                case CellValues.String:
                case CellValues.InlineString:
                case CellValues.Error:
                    throw new InvalidOperationException(
                        string.Format("Cell {0} has inappropriate data type.", cell.CellReference.Value));
            }

            return null;
        }

        public void Dispose()
        {
            _rows.Dispose();
        }

        public bool MoveNext()
        {
            return _rows.MoveNext();
        }

        public void Reset()
        {
            _rows.Reset();
        }
    }
}
