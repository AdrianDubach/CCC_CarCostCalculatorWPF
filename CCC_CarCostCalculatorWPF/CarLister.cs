using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC_CarCostCalculatorWPF
{
    public class CarLister
    {
        //private int carNr;
        //private int carChecker;
        //private double milesVal;
        //private double gasCostVal;
        //private double serviceCostVal;
        //private double taxCostVal;
        //private double extraCostVal;
        //private double result;
        //private string carID;
        //private string miles;
        //private string gasCost;
        //private string serviceCost;
        //private string taxCost;
        //private string extraCost;
        //private string cabType;
        //private string arrayResult;
        //private string errorMessage;

        //public CarLister()
        //{
        //    carNr = 0;
        //    carChecker = 0;
        //    milesVal = 0;
        //    gasCostVal = 0;
        //    serviceCostVal = 0;
        //    taxCostVal = 0;
        //    extraCostVal = 0;
        //    result = 0;
        //    carID = null;
        //    miles = null;
        //    gasCost = null;
        //    serviceCost = null;
        //    taxCost = null;
        //    extraCost = null;
        //    cabType = null;
        //    arrayResult = null;
        //    errorMessage = null;

        //}
        public static double CombineResult(double miles, double gasCostVal, double serviceCostVal, double taxCostVal, double extraCostVal)
        {
            double result = (gasCostVal + serviceCostVal + taxCostVal + extraCostVal)/miles;

            return result;
        }
    }
}
