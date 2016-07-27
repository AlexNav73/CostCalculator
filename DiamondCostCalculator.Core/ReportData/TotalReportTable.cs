using DiamondCostCalculator.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.Core.ReportData
{
    public class TotalReportTable
    {
        [Header("Параметры исследования", 1)]
        public string Parameters { get; set; }
        [Header("По данным клиента", 2)]
        public string ClientData { get; set; }
        [Header("По данным Национального банка Республики Беларусь", 3)]
        public string BankData { get; set; }
        [Header("Отметка о соответствии", 4)]
        public string Mark { get; set; }
    }
}
