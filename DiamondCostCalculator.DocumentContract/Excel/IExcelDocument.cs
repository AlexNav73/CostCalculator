﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCostCalculator.DocumentContract.Excel
{
    public interface IExcelDocument : IDisposable
    {
        void Open(string filePath);
        DataTable ReadFirstSheet();
        void Close();
    }
}
