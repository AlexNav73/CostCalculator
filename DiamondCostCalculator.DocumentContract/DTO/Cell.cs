using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentContract.DTO
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
            if (_value is T) return (T)_value;
            throw new InvalidCastException();
        }
    }
}
