using DiamondCostCalculator.Core.OrderInfo;
using DiamondCostCalculator.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.Core.ReportData
{
    public class InventoryInvestmentTable
    {
        [Header("№ Пакета", 1)]
        public string PacketNumber { get; set; }
        [Header("№ Договора", 2)]
        public string Unknown { get; set; }
        [Header("Форма огранки", 3)]
        public Shape Shape { get; set; }
        [Header("Цвет/Дефектность", 4)]
        public string Color { get; set; }
        [Header("Весовая группа", 5)]
        public string WeightGroup { get; set; }
        [Header("Кол-во, штук", 6)]
        public int Count { get; set; }
        [Header("Масса, карат", 7)]
        public double Mass { get; set; }
        [Header("Стоймость (бел. руб.)", 8)]
        public double Price { get; set; }
        [Header("Отметка об изъятии", 9)]
        public string Mark { get; set; }
    }
}
