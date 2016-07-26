using DiamondCostCalculator.DocumentContract.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentProvider.Excel
{
    public class ExcelDocument : IExcelDocument
    {
        private SpreadsheetDocument _document;
        private WorkbookPart _wbPart;
        private IExcelReader<SheetData> _reader;

        public ExcelDocument(IExcelReader<SheetData> reader)
        {
            _reader = reader;
        }

        public void Open(string filePath)
        {
            Contract.Requires(!string.IsNullOrEmpty(filePath));

            _document = SpreadsheetDocument.Open(filePath, false);
            _wbPart = _document.WorkbookPart;
        }

        public DataTable ReadFirstSheet()
        {
            var sheet = _wbPart.Workbook.Descendants<Sheet>().FirstOrDefault();

            if (sheet != null)
            {
                var worksheet = ((WorksheetPart)_wbPart.GetPartById(sheet.Id)).Worksheet;
                return _reader.ReadSheet(worksheet.GetFirstChild<SheetData>());
            }

            throw new InvalidOperationException("Document doesn't contains any worksheets");
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
