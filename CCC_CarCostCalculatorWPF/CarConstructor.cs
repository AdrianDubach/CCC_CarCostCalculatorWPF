using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC_CarCostCalculatorWPF
{




    class CarConstructor
    {
        //private const int MAX_CARS= 20;
        //private static double costPerMile;
        //private static string carID;
        //private static string carType;
        //private static int newCar;
        internal struct CarStruct
        {
            private string _carType;
            private string _carID;
            private double _costPerMile;
            private int _carNr;

            public CarStruct(string carType, string carID, double costPerMile, int carNr)
            {

                this._carType = carType;
                this._carID = carID;
                this._costPerMile = costPerMile;
                this._carNr = carNr;
            }
            public static string CarReturner(CarStruct Car)
            {
                return string.Format("Car Number: " +Car._carNr +" Car ID: "+Car._carID +" Cab Type: "+Car._carType+ " Cost Per Mile: {0:N2}", Car._costPerMile);
            }
        };




    //public CarConstructor(string CarID, string CabType, double Result, int CarNr)
    //{

    //    newCar = NewCar;
    //    carType = CarType;
    //    carID = CarID;
    ////    costPerMile = CostPerMile;
    //CarArrayStruct[] carPosition;
    //carPosition = new CarArrayStruct[20];

}
}
    //public static string Array(string CarID, string CabType, double Result, int CarNr)
    //{
    //    CarArrayStruct[] carPosition = new CarArrayStruct[20];
    //    //carPosition = new CarArrayStruct[20];
    //    carPosition[CarNr].costPerMile = Result;
    //    carPosition[CarNr].carID = CarID;
    //    carPosition[CarNr].carType = CabType;


    //return string.Format("Car nr: " + CarNr + " Car: " + carPosition[CarNr].carID + " Type: " + carPosition[CarNr].carType + " Cost/Mile: {0:N2}", carPosition[CarNr].costPerMile);


    //}

//}
//}
