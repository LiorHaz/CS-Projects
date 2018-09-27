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
namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1 = 0, num2 = 0;
        string operation = "", mathop = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Digit Butttons
        private void btn7_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "7";
                else
                {
                    num1 = (num1 * 10) + 7;
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "7";

                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "7";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "7";
                }
                else
                {
                    num2 = (num2 * 10) + 7;
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btn8_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "8";
                else
                {
                    num1 = (num1 * 10) + 8;
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "8";
                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "8";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "8";
                }
                else
                {
                    num2 = (num2 * 10) + 8;
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btn9_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "9";
                else
                {
                    num1 = (num1 * 10) + 9;
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "9";
                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "9";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "9";
                }
                else
                {
                    num2 = (num2 * 10) + 9;
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "4";
                else
                {
                    num1 = (num1 * 10) + 4;
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "4";
                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "4";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "4";
                }
                else
                {
                    num2 = (num2 * 10) + 4;
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "5";
                else
                {
                    num1 = (num1 * 10) + 5;
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "5";
                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "5";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "5";
                }
                else
                {
                    num2 = (num2 * 10) + 5;
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btn6_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "6";
                else
                {
                    num1 = (num1 * 10) + 6;
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "6";
                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "6";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "6";
                }
                else
                {
                    num2 = (num2 * 10) + 6;
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "1";
                else
                {
                    num1 = (num1 * 10) + 1;
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "1";
                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "1";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "1";
                }
                else
                {
                    num2 = (num2 * 10) + 1;
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "2";
                else
                {
                    num1 = (num1 * 10) + 2;
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "2";
                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "2";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "2";
                }
                else
                {
                    num2 = (num2 * 10) + 2;
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "3";
                else
                {
                    num1 = (num1 * 10) + 3;
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "3";
                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "3";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "3";
                }
                else
                {
                    num2 = (num2 * 10) + 3;
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btn0_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                if (txtDisplay.Text.Contains(".") || txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                    txtDisplay.Text += "0";
                else
                {
                    num1 = (num1 * 10);
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {
                if ((txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")) && txtDisplay.Text.Contains("."))
                    txtDisplay.Text += "0";
                else if (txtDisplay.Text.Contains(".") && !(txtDisplay.Text.Contains("sin") && !txtDisplay.Text.Contains("cos") && !txtDisplay.Text.Contains("tan") && !txtDisplay.Text.Contains("pow") && !txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "0";
                    num2 = Convert.ToDouble(txtDisplay.Text);
                }
                else if (!txtDisplay.Text.Contains(".") && (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log")))
                {
                    txtDisplay.Text += "0";
                }
                else
                {
                    num2 = (num2 * 10);
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        #endregion

        #region Operation Buttons+Point case 
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
            {
                if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '(') { MessageBox.Show("Illegal Value!"); return; }
                string[] number = txtDisplay.Text.Split('(');
                switch (mathop)
                {
                    case "sin":
                        num1 = Math.Sin(Convert.ToDouble(number[1]));
                        break;

                    case "cos":
                        num1 = Math.Cos(Convert.ToDouble(number[1]));
                        break;

                    case "tan":
                        num1 = Math.Tan(Convert.ToDouble(number[1]));
                        break;

                    case "log":
                        {
                            num1 = Math.Log(Convert.ToDouble(number[1]), 10);
                            if (Convert.ToDouble(number[1]) < 0) { MessageBox.Show("Illegal Value!"); return; }
                        }
                        break;


                    case "pow":
                        num1 = Math.Pow(Convert.ToDouble(number[1]), 2);
                        break;
                }
            }
            else
                num1 = Convert.ToDouble(txtDisplay.Text);

            operation = "+";
            txtDisplay.Text = operation.ToString();

        }
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '(') { MessageBox.Show("Illegal Value!"); return; }
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
            {
                string[] number = txtDisplay.Text.Split('(');
                switch (mathop)
                {
                    case "sin":
                        num1 = Math.Sin(Convert.ToDouble(number[1]));
                        break;

                    case "cos":
                        num1 = Math.Cos(Convert.ToDouble(number[1]));
                        break;

                    case "tan":
                        num1 = Math.Tan(Convert.ToDouble(number[1]));
                        break;

                    case "log":
                        {
                            num1 = Math.Log(Convert.ToDouble(number[1]), 10);
                            if (Convert.ToDouble(number[1]) < 0) { MessageBox.Show("Illegal Value!"); return; }
                        }
                        break;


                    case "pow":
                        num1 = Math.Pow(Convert.ToDouble(number[1]), 2);
                        break;
                }
            }
            else
                num1 = Convert.ToDouble(txtDisplay.Text);
            operation = "-";
            txtDisplay.Text = "0";
        }
        private void btnTimes_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '(') { MessageBox.Show("Illegal Value!"); return; }
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
            {
                string[] number = txtDisplay.Text.Split('(');
                switch (mathop)
                {
                    case "sin":
                        num1 = Math.Sin(Convert.ToDouble(number[1]));
                        break;

                    case "cos":
                        num1 = Math.Cos(Convert.ToDouble(number[1]));
                        break;

                    case "tan":
                        num1 = Math.Tan(Convert.ToDouble(number[1]));
                        break;

                    case "log":
                        {
                            num1 = Math.Log(Convert.ToDouble(number[1]), 10);
                            if (Convert.ToDouble(number[1]) < 0) { MessageBox.Show("Illegal Value!"); return; }
                        }
                        break;


                    case "pow":
                        num1 = Math.Pow(Convert.ToDouble(number[1]), 2);
                        break;
                }
            }
            else
                num1 = Convert.ToDouble(txtDisplay.Text);
            operation = "*";
            txtDisplay.Text = "0";
        }
        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '(') { MessageBox.Show("Illegal Value!"); return; }
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
            {
                string[] number = txtDisplay.Text.Split('(');
                switch (mathop)
                {
                    case "sin":
                        num1 = Math.Sin(Convert.ToDouble(number[1]));
                        break;

                    case "cos":
                        num1 = Math.Cos(Convert.ToDouble(number[1]));
                        break;

                    case "tan":
                        num1 = Math.Tan(Convert.ToDouble(number[1]));
                        break;
                    case "log":
                        {
                            num1 = Math.Log(Convert.ToDouble(number[1]), 10);
                            if (Convert.ToDouble(number[1]) < 0) { MessageBox.Show("Illegal Value!"); return; }
                        }
                        break;


                    case "pow":
                        num1 = Math.Pow(Convert.ToDouble(number[1]), 2);
                        break;
                }
            }
            else
                num1 = Convert.ToDouble(txtDisplay.Text);
            operation = "/";
            txtDisplay.Text = "0";
        }
        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                {
                    if (txtDisplay.Text.Contains("."))
                        return;
                    else txtDisplay.Text += ".";
                }

                else if (txtDisplay.Text.Contains("."))
                    return;

                else txtDisplay.Text = num1.ToString() + ".";
            }
            else
            {
                if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                {
                    if (txtDisplay.Text.Contains("."))
                        return;
                    else txtDisplay.Text += ".";
                }
                else if (txtDisplay.Text.Contains("."))
                    return;
                else txtDisplay.Text = num2.ToString() + ".";
            }
        }
        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '(') { MessageBox.Show("Illegal Value!"); return; }
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
            {
               
                string[] number = txtDisplay.Text.Split('(');
                string str = number[1];
                if(txtDisplay.Text[txtDisplay.Text.Length - 1] == ')')
                    number[1]=number[1].Remove(number[1].Length - 1);
                
                switch (mathop)
                {
                    case "sin":
                        num2 = Math.Sin(Convert.ToDouble(number[1]));
                        break;

                    case "cos":
                        num2 = Math.Cos(Convert.ToDouble(number[1]));
                        break;

                    case "tan":
                        num2 = Math.Tan(Convert.ToDouble(number[1]));
                        break;

                    case "log":
                        {
                            num2 = Math.Log(Convert.ToDouble(number[1]), 10);
                            if (Convert.ToDouble(number[1]) < 0) { MessageBox.Show("Illegal Value!"); return; }
                        }
                        break;

                    case "pow":
                        num2 = Math.Pow(Convert.ToDouble(number[1]), 2);
                        break;
                }
                txtDisplay.Text += ")";

            }
            else
                num2 = Convert.ToDouble(txtDisplay.Text = num2.ToString());
            switch (operation)
            {
                case "+":
                    {
                        txtDisplay.Text = (num1 + num2).ToString();
                        num1 += num2;
                        num2 = 0;
                    }
                    break;
                case "-":
                    {
                        txtDisplay.Text = (num1 - num2).ToString();
                        num1 -= num2;
                        num2 = 0;
                    }
                    break;
                case "*":
                    {
                        txtDisplay.Text = (num1 * num2).ToString();
                        num1 *= num2;
                        num2 = 0;
                    }
                    break;
                case "/":
                    {
                        if (num2 == 0) { MessageBox.Show("Error- Dividing by zero"); return; }
                        else txtDisplay.Text = (num1 / num2).ToString();
                        num1 /= num2;
                        num2 = 0;
                    }
                    break;
            }

        }
        private void btnSin_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                return;
            mathop = "sin";
            txtDisplay.Text = "sin(";

        }
        private void btnCosin_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                return;
            mathop = "cos";
            txtDisplay.Text = "cos(";

        }

        private void btnTan_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                return;
            mathop = "tan";
            txtDisplay.Text = "tan(";
        }

        private void btnlog_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                return;
            mathop = "log";
            txtDisplay.Text = "log(";
        }

        private void btnPow_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                return;
            mathop = "pow";
            txtDisplay.Text = "pow(";
        }

        #endregion

        #region Clear Buttons+Point case
        private void btnClearEntry_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
                num1 = 0;
            else
                num2 = 0;
            txtDisplay.Text = "0";
            mathop = "";
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            operation = "";
            mathop = "";
            num1 = num2 = 0;
            txtDisplay.Text = "0";

        }
        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                {
                    if (txtDisplay.Text[txtDisplay.Text.Length - 2] == '(')
                        txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                    else if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '(') { txtDisplay.Text = "0"; }
                    else txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                }
                else if (txtDisplay.Text.Contains("."))
                {
                    if (txtDisplay.Text[txtDisplay.Text.Length - 2] == '.')
                    {
                        txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                        txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                    }
                    else
                        txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                }
                else
                {
                    num1 = Math.Floor(num1 / 10);
                    txtDisplay.Text = num1.ToString();
                }
            }
            else
            {

                if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
                {
                    if (txtDisplay.Text[txtDisplay.Text.Length - 2] == '(')
                        txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                    else if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '(') { txtDisplay.Text = "0"; }
                    else txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                }
                else if (txtDisplay.Text.Contains("."))
                {
                    if (txtDisplay.Text[txtDisplay.Text.Length - 2] == '.')
                    {
                        txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                        txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                    }
                    else
                        txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                }
                else
                {
                    num2 = Math.Floor(num2 / 10);
                    txtDisplay.Text = num2.ToString();
                }
            }
        }
        private void btnPositiveNegative_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Contains("sin") || txtDisplay.Text.Contains("cos") || txtDisplay.Text.Contains("tan") || txtDisplay.Text.Contains("pow") || txtDisplay.Text.Contains("log"))
            { MessageBox.Show("Error-number is not valid"); return; }
            else if (operation == "")
            {
                num1 *= -1;
                txtDisplay.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                txtDisplay.Text = num2.ToString();
            }
        }
        #endregion


    }
}
