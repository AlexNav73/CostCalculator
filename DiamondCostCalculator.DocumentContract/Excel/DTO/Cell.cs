using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentContract.Excel.DTO
{
    public struct Cell
    {
        object _value;

        public Cell(object value)
        {
            _value = value;
        }

        public T Unwrap<T>()
        {
            var type = _value.GetType();
            if (_value is T) return (T)_value;
            throw new InvalidCastException();
        }
    }
}
