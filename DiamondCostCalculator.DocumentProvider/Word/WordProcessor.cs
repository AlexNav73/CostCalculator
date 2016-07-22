using DiamondCostCalculator.DocumentContract.DTO;
using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.DocumentProvider.Word.Helpers;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DiamondCostCalculator.DocumentProvider.Word
{
    public class WordProcessor : IWordProcessor
    {
        private WordprocessingDocument _document;
        private Document _documentPart;
        private Regex _tokenRegex = new Regex("##.*##");

        public void AddTable(IEnumerable<IEnumerable<string>> rows)
        {
            var table = WordHelper.CreateTableTemplate();

            foreach (ICollection<string> row in rows)
            {
                var tr = new TableRow();

                var tableCells = row
                    .Select(c =>
                    {
                        var cell = new TableCell();
                        cell.Append(new Paragraph(new Run(new Text(c))));
                        return cell;
                    }).ToList();

                tableCells.ForEach(c => {
                    tr.Append(c);
                    tr.Append(WordHelper.CreateTableCellProperties());
                });

                table.Append(tr);
            }

            _documentPart.Body.Append(table);
        }

        public void LoadTemplate(string fileName)
        {
            _document = WordprocessingDocument.Open(fileName, true);
            _documentPart = _document.MainDocumentPart.Document;
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

        public IEnumerable<string> GetTokens()
        {
            var tokens = new List<string>();
            CollectTokens(tokens, _documentPart.Body);
            return tokens;
        }

        private void CollectTokens(List<string> tokens, OpenXmlElement elements)
        {
            foreach (OpenXmlElement element in elements.Elements())
            {
                switch (element.LocalName)
                {
                    case "t":
                        TryRetriveToken(tokens, element.InnerText);
                        break;
                    case "p":
                        CollectTokens(tokens, element);
                        break;

                    case "cr":
                    case "br":
                    case "tab":
                        break;

                    default:
                        CollectTokens(tokens, element);
                        break;
                }
            }
        }

        private void TryRetriveToken(List<string> tokens, string str)
        {
            // TODO: Find tokens in string using regex
            tokens.Add(string.Empty);
        }
    }
}
