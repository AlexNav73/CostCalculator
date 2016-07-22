using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.Documents.Word.Commands
{
    internal interface ICommand
    {
        CommandContext Context { set; }
        void Execute();
    }
}
