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

namespace CCC_CarCostCalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int carNr;
        private int carChecker;
        private double milesVal;
        private double gasCostVal;
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
        private string arrayResult;
        private string errorMessage;
        




        public MainWindow()
        {
            InitializeComponent();
            { }
            
        }

        private void CarID_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            carID = CarID_TextBox.Text;

        }

        private void Miles_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            miles = Miles_TextBox.Text;
        }

        private void GasCost_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            gasCost = GasCost_TextBox.Text;
        }

        private void TaxCost_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            taxCost = TaxCost_TextBox.Text;
        }

        private void ServiceCost_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            serviceCost = ServiceCost_TextBox.Text;
        }

        private void ExtraCost_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            extraCost = ExtraCost_TextBox.Text;
        }

        private void Result_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        public void Combine_Button_Click(object sender, RoutedEventArgs e)
        {


            if(!TryParseMethod.Parser(miles, out milesVal))
                Miles_TextBox.Clear();
            MessageBox.Show("Du har inte angivit ett korrekt värde.");

            gasCostVal = TryParseMethod.Parser(gasCost);
            serviceCostVal = TryParseMethod.Parser(serviceCost);
            taxCostVal = TryParseMethod.Parser(taxCost);
            extraCostVal = TryParseMethod.Parser(extraCost);

            result = CarLister.CombineResult(milesVal, gasCostVal, serviceCostVal, taxCostVal, extraCostVal);
            Result_TextBox.Text = string.Format("{0:N2}", result);
            

        }

        public void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (carID == null)
                errorMessage = "No id Given(!)";
            if (cabType == null)
                errorMessage = "No Type Given(!)";
            if ((carNr == carChecker) == true)
                errorMessage = "You must select a new car(!)";

            if (errorMessage == null)
            {
                arrayResult = CarArray.Array(carID, cabType, result, carNr);
                Car_List.Items.Add(arrayResult);
                carChecker = carNr;
                ClearAll();
            }
            else
            {
                Car_List.Items.Add(errorMessage);
                errorMessage = null;
            }
            

        }

        private void NewCar_Button_Click(object sender, RoutedEventArgs e)
        {
            carNr++;

            Car_Number.Text = carNr.ToString();
        }

        private void Car_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void WheelChair_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)WheelChair_CheckBox.IsChecked == true)
                cabType = "Wheelchair";
            else
             cabType = null;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)RegularCab_CheckBox.IsChecked == true)
            { cabType = "Regular"; }
            else cabType = null;
        }

        private void Bus_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)Bus_CheckBox.IsChecked == true)
            { cabType = "Bus"; }
            else cabType = null;
        }
        private void ClearAll()
        {
            carID = null;
            cabType = null;
            arrayResult = null;
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
