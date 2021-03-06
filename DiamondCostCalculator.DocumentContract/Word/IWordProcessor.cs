﻿using DiamondCostCalculator.DocumentContract.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DocumentContract.Word
{
    public interface IWordProcessor : IDisposable
    {
        void Open(string fileName);
        void ApplyCommands(IDictionary<string, ICommand> commands);
        void Save();
    }
}
