using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCalculadora
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
            OnClear(new object(), new EventArgs());
        }

        private void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string pressed = btn.Text;

            if(this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if(currentState < 0)
                    currentState *= -1;
            }

            this.resultText.Text += pressed;

            double number;
            if(double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if(currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button btn = (Button)sender;
            string pressed = btn.Text;
            mathOperator = pressed;
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if(currentState == 2)
            {
                double result = 0;
                if(mathOperator == "+")
                {
                    result = firstNumber + secondNumber;
                }

                if (mathOperator == "-")
                {
                    result = firstNumber - secondNumber;
                }

                if (mathOperator == "X")
                {
                    result = firstNumber * secondNumber;
                }

                if (mathOperator == "/")
                {
                    result = firstNumber / secondNumber;
                }

                this.resultText.Text = result.ToString("N0");
                firstNumber = result;
                currentState = -1;
            }
        }
    }
}
