using DiamondCostCalculator.DocumentContract;
using DiamondCostCalculator.DocumentContract.Excel.DTO;
using DiamondCostCalculator.Documents.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        struct CostsRow : IFrom<Row, CostsRow>
        {
            private ICollection<double> _costs;

            public CostsRow Into(Row obj)
            {
                _costs = obj.Cells.Skip(1).Select(c => c.Unwrap<double>()).ToArray();
                return this;
            }
        }

        struct QualityRow : IFrom<Row, QualityRow>
        {
            private ICollection<double> _qualities;

            public QualityRow Into(Row obj)
            {
                _qualities = obj.Cells.Skip(1).Select(c => c.Unwrap<double>()).ToArray();
                return this;
            }
        }

        static void Main(string[] args)
        {
            var excel = new ExcelHelper("123.xlsx", "Лист1");
            QualityRow qualities = new QualityRow();
            var matrix = new List<CostsRow>();

            if (excel.Read(ref qualities))
            {
                CostsRow costs = new CostsRow();
                while(excel.Read(ref costs))
                {
                    matrix.Add(costs);
                }
            }
        }
    }
}
