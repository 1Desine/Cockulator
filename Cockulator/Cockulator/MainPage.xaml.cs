using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cockulator
{
    public partial class MainPage : ContentPage
    {
        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked;




        public MainPage()
        {
            InitializeComponent();
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "1";
        }
        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (LblResult.Text == "0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                LblResult.Text = button.Text;
            }
            else
            {
                LblResult.Text += button.Text;
            }
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "0";
                isOperatorClicked = false;
            firstNumber = 0;
        }

        private void BtnBackspace_Clicked(object sender, EventArgs e)
        {
            string number = LblResult.Text;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";
                }
                else
                {
                    LblResult.Text = number;
                }
            }
        }

        private void BtnCommonOperator_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(LblResult.Text);
        }

        private async void BtnPercentage_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = LblResult.Text;
                if (number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (Convert.ToDecimal(number) / 100).ToString("0.##");
                    LblResult.Text = result;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("I shitted myself", ex.Message, "fuck");
            }
        }

        private void BtnEqual_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(LblResult.Text);
                string finalResult = Calcualte(firstNumber, secondNumber).ToString("0.##");
                LblResult.Text = finalResult;
            }
            catch (Exception ex)
            {
                DisplayAlert("I shitted myself", ex.Message, "fuck");
            }
        }
        private decimal Calcualte(decimal firstNumber, decimal secondNumber)
        {
            switch (operatorName)
            {
                case "+": return firstNumber + secondNumber;
                case "-": return firstNumber - secondNumber;
                case "*": return firstNumber * secondNumber;
                case "/": return firstNumber / secondNumber;
                default: return 0;
            }
        }
    }
}
