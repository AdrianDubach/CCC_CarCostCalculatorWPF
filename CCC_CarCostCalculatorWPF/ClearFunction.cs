using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC_CarCostCalculatorWPF
{
    class ClearFunction
    {
        public string ClearText(string clearText)
        {
            clearText = null;

            return clearText;
        }
        public double ClearValue(double clearValue)
        {
            clearValue = 0;
            return clearValue;
        }
    }
}
