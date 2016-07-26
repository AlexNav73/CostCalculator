using System.Linq;
using System.Collections.Generic;

using DiamondCostCalculator.DocumentContract.Commands;
using DiamondCostCalculator.DocumentProvider.Word.Helpers;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DiamondCostCalculator.DocumentProvider.Commands
{
    public class InsertTableCommand : ITableCommand
    {
        public object Context { get; set; }

        public object Execute()
        {
            var table = WordHelper.CreateTableTemplate();
            var rows = Context as List<List<string>>;

            foreach (var row in rows)
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

            return table;
        }
    }
}
