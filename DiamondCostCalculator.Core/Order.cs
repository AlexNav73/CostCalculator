using DiamondCostCalculator.Core.OrderInfo;
using DiamondCostCalculator.Core.ReportData;
using DiamondCostCalculator.Reporting;
using DiamondCostCalculator.Reporting.Reports;
using System.Collections.Generic;

namespace DiamondCostCalculator.Core
{
    public class Order
    {
        public Shape Shape { get; set; }
        public Quality Quality { get; set; }
        public Discount Discount { get; set; }
        public string Color { get; set; }
        public string Purity { get; set; }

        public Order(Shape shape, Quality quality, Discount discount, string color, string purity)
        {
            Shape = shape;
            Quality = quality;
            Discount = discount;
            Color = color;
            Purity = purity;
        }

        public void Test()
        {
            var table = new List<ConclusionReportTable>()
            {
                new ConclusionReportTable() { Name = "Name1", Number = "Number1", Shape = Shape.Round, Mass = 0.1, Count = 1, Quality = "Quality1", Price = 0.1 },
                new ConclusionReportTable() { Name = "Name2", Number = "Number2", Shape = Shape.Round, Mass = 0.2, Count = 2, Quality = "Quality2", Price = 0.2 },
                new ConclusionReportTable() { Name = "Name3", Number = "Number3", Shape = Shape.Round, Mass = 0.3, Count = 3, Quality = "Quality3", Price = 0.3 },
                new ConclusionReportTable() { Name = "Name4", Number = "Number4", Shape = Shape.Round, Mass = 0.4, Count = 4, Quality = "Quality4", Price = 0.4 }
            };
            var t = new ReportTable<ConclusionReportTable>(table);
            var d = t.Data;
            var h = t.Headers;
            //var report = new ConclusionReport();
            //report.InsertTable(new List<List<string>>()
            //{
            //    new List<string>() { "11", "12", "13" },
            //    new List<string>() { "21", "22", "23" },
            //    new List<string>() { "31", "32", "33" },
            //    new List<string>() { "41", "42", "43" },
            //    new List<string>() { "51", "52", "53" }
            //});
            //report.Save("Conclusion.docx");
        }
    }
}
