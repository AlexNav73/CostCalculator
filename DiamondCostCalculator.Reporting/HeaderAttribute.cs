using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Reporting
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HeaderAttribute : Attribute
    {
        public int Order { get; set; }
        public string HeaderName { get; set; }

        public HeaderAttribute(string header, int order)
        {
            HeaderName = header;
            Order = order;
        }
    }
}
