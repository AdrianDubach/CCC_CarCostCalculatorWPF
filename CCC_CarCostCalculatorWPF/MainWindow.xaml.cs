using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
/*Tanke bakom programmet och dess syfte: Jag har tänkt mig att detta program är bestält av ett taxi företag. Kravpsecifikationen är att programmet ska  
 räkna ut vad kostnaden/sträcka som körs. Sträckan är i miles och kostnaderna består av Gas, Service, Tax och Extra. Svaret ska läggas i en lista där
 ett flertal bilar ska kunna läggas in. I listan ska även bilens id nummer och transport typ visas. */
namespace CCC_CarCostCalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {//variabler som används i main koden.
        private int carNr;
        private int carChecker;
        private double milesVal;
        private double gasCostVal = 0;
        private double serviceCostVal;
        private double taxCostVal;
        private double extraCostVal;
        private double result;
        private string carID;
        private string miles;
        private string gasCost;
        private string serviceCost;
        private string taxCost;
        private string extraCost;
        private string cabType;
        private string errorMessage;

        public MainWindow()
        {//constructor
            InitializeComponent();
            {
                carNr = 0;
                carChecker = 0;
                milesVal = 0;
                gasCostVal = 0;
                serviceCostVal = 0;
                taxCostVal = 0;
                extraCostVal = 0;
                result = 0;
                carID = null;
                miles = null;
                gasCost = null;
                serviceCost = null;
                taxCost = null;
                extraCost = null;
                cabType = null;
                errorMessage = null;
            }
        }
        //carID boxen representerar Bilens identifikation. Om företaget använder ID nummer eller bil typ t.ex. ID num: 12232 eller Volvo etc.
        private void CarID_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            carID = CarID_TextBox.Text;
        }
        //Miles boxen sätter string value på miles variabeln till det som skrivs in.
        private void Miles_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            miles = Miles_TextBox.Text;
        }
        //GasCost boxen sätter string value på gasCost variabeln till det som skrivs in.
        private void GasCost_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            gasCost = GasCost_TextBox.Text;
        }
        //TaxCost boxen sätter string value på TaxCost variabeln till det som skrivs in.
        private void TaxCost_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            taxCost = TaxCost_TextBox.Text;
        }
        //ServiceCost boxen sätter string value på serviceCost variabeln till det som skrivs in.
        private void ServiceCost_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            serviceCost = ServiceCost_TextBox.Text;
        }
        //ExtraCost boxen sätter string value på extraCost variabeln till det som skrivs in.
        private void ExtraCost_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            extraCost = ExtraCost_TextBox.Text;
        }
        // Result boxen tilldelas senare i koden ett värde som matas in.
        private void Result_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        { }
        /*Combine button knappen kallar på en rad metoder för att omvandla ett antal string variabler till double variabler.
         Den kollar även att viktiga uppgifter så som bil nummer, bil id och bil typ existerar och skriver ett meddelande om de ej finns.
         Sist använder den sig av en metod som räknar ut resultatet av miles/cost.*/
        public void Combine_Button_Click(object sender, RoutedEventArgs e)
        {
            /*Skickar till en hjälpmetod som tryparsar stringen som används som argument. 
             *Om inget värde blivit utvunnet skrivs ett felmeddelande som hänvisar till den boxen som innehöll det felaktiga värdet och värdet rensas.
             Detta sker för varje TextBox som ska omvandlas.*/
            if (!TryParseMethod.Parser(miles, out milesVal))
            {
                Miles_TextBox.Clear();
                MessageBox.Show("Miles driven was not entered or not entered properly.");
            }
            if (!TryParseMethod.Parser(gasCost, out gasCostVal))
            {
                GasCost_TextBox.Clear();
                MessageBox.Show("Gas cost was not entered or not entered properly.");
            }
            if (!TryParseMethod.Parser(serviceCost, out serviceCostVal))
            {
                ServiceCost_TextBox.Clear();
                MessageBox.Show("Service cost was not entered or not entered properly.");
            }
            if (!TryParseMethod.Parser(taxCost, out taxCostVal))
            {
                TaxCost_TextBox.Clear();
                MessageBox.Show("Tax cost was not entered or not entered properly.");
            }
            if (!TryParseMethod.Parser(extraCost, out extraCostVal))
            {
                ExtraCost_TextBox.Clear();
                MessageBox.Show("Extra cost was not entered or not entered properly.");
            }
            //Nedstående if satserna kontrollerar att värden tilldelats BilID, Bil typ och Bil nummer
            if (carID == null)
                MessageBox.Show("No id Given(!)");
            if (cabType == null)
                MessageBox.Show("No Type Given(!)");
            if ((carNr == carChecker) == true)
                MessageBox.Show("You must select a new car(!)");
            /*Kallar på metoden Combineresult i klassen CarMilesCalculator. Beskrivning på funktion finns i klassen. 
             *Return värdet från metoden sätter ett värde på result variabeln.*/
            result = CarMilesCalculator.CombineResult(milesVal, gasCostVal, serviceCostVal, taxCostVal, extraCostVal);
            //result variabeln matas in i Result Boxen.
            Result_TextBox.Text = string.Format("{0:N2}", result);


        }
        /*Print knappen printar ut, om allt gått som det ska, uppgifterna om bilen till en ListBox som heter Car_List.
         *Om något värde saknas eller är felaktigt så skrivs ett errorMessage ut som förklarar vad som har gått fel. */
        public void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            /*Error meddelande funktioner av olika slag som kontrollerar att de vitala uppgifterna är tilldelade. 
             *Om ett fel hittats tillges errorMessage stringen ett felmeddelande som värde.*/
            if (carID == null)
                errorMessage = "No id Given(!)";
            if (cabType == null)
                errorMessage = "No Type Given(!)";
            if ((carNr == carChecker) == true)
                errorMessage = "You must select a new car(!)";
            if (Result_TextBox.Text == "NaN" || result == 0)
                errorMessage = "No costs were calculated";
            if (result > 10000000000000)
                errorMessage = "Calculation error.";
            // om errorMessage stringen inte tillgivits något värde kommer ett struct objekt som heter AddCar läggas till i ListBoxen
            if (errorMessage == null)
            {/*Skapar ett objekt av en struct som finns i CarConstuctor klassen. 
                Structen har en constructor som använder sig av argumenten Bil typen, BilID, resultatet från Combine knappen och bilnumret.*/
                CarConstructor.CarStruct AddCar = new CarConstructor.CarStruct(cabType, carID, result, carNr);
                //använder en metod som också finns i CarConstructor. Använder Stuct Objektet som argument.
                Car_List.Items.Add(CarConstructor.CarStruct.CarReturner(AddCar));
                /*Sätter värdet på carChecker variabeln till värdet på carNr. 
                 *Detta används så att man ej kan ange ett bilnummer som överstiger existerande bilnummer +1*/
                carChecker = carNr;
                //Kallar på en clear metod som rensar alla värden som använts. Se längst ner.
                ClearAll();
            }
            //Om errorMessage stringen har ett värde skrivs det ut och sätts sen till null.
            else
            {
                MessageBox.Show(errorMessage);
                errorMessage = null;
            }
        }
        //Lägger till ett nytt bilnummer som ej kan överstiga existerande antal +1. Detta matas sen in i bilnummer rutan
        private void NewCar_Button_Click(object sender, RoutedEventArgs e)
        {
            carNr = carChecker + 1;
            Car_Number.Text = carNr.ToString();
        }
        //Car_List är den listan som printknappen skickar giltig information till.
        private void Car_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        //exit knapp som stänger ner fönstret.
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //En checkbox som tilldelar biltyp och som kollar att inte andra biltypsboxar är ikryssade.
        private void WheelChair_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)WheelChair_CheckBox.IsChecked == true && RegularCab_CheckBox.IsChecked == false && Bus_CheckBox.IsChecked == false)
                cabType = "Wheelchair";
            //om en annan box är ikryssad så skrivs ett felmeddelande och boxen avmarkeras.
            else
            {
                MessageBox.Show("Kan ej använda flera Typer");
                WheelChair_CheckBox.IsChecked = false;
            }
        }
        //En checkbox som tilldelar biltyp och som kollar att inte andra biltypsboxar är ikryssade.
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)RegularCab_CheckBox.IsChecked == true && WheelChair_CheckBox.IsChecked == false && Bus_CheckBox.IsChecked == false)
            {
                cabType = "Regular";
            }
            //om en annan box är ikryssad så skrivs ett felmeddelande och boxen avmarkeras.
            else
            {
                MessageBox.Show("Kan ej använda flera Typer");
                RegularCab_CheckBox.IsChecked = false;
            }
        }
        //En checkbox som tilldelar biltyp och som kollar att inte andra biltypsboxar är ikryssade.
        private void Bus_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)Bus_CheckBox.IsChecked == true && RegularCab_CheckBox.IsChecked == false && WheelChair_CheckBox.IsChecked == false)
            { cabType = "Bus"; }
            //om en annan box är ikryssad så skrivs ett felmeddelande och boxen avmarkeras.
            else
            {
                MessageBox.Show("Kan ej använda flera Typer");
                Bus_CheckBox.IsChecked = false;
            }
        }
        //denna textbox innehåller carNr variabeln.
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {}
        //clearfunktion som rensar alla värden när en bil lagts till i listan
        private void ClearAll()
        {
            carID = null;
            cabType = null;
            milesVal = 0;
            gasCostVal = 0;
            serviceCostVal = 0;
            taxCostVal = 0;
            extraCostVal = 0;
            result = 0;
            CarID_TextBox.Clear();
            Miles_TextBox.Clear();
            GasCost_TextBox.Clear();
            ServiceCost_TextBox.Clear();
            TaxCost_TextBox.Clear();
            ExtraCost_TextBox.Clear();
            Result_TextBox.Clear();
            RegularCab_CheckBox.IsChecked = false;
            Bus_CheckBox.IsChecked = false;
            WheelChair_CheckBox.IsChecked = false;
        }
    }
}
