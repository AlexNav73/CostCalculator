using DiamondCostCalculator.Core.OrderInfo;
using DiamondCostCalculator.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.Core.ReportData
{
    public class EvaluatedCostReportTable
    {
        [Header("Наименование драгоценного камня", 1)]
        public string Name { get; set; }
        [Header("Нмер аттестата качества на бриллиант", 1)]
        public string Number { get; set; }
        [Header("Форма огранки", 1)]
        public Shape Shape { get; set; }
        [Header("Масса, карат", 1)]
        public double Mass { get; set; }
        [Header("Количество, штук", 1)]
        public int Count { get; set; }
        [Header("Качественно-цветовые характеристики", 1)]
        public string Color { get; set; }
        [Header("Цена за карат согласно прейскуранту в долларах США", 1)]
        public double PriceForCaratUSA { get; set; }
        [Header("Курс доллара США к белорусскому рублю на дату пакупки", 1)]
        public double USACourse { get; set; }
        [Header("Сумма, белорусских рублей", 1)]
        public double PriceBel { get; set; }
    }
}
