using DiamondCostCalculator.DocumentContract.DTO;
using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.DocumentProvider.Word.Helpers;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentProvider.Word
{
    public class WordReportCreator : IWordReportCreator
    {
        private WordprocessingDocument _document;
        private Document _documentPart;

        public IWordReportCreator AddTable(ICollection<Row> rows)
        {
            var table = WordHelper.CreateTableTemplate();

            foreach (Row row in rows)
            {
                var tr = new TableRow();

                var tableCells = row.Cells
                    .Select(c =>
                    {
                        var cell = new TableCell();
                        cell.Append(new Paragraph(new Run(new Text(c.Unwrap<object>().ToString()))));
                        return cell;
                    }).ToList();

                tableCells.ForEach(c => {
                    tr.Append(c);
                    tr.Append(WordHelper.CreateTableCellProperties());
                });

                table.Append(tr);
            }

            _documentPart.Body.Append(table);

            return this;
        }

        public IWordReportCreator Open(string fileName)
        {
            _document = WordprocessingDocument.Create(fileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
            _document.AddMainDocumentPart();
            _documentPart = new Document();
            _documentPart.Body = new Body();
            _document.MainDocumentPart.Document = _documentPart;
            return this;
        }

        public void Save()
        {
            _documentPart.Save();
        }

        public void Dispose()
        {
            Save();
            _document.Dispose();
        }
    }
}
