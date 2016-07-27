using DiamondCostCalculator.Core.OrderInfo;
using DiamondCostCalculator.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.Core.ReportData
{
    public class ConclusionReportTable
    {
        [Header("Наименование драгоценного камня", 1)]
        public string Name { get; set; }
        [Header("Номер аттестата качества на бриллиант", 2)]
        public string Number { get; set; }
        [Header("Форма огранки", 3)]
        public Shape Shape { get; set; }
        [Header("Масса, карат", 4)]
        public double Mass { get; set; }
        [Header("Количество, штук", 5)]
        public int Count { get; set; }
        [Header("Качественно-цветовые характеристики", 6)]
        public string Quality { get; set; }
        [Header("Сумма, белорусских рублей", 7)]
        public double Price { get; set; }
    }
}
