using DiamondCostCalculator.LocalizationEn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Documents.Word.Data
{
    public class Table1 : ReportTable
    {
        public Table1()
        {

        }

        protected override void BuildTableHeaders()
        {
            AddHeader(ReportHeaders.Params);
            AddHeader(ReportHeaders.ClientData);
            AddHeader(ReportHeaders.NationalBankData);
            AddHeader(ReportHeaders.ComparisonMark);
        }

        protected override void BuildTableData()
        {
        }
    }
}
