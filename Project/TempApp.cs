using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project.TempApp;

namespace Project
{
    public partial class TempApp : Form
    {
        public class Conversion
        {
            private double celsius;
            private double fahrenheit;


            public Conversion() { } //Default construct

            public Conversion(double celsius, double fahrenheit)
            {
                this.Celsius = celsius;
                this.Fahrenheit = fahrenheit;
            }

            public double Celsius { get { return celsius; } set { celsius = value; } }
            public double Fahrenheit { get { return fahrenheit; } set { fahrenheit = value; } }

            public double cTof(double conv)
            {
                conv = (Celsius * 9 / 5) + 32;
                Fahrenheit = conv;
                return conv;
            }
            public double fToc(double conv)
            {
                conv = (Fahrenheit - 32) * (5.0 / 9);
                Celsius = conv;
                return conv;
            }
        }
        public TempApp()
        {
            InitializeComponent();


        }

        
        private void button1_Click(object sender, EventArgs e)
        {


            double input = Convert.ToDouble(textBox1.Text); // Temp to convert
            double output = 0; // Temp converted. Displayed on the textbox2.
            string messageString = ""; // Message displayed in the message (textbox3).
            Conversion conversion = new Conversion(input, 0); // object created to use it on the conversion from C to F
            Conversion conversion1 = new Conversion(0, input); // object created to use it on the conversion from F to C
            FileStream fs1 = new FileStream("TempConv.txt", FileMode.Append, FileAccess.Write);
            StreamWriter objW = new StreamWriter(fs1);
            string inputString = textBox1.Text;
            string outputString = textBox2.Text;

            DateTime date = DateTime.Now;



            if (radioButton1.Checked)
            {
                output = conversion.cTof(input);
                textBox2.Text = output.ToString();

            }
            else if (radioButton2.Checked)
            {
                output = conversion1.fToc(input);
                textBox2.Text = output.ToString();


            }
            string mess = textBox3.Text;
            outputString = textBox2.Text;

            

            if (output == 100 || output == 212)
            {
                textBox3.ForeColor = Color.Red;
                messageString = "Water boils.";
                 
            }
            else if (output == 40 || output == 104)
            {
                messageString = "Hot bath";
            }
            else if (output == 37 || output == 98.6)
            {
                messageString = "Body temperature";
            }
            else if (output == 30 || output == 86)
            {
                messageString = "Beach weather";
            }
            else if (output == 21 || output == 70)
            {
                messageString = "Rooom temperature";
            }
            else if (output == 10 || output == 50)
            {
                messageString = "Cool day";
            }
            else if (output == 0 || output == 32)
            {
                messageString = "Freezing point of water";
            }
            else if (output == -18 || output == 0)
            {
                messageString = "Very Cold Day";
            }
            else if (output == -40 || output == -40)
            {
                messageString = "Extremely Cold Day ";
                messageString += Environment.NewLine + "(and the same number!)";
            }

            if (radioButton1.Checked)
            {
                output = conversion.cTof(input);
                textBox2.Text = output.ToString();
                textBox3.Text = messageString;
                objW.WriteLine(" {0} C = {1} F , {2} {3}", inputString, outputString, date, textBox3.Text);
                objW.Close();
                messageString = "";

            }
            else if (radioButton2.Checked)
            {
                output = conversion1.fToc(input);
                textBox2.Text = output.ToString();
                textBox3.Text = messageString;
                objW.WriteLine(" {0} F = {1} C , {2} {3}", inputString, outputString, date, textBox3.Text);
                objW.Close();
                messageString = "";


            }
            fs1.Close();


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "F";
            label3.Text = "C";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "C";
            label3.Text = "F";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayTempFile temp = new DisplayTempFile();
            temp.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("\nDo you want \n to quit this application \n Temp Conversion ? ", "Exit?", MessageBoxButtons.YesNo).ToString() == "Yes") // Asking if the user wants to quit the app

            {
                this.Close();

            }
        }
    }
}


