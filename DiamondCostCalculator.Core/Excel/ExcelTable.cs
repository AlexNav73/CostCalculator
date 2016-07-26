using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.Core.Excel
{
    public class ExcelTable
    {
        private DataTable _table;
        private string[] _columns;
        private string[] _rows;

        public ExcelTable(DataTable table)
        {
            _table = table;
            _columns = table.Columns.OfType<DataColumn>().Select(c => c.ColumnName).ToArray();
            _rows = table.Rows.OfType<DataRow>().Select(r => r.ItemArray[0].ToString()).ToArray();
        }

        public T Get<T>(string row, string col)
        {
            var colIdx = Array.IndexOf(_columns, col);
            var rowIdx = Array.IndexOf(_rows, row);

            return (T)_table.Rows[rowIdx][colIdx];
        }
    }
}
