using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using DiamondCostCalculator.DocumentContract.Word;
using DiamondCostCalculator.DocumentProvider.Word.Helpers;
using DiamondCostCalculator.DocumentContract.Commands;
using DiamondCostCalculator.DocumentProvider.Commands;

namespace DiamondCostCalculator.DocumentProvider.Word
{
    public class WordProcessor : IWordProcessor
    {
        private WordprocessingDocument _document;
        private Document _documentPart;

        public void Create(string templFile, string fileName)
        {
            File.Copy(templFile, fileName, true);
            _document = WordprocessingDocument.Open(fileName, true);
            _documentPart = _document.MainDocumentPart.Document;
        }

        private void SubstituteTokens(OpenXmlElement element, Func<string, OpenXmlElement> replace)
        {
            foreach (OpenXmlElement elem in element.Elements())
            {
                switch (elem.LocalName)
                {
                    case "t":
                        var newElem = replace(elem.InnerText);
                        if (newElem != null)
                            element.Parent.Parent.ReplaceChild(newElem, elem.Parent.Parent);
                        break;
                    case "p":
                        SubstituteTokens(elem, replace);
                        break;

                    case "cr":
                    case "br":
                    case "tab":
                        break;

                    default:
                        SubstituteTokens(elem, replace);
                        break;
                }
            }
        }

        public void ApplyCommands(IDictionary<string, ICommand> commands)
        {
            var tokens = commands.Keys;
            SubstituteTokens(_documentPart.Body, (str) =>
            {
                var token = tokens.FirstOrDefault(t => str.Contains(t));
                if (token != null)
                    return (OpenXmlElement)commands[token].Execute();
                return null;
            });
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
