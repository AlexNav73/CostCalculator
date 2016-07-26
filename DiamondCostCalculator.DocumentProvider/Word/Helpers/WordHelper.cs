using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DiamondCostCalculator.DocumentProvider.Word.Helpers
{
    internal static class WordHelper
    {
        public static Table CreateTableTemplate()
        {
            var table = new Table();
            var props = new TableProperties(new TableBorders(
                new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 }
            ));
            table.AppendChild(props);
            return table;
        }

        public static TableCellProperties CreateTableCellProperties()
        {
            var tcp = new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Auto }
            );
            return tcp;
        }
    }
}
