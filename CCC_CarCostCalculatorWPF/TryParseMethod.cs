using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC_CarCostCalculatorWPF
{
    class TryParseMethod
    {
        public static bool Parser(string stringToParse, out double result)
        {
            bool text;
            text = double.TryParse(stringToParse, out result);
            if (!text)
                return false;

            return true;



                //return result;
        }
    }
}
