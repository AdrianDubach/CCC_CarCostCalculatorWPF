using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC_CarCostCalculatorWPF
{
    class TryParseMethod
    {/* en metod som tryparsear den string som givits som argument. 
        En bool kontrollerar att parsen fungerat och returnerar en bool som är sann eller falsk. Om sant så skickas doublen tillbaka och returneras via out
        funktionen*/
        public static bool Parser(string stringToParse, out double result)
        {
            bool ParseResult;
            ParseResult = double.TryParse(stringToParse, out result);
            if (!ParseResult)
                return false;

            return true;
        }
    }
}
