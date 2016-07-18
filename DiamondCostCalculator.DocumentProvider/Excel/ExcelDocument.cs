using DiamondCostCalculator.DocumentContract.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentProvider.Excel
{
    public class ExcelDocument : IDocument
    {
        private SpreadsheetDocument _document;
        private WorkbookPart _wbPart;

        public ExcelDocument(string filePath)
        {
            _document = SpreadsheetDocument.Open(filePath, false);
            _wbPart = _document.WorkbookPart;
        }

        public IExcelReader GetReader(string sheetName)
        {
            Contract.Requires(!string.IsNullOrEmpty(sheetName));

            var sheet = _wbPart.Workbook
                    .Descendants<Sheet>()
                    .FirstOrDefault(s => string.Equals(sheetName, s.Name, StringComparison.CurrentCulture));

            if (sheet != null)
            {
                var worksheet = ((WorksheetPart)_wbPart.GetPartById(sheet.Id)).Worksheet;
                return new ExcelReader(worksheet.GetFirstChild<SheetData>());
            }
            throw new InvalidOperationException(string.Format("Invalid sheet name: {0}", sheetName));
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            _document.Close();
        }
    }
}
