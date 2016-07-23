using DiamondCostCalculator.DocumentContract;
using DiamondCostCalculator.DocumentContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Core.Excel.Documents
{
    public class SmallDocument
    {
        private struct CostsRow : IFrom<Row, CostsRow>
        {
            private ICollection<double> _costs;

            public CostsRow Into(Row obj)
            {
                _costs = obj.Cells.Skip(1).Select(c => c.Unwrap<double>()).ToArray();
                return this;
            }
        }

        private struct QualityRow : IFrom<Row, QualityRow>
        {
            private ICollection<double> _qualities;

            public QualityRow Into(Row obj)
            {
                _qualities = obj.Cells.Skip(1).Select(c => c.Unwrap<double>()).ToArray();
                return this;
            }
        }

        public SmallDocument(ExcelHelper helper)
        {
            QualityRow qualities = new QualityRow();
            var matrix = new List<CostsRow>();

            if (helper.Read(ref qualities))
            {
                CostsRow costs = new CostsRow();
                while(helper.Read(ref costs))
                {
                    matrix.Add(costs);
                }
            }
        }
    }
}
