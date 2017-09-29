using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC_CarCostCalculatorWPF
{




    class CarConstructor
    {
        // en struct som innehåller 4 värden i form av bil typ, bil id, kostnad/mile och bil nr.
        internal struct CarStruct
        {
            private string _carType;
            private string _carID;
            private double _costPerMile;
            private int _carNr;

            //Struct constructor som tar emot 4 argument som sen tilldelar argument värdena till värdena i structen
            public CarStruct(string carType, string carID, double costPerMile, int carNr)
            {

                this._carType = carType;
                this._carID = carID;
                this._costPerMile = costPerMile;
                this._carNr = carNr;
            }
            //tar emot en CarStruct som argument och matar ut de värden som structen innehåller till en string som den sedan returnerar
            public static string CarReturner(CarStruct Car)
            {//Stringen som returneras.
                return string.Format("Car Number: " + Car._carNr + " Car ID: " + Car._carID + " Cab Type: " + Car._carType + " Cost Per Mile: {0:N2}", Car._costPerMile);
            }
        };

    }
}

