using DiamondCostCalculator.DocumentContract.Excel;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;

namespace DiamondCostCalculator.DocumentProvider.Excel
{
    public class ExcelReader : IExcelReader<SheetData>
    {
        public DataTable ReadSheet(SheetData sheet)
        {
            var table = new DataTable();
            var stringType = typeof(string);

            table.Columns.Add(String.Empty, stringType);
            foreach (var headerCell in sheet.Elements<Row>().First().Elements<Cell>())
                table.Columns.Add(headerCell.InnerText, stringType);

            foreach(var row in sheet.Elements<Row>().Skip(1))
            {
                var newRow = table.NewRow();
                int j = 0;

                foreach (var cell in row.Elements<Cell>())
                    newRow[j++] = cell.InnerText;

                table.Rows.Add(newRow);
            }

            return table;
        }
    }
}
