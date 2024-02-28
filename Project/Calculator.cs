using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project.TempApp;

namespace Project
{
    public partial class Calculator : Form
    {
        internal class Calc
        {
            private decimal currentValue; //A decimal that stores the result currently displayed by the calculator.
            private decimal operand1; // A decimal that stores the value of the first operand.
            private decimal operand2;// A decimal that stores the value of the second operand
            private string op = null; //A string type that stores the value of the operator

            public Calc() {  }

            public Calc (decimal currentValue)
            {
                this.CurrentValue = currentValue;
              
            }

            public decimal CurrentValue
            {
                get
                { return currentValue; }
                set
                { currentValue = value; }
            }
            

            public void Add(decimal displayValue)
            {
                operand1 = displayValue;
                currentValue = operand1;
                op = "+";
                
            }

            public string Subtract(decimal displayValue)
            {
                operand1 = displayValue;
                currentValue = operand1;
                op = "-";
                return op;
            }

            public string Multiply(decimal displayValue)
            {
                operand1 = displayValue;
                currentValue = operand1;
                op = "*";
                return op;
            }

            public string Divide(decimal displayValue)
            {
                operand1 = displayValue;
                currentValue = operand1;
                op = "/";
                return op;
            }

            public decimal Equals()
            {
                operand2 = currentValue;
                switch (op)
                {
                    case "+":
                        currentValue = operand1 + operand2;
                        break;
                    case "-":
                        currentValue = operand1 - operand2;
                        break;
                    case "*":
                        currentValue = operand1 * operand2;
                        break;
                    case "/":
                        if (operand2 == 0)
                        {
                            MessageBox.Show("Dividing by 0 is undefined");
                        }
                        else
                        {
                            currentValue = operand1 / operand2;
                        }
                        break;
                        
                }
                operand1 = currentValue; // set operand1 to the current result for chaining operations
                operand2 = 0; // clear operand2
                op = null; // clear the operator
                return operand1;
            }

            public void Clear()
            {
                operand1 = 0;
                operand2 = 0;
                currentValue = 0;
                op = null;
            }
        }

        public Calculator()
        {
            InitializeComponent();
        }
        Calc calc = null;
        FileStream fs1 = new FileStream("Calculator.txt", FileMode.Append, FileAccess.Write);
        
        StreamWriter objW = null;
        StreamWriter objW2 = null;
        private void Calculator_Load(object sender, EventArgs e)
        {
            calc = new Calc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = textBox1.Text + "1";
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "0")
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text = textBox1.Text + "2";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text = textBox1.Text + "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text = textBox1.Text + "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text = textBox1.Text + "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text = textBox1.Text + "6";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text = textBox1.Text + "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text = textBox1.Text + "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text = textBox1.Text + "9";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text = textBox1.Text + "0";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = ".";
            }
            else
            {
                textBox1.Text += ".";
            }
        }
        string textString = null; //Text to store the first number and write in the text file. 
        //ADD BUTTON
        private void button13_Click(object sender, EventArgs e)
        {
            textString = textBox1.Text;
            calc.Add(Convert.ToDecimal(textBox1.Text));
            textBox1.Text = null;
        }
        private void substractBTN_Click(object sender, EventArgs e)
        {
            calc.Subtract(Convert.ToDecimal(textBox1.Text));
            textBox1.Text += "-";
            textBox1.Text = null;
        }

        private void multBTN_Click(object sender, EventArgs e)
        {
            calc.Multiply(Convert.ToDecimal(textBox1.Text)); 
            textBox1.Text += "*";
            textBox1.Text = null;
        }

        private void DivBTN_Click(object sender, EventArgs e)
        {
            calc.Divide(Convert.ToDecimal(textBox1.Text)); 
            textBox1.Text += "/";
            textBox1.Text = null;
        }

        //EQUAL BUTTON
        private void button17_Click(object sender, EventArgs e)
        {
            
            objW = new StreamWriter(fs1);
            objW.Write(textString);
            calc.CurrentValue = Convert.ToDecimal(textBox1.Text);
            objW.Write(" + " + textBox1.Text + " = ");
            textBox1.Text = calc.Equals().ToString();


            objW.Write(textBox1.Text+ "\n");
            objW.Close();

        }
        //CLEAR BUTTON
        private void button12_Click(object sender, EventArgs e)
        {
            calc.Clear();
            textBox1.Text = null;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("\nDo you want \n to quit this application \n Temp Conversion ? ", "Exit?", MessageBoxButtons.YesNo).ToString() == "Yes") // Asking if the user wants to quit the app

            {
                this.Close();

            }
        }
    }
}
