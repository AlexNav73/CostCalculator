using DiamondCostCalculator.DocumentContract.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DiamondCostCalculator.Documents.CSV
{
    public static class CSVParser
    {
        public static IEnumerable<T> Parse<T>(string filePath, IFormatProvider formatProvider = null) where T: new()
        {
            var separator = new[] { ',' };
            var objects = new List<T>();
            var provider = formatProvider ?? new StringFormatProvider();

            using (var reader = new StreamReader(new FileStream(filePath, FileMode.Open)))
            {
                var headers = reader.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                var properties = typeof(T).GetProperties().Where(p => headers.Contains(p.Name)).ToArray();

                while(!reader.EndOfStream)
                {
                    var obj = new T();
                    var values = reader.ReadLine().Split(separator).ToArray();

                    for (int i = 0; i < values.Length; i++)
                    {
                        properties[i].SetValue(obj, Convert.ChangeType(values[i], properties[i].PropertyType, provider), null);
                    }
                    objects.Add(obj);
                }
            }

            return objects;
        }

        private class StringFormatProvider : IFormatProvider
        {
            private CultureInfo _gbCultureInfo = CultureInfo.GetCultureInfo("en-GB");

            public object GetFormat(Type formatType)
            {
                if (formatType == typeof(NumberFormatInfo))
                    return _gbCultureInfo.GetFormat(formatType);
                return null;
            }
        }
    }
}
