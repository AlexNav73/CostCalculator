using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Documents.Word.Commands
{
    internal class CommandContext
    {
        private string[] _params;

        public CommandContext(IEnumerable<string> prms)
        {
            _params = prms.ToArray();
        }

        public T GetValue<T>(int index)
        {
            return (T)Convert.ChangeType(_params[index], typeof(T));
        }
    }
}
