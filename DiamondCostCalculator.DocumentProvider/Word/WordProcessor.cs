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
using DiamondCostCalculator.DocumentContract.Commands;

namespace DiamondCostCalculator.DocumentProvider.Word
{
    public class WordProcessor : IWordProcessor
    {
        private WordprocessingDocument _document;
        private Document _documentPart;
        private Regex _tokenRegex = new Regex("##.*##");


        public void Load(string fileName)
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

        private void CollectTokens(List<string> tokens, OpenXmlElement elements)
        {
            foreach (OpenXmlElement element in elements.Elements())
            {
                switch (element.LocalName)
                {
                    case "t":
                        //
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

        public void ApplyCommands(IDictionary<string, ICommand> commands)
        {
            throw new NotImplementedException();
        }
    }
}
