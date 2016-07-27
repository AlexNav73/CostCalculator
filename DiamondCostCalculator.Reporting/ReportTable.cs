using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DiamondCostCalculator.Reporting
{
    public sealed class ReportTable<T>
    {
        private List<string> _headers;
        private List<List<string>> _data = new List<List<string>>();

        public List<string> Headers { get { return _headers; } }
        public List<List<string>> Data { get { return _data; } }

        public ReportTable(ICollection<T> data)
        {
            var attrType = typeof(HeaderAttribute);
            var props = typeof(T).GetProperties();
            var entries = props
                .Select(p => new TableEntry(attrType, p))
                .ToArray();

            Array.Sort(entries, new TableEntryComparer());
            _headers = entries.Select(e => e.HeaderName).ToList();

            foreach (var entity in data)
            {
                _data.Add(entries.Select(e => e.Property.GetValue(entity, null).ToString()).ToList());
            }
        }

        private struct TableEntry
        {
            public PropertyInfo Property;
            public string HeaderName;
            public int Index;

            public TableEntry(Type attrType, PropertyInfo prop)
            {
                Property = prop;

                var attr = (HeaderAttribute)prop.GetCustomAttributes(attrType, false).First(); 
                HeaderName = attr.HeaderName;
                Index = attr.Order;
            }
        }

        private class TableEntryComparer : IComparer<TableEntry>
        {
            public int Compare(TableEntry x, TableEntry y)
            {
                return x.Index.CompareTo(y.Index);
            }
        }
    }
}
