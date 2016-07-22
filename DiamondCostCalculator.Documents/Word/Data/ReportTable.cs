using DiamondCostCalculator.DocumentContract.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Documents.Word.Data
{
    public abstract class ReportTable
    {
        private List<string> _headers = new List<string>();
        private List<List<string>> _data = new List<List<string>>() { null };

        protected void AddHeader(string name)
        {
            _headers.Add(name);
        }

        protected void AddData(IEnumerable<string> data)
        {
            _data.Add(data.ToList());
        }

        protected abstract void BuildTableHeaders();
        protected abstract void BuildTableData();

        protected virtual void WriteTable(IWordProcessor creator)
        {
            if (_data[0] == null)
                _data[0] = _headers;

            creator.AddTable(_data);
        }
    }
}
