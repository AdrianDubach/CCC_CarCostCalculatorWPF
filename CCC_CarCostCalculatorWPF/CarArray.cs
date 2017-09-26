using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC_CarCostCalculatorWPF
{




    class CarArray
    {
        private const int MAX_CARS= 20;
        //private static double costPerMile;
        //private static string carID;
        //private static string carType;
        //private static int newCar;
        struct CarArrayStruct
        {
           public string carType;
           public string carID;
           public double costPerMile;

        
        };


        public CarArray()
        {
            //    newCar = NewCar;
            //    carType = CarType;
            //    carID = CarID;
            ////    costPerMile = CostPerMile;
            //CarArrayStruct[] carPosition;
            //carPosition = new CarArrayStruct[20];
       
        }
        public static string Array(string CarID, string CabType, double Result, int CarNr)
        {
            CarArrayStruct[] carPosition;
            carPosition = new CarArrayStruct[20];
            carPosition[CarNr].costPerMile = Result;
            carPosition[CarNr].carID = CarID;
            carPosition[CarNr].carType = CabType;


            return string.Format("Car nr: " + CarNr + " Car: " + carPosition[CarNr].carID + " Type: " + carPosition[CarNr].carType + " Cost/Mile: {0:N2}", carPosition[CarNr].costPerMile);


        }

    }
}
