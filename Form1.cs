using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{

    public partial class Form1 : Form
    {
        bool equalsButtonClicked = false;
        double originalNumber = 0;
        string operationType;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CalculatorLabel_Click(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text = string.Empty;
        }

        private void DisplayNumbersTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string text = DisplayNumbersTextBox.Text;
            int length = text.Length;
            if (length > 0) text = text.Remove(text.Length - 1); // Removes last number / letter

            DisplayNumbersTextBox.Text = text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "1";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "3";
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "0";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "7";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += "9";
        }

        private void ExitButton(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            EqualClicked();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.D0:
                    DisplayNumbersTextBox.Text += "0";
                    break;

                case Keys.D1:
                    DisplayNumbersTextBox.Text += "1";
                    break;

                case Keys.D2:
                    DisplayNumbersTextBox.Text += "2";
                    break;

                case Keys.D3:
                    DisplayNumbersTextBox.Text += "3";
                    break;

                case Keys.D4:
                    DisplayNumbersTextBox.Text += "4";
                    break;

                case Keys.D5:
                    DisplayNumbersTextBox.Text += "5";
                    break;

                case Keys.D6:

                    if (e.Shift)
                    {
                        PowerClicked();
                    }
                    else DisplayNumbersTextBox.Text += "6";
                    break;

                case Keys.D7:
                    DisplayNumbersTextBox.Text += "7";
                    break;

                case Keys.D8:
                    
                    if (e.Shift) MultiplyClicked(); // If holding shift and 8 then that is * so multiply
                    
                    else DisplayNumbersTextBox.Text += "8";
                    break;

                case Keys.D9:
                    DisplayNumbersTextBox.Text += "9";
                    break;

                case Keys.OemPeriod:
                    DisplayNumbersTextBox.Text += ".";
                    break;

                case Keys.X:
                    MultiplyClicked();
                    break;

                case Keys.OemMinus:
                    MinusClicked();
                    break;

                case Keys.Oemplus:
                    if (e.Shift) PlusClicked();
                    break;

                case Keys.OemQuestion:
                    DivisionClicked();
                    break;

                case Keys.Back:
                    BackClicked();
                    break;

                default:
                    break;
            }
        }

        private void AdditionButton_Click(object sender, EventArgs e)
        {
            PlusClicked();
        }

        private void SubtractionButton_Click(object sender, EventArgs e)
        {
            MinusClicked();
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            DivisionClicked();
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            MultiplyClicked();
        }
        private string CleanString(string input)
        {
            char[] operations = { '+', '-', '/', 'x','√', '^'};

            int indexOfOperation = input.IndexOfAny(operations);

            if (indexOfOperation != -1) // -1 = no operations present in input
            {
                input = input.Substring(indexOfOperation +1); // Removes characters before operation
            }
            return input;
        }

        private void EqualClicked()
        {
            string text = DisplayNumbersTextBox.Text;
            text = CleanString(text);

            //text = Regex.Replace(text, "[+\\-/x]", ""); // Replaces +\-x characters the [] and \\ had to be used as many of those symbols have a specific purpose in regex
            double answer = 0;

            try 
            {
                double newNumbers = Convert.ToDouble(text);

                switch (operationType)
                {
                    case "addition":
                        answer = originalNumber + newNumbers;
                        break;

                    case "subtraction":
                        answer = originalNumber - newNumbers;
                        break;

                    case "multiplication":
                        answer = originalNumber * newNumbers;
                        break;

                    case "division":
                        answer = originalNumber / newNumbers;
                        break;
                    case "squareRoot":
                        answer = Math.Sqrt(newNumbers);
                        break;
                    case "exponent":
                        answer = Math.Pow(originalNumber, newNumbers);
                        break;
                }
                DisplayNumbersTextBox.Text = answer.ToString();
            }
            catch
            {
                DisplayNumbersTextBox.Text = "😡😡😡";
            }
        }

        private void MultiplyClicked()
        {
            string text = DisplayNumbersTextBox.Text;
            DisplayNumbersTextBox.Text += "x";

            try
            {
                originalNumber = Convert.ToDouble(text);
                operationType = "multiplication";
            }
            catch
            {
                DisplayNumbersTextBox.Text = "😡😡😡";
            }
        }

        private void DivisionClicked()
        {
            string text = DisplayNumbersTextBox.Text;
            DisplayNumbersTextBox.Text += "/";

            try
            {
                originalNumber = Convert.ToDouble(text);
                operationType = "division";
            }
            catch
            {
                DisplayNumbersTextBox.Text = "😡😡😡";
            }
        }

        private void BackClicked()
        {
            string text = DisplayNumbersTextBox.Text;
            int length = text.Length;
            if (length > 0) text = text.Remove(text.Length - 1); // Removes last number / letter
            DisplayNumbersTextBox.Text = text;
        }

        private void PlusClicked()
        {
            string text = DisplayNumbersTextBox.Text;
            DisplayNumbersTextBox.Text += "+";

            try
            {
                originalNumber = Convert.ToDouble(text);
                operationType = "addition";
            }
            catch
            {
                DisplayNumbersTextBox.Text = "😡😡😡";
            }
        }

        private void MinusClicked()
        {
            string text = DisplayNumbersTextBox.Text;
            DisplayNumbersTextBox.Text += "-";

            try
            {
                originalNumber = Convert.ToDouble(text);
                operationType = "subtraction";
            }
            catch
            {
                DisplayNumbersTextBox.Text = "😡😡😡";
            }
        }

        private void guna2CircleButton16_Click(object sender, EventArgs e)
        {
            DisplayNumbersTextBox.Text += ".";
        }

        private void RootButton_Click(object sender, EventArgs e)
        {
            string text = DisplayNumbersTextBox.Text;
            DisplayNumbersTextBox.Text = "√";
            
            operationType = "squareRoot";
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            PowerClicked();
        }

        private void PowerClicked()
        {
            string text = DisplayNumbersTextBox.Text;
            DisplayNumbersTextBox.Text += "^";

            try
            {
                originalNumber = Convert.ToDouble(text);
                operationType = "exponent";
            }
            catch
            {
                DisplayNumbersTextBox.Text = "😡😡😡";
            }
        }
    }
}