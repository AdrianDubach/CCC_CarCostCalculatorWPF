using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC_CarCostCalculatorWPF
{
    public class CarMilesCalculator
    {
        //En uträknings metod som använder sig av de argumenten som givits för att utvinna ett resultat som den sedan returnerar.
        public static double CombineResult(double miles, double gasCostVal, double serviceCostVal, double taxCostVal, double extraCostVal)
        {
            //Här är ekvationen som plussar ihop alla värden förutom miles, som den använder för att dela de ihoplagda talen. Svaret blir variabeln result.
            double result = (gasCostVal + serviceCostVal + taxCostVal + extraCostVal)/miles;
            //returnerar result.
            return result;
        }
    }
}
