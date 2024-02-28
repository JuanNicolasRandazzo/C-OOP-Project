using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Project
{
    
    public partial class MoneyEx : Form
    {
        public int timer = 0; // Global variable used for the timer. 
        internal class Money
        {
            private double firstCurr;
            private double conversion;


            public Money() { } //Default construct 



            public Money(double firstCurr, double conversion)
            {
                this.firstCurr = firstCurr;
                this.conversion = conversion;
            }

            public double FirstCurr
            {
                get
                { return firstCurr; }
                set
                { firstCurr = value; }
            }
            public double Conversion
            {
                get
                { return conversion; }
                set
                { conversion = value; }
            }

            // CAD conversion
            public double cadToUsd(double usd)
            {

                usd = FirstCurr * 0.74;
                Conversion = usd;
                return Conversion;
            }
            public double cadToEur(double eur)
            {
                eur = FirstCurr * 0.68;
                Conversion = eur;
                return Conversion;
            }
            public double cadToGBP(double gbp)
            {
                gbp = FirstCurr * 0.599;
                Conversion = gbp;
                return Conversion;
            }
            public double cadToClp(double clp)
            {
                clp = FirstCurr * 585.96;
                Conversion = clp;
                return Conversion;
            }

            //USD conversion
            public double usdToCad(double cad)
            {
                cad = FirstCurr * 1.35;
                Conversion = cad;
                return Conversion;
            }
            public double usdToEur(double eur)
            {
                eur = FirstCurr * 0.92;
                Conversion = eur;
                return Conversion;
            }
            public double usdToGBP(double gbp)
            {
                gbp = FirstCurr * 0.81;
                Conversion = gbp;
                return Conversion;
            }
            public double usdToCLP(double gbp)
            {
                gbp = FirstCurr * 790.91;
                Conversion = gbp;
                return Conversion;
            }

            // EUR conversion 

            public double eurToCad(double cad)
            {
                cad = FirstCurr * 1.46;
                Conversion = cad;
                return Conversion;
            }
            public double eurToUsd(double usd)
            {
                usd = FirstCurr * 1.08;
                Conversion = usd;
                return Conversion;
            }
            public double eurToGBP(double gbp)
            {
                gbp = FirstCurr * 0.88;
                Conversion = gbp;
                return Conversion;
            }
            public double eurToClp(double clp)
            {
                clp = FirstCurr * 857.96;
                Conversion = clp;
                return Conversion;
            }

            //GBP conversion

            public double gbpToCad(double cad)
            {
                cad = FirstCurr * 1.66;
                Conversion = cad;
                return Conversion;
            }
            public double gbpToUsd(double usd)
            {
                usd = FirstCurr * 1.23;
                Conversion = usd;
                return Conversion;
            }
            public double gbpToEur(double eur)
            {
                eur = FirstCurr * 1.14;
                Conversion = eur;
                return Conversion;
            }
            public double gbpToClp(double clp)
            {
                clp = FirstCurr * 975.59;
                Conversion = clp;
                return Conversion;
            }

            // CLP conversion 

            public double clpToCad(double cad)
            {
                cad = FirstCurr * 0.0017;
                Conversion = cad;
                return Conversion;
            }
            public double clpToUsd(double usd)
            {
                usd = FirstCurr * 0.0013;
                Conversion = usd;
                return Conversion;
            }
            public double clpToEur(double eur)
            {
                eur = FirstCurr * 0.0012;
                Conversion = eur;
                return Conversion;
            }
            public double clpToGBP(double gbp)
            {
                gbp = FirstCurr * 0.0010;
                Conversion = gbp;
                return Conversion;
            }
        }
        
        public MoneyEx()
        {
            InitializeComponent();
            timer1.Start();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            //Strings used in the ternary operators
            string cadString = "CAD";
            string usdString = "USD";
            string eurString = "EUR";
            string gbpString = "GBP";
            string clpString = "CLP";
            
            try
            {
                // Ternary Operators:

                // Making the conditions in the radioButtons. It's a shorter way. It makes the same as an if and else but in a shorter way. 
                string from = radioButton1.Checked ? "CAD" : radioButton2.Checked ? "USD" : radioButton3.Checked ? "EUR" : radioButton4.Checked ? "GBP" : radioButton5.Checked ? "CLP" : "";
                string to = radioButton10.Checked ? "CAD" : radioButton9.Checked ? "USD" : radioButton8.Checked ? "EUR" : radioButton7.Checked ? "GBP" : radioButton6.Checked ? "CLP" : "";
                double result = 0; // this variable will save the conversion result. 
                double amount = Convert.ToDouble(textBox1.Text); // This variable recieves the input from the user
                Money money = new Money(amount, 0); // Creation of the object money with arguments for firstCurr and Conversion. 
                                                    //Creation of the text file. 
                string filePath = @".\MoneyConv.txt";
                DateTime currentDate = DateTime.Now;

                switch (from)
                {
                    case "CAD":
                        switch (to)
                        {
                            case "USD":


                                result = money.cadToUsd(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {cadString} = {textBox2.Text} {usdString}, {currentDate}\n");
                                }
                                break;
                            case "EUR":
                                result = money.cadToEur(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {cadString} = {textBox2.Text} {eurString}, {currentDate}\n");
                                }
                                break;

                            case "GBP":
                                result = money.cadToGBP(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {cadString} = {textBox2.Text} {gbpString}, {currentDate} \n");
                                }
                                break;

                            case "CLP":
                                result = money.cadToClp(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {cadString} = {textBox2.Text} {clpString}, {currentDate} \n");
                                }
                                break;

                            case "CAD":
                                result = Convert.ToDouble(textBox1.Text);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {cadString} = {textBox2.Text} {cadString}, {currentDate} \n");
                                }
                                break;

                        }
                        break;

                    case "USD":
                        switch (to)
                        {
                            case "CAD":
                                result = money.usdToCad(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {usdString} = {textBox2.Text} {cadString}, {currentDate}\n");
                                }
                                break;
                            case "EUR":
                                result = money.usdToEur(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {usdString} = {textBox2.Text} {eurString}, {currentDate}\n");
                                }
                                break;
                            case "GBP":
                                result = money.usdToGBP(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {usdString} = {textBox2.Text} {gbpString}, {currentDate}\n");
                                }
                                break;
                            case "CLP":
                                result = money.usdToCLP(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {usdString} = {textBox2.Text} {clpString}, {currentDate}\n");
                                }
                                break;
                            case "USD":
                                result = Convert.ToDouble(textBox1.Text);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {usdString} = {textBox2.Text} {usdString}, {currentDate}\n");
                                }
                                break;
                        }
                        break;
                    case "EUR":
                        switch (to)
                        {
                            case "CAD":
                                result = money.eurToCad(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {eurString} = {textBox2.Text} {cadString}, {currentDate}\n");
                                }
                                break;
                            case "USD":
                                result = money.eurToUsd(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {eurString} = {textBox2.Text} {usdString}, {currentDate}\n");
                                }
                                break;
                            case "GBP":
                                result = money.eurToGBP(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {eurString} = {textBox2.Text} {gbpString}, {currentDate}\n");
                                }
                                break;
                            case "CLP":
                                result = money.eurToClp(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {eurString} = {textBox2.Text} {clpString}, {currentDate}\n");
                                }
                                break;
                            case "EUR":
                                result = Convert.ToDouble(textBox1.Text);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {eurString} = {textBox2.Text} {eurString}, {currentDate}\n");
                                }
                                break;
                        }
                        break;
                    case "GBP":
                        switch (to)
                        {
                            case "CAD":
                                result = money.gbpToCad(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {gbpString} = {textBox2.Text} {cadString}, {currentDate}\n");
                                }
                                break;
                            case "USD":
                                result = money.gbpToUsd(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {gbpString} = {textBox2.Text} {usdString}, {currentDate}\n");
                                }
                                break;
                            case "EUR":
                                result = money.gbpToEur(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {gbpString} = {textBox2.Text} {eurString}, {currentDate} \n");
                                }
                                break;
                            case "CLP":
                                result = money.gbpToClp(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {gbpString} = {textBox2.Text} {clpString}, {currentDate} \n");
                                }
                                break;
                            case "GBP":
                                result = Convert.ToDouble(textBox1.Text);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {gbpString} = {textBox2.Text} {gbpString}, {currentDate} \n");
                                }
                                break;
                        }
                        break;
                    case "CLP":
                        switch (to)
                        {
                            case "CAD":
                                result = money.clpToCad(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {clpString} = {textBox2.Text} {cadString}, {currentDate}\n");
                                }
                                break;
                            case "USD":
                                result = money.clpToUsd(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {clpString} = {textBox2.Text} {usdString}, {currentDate} \n");
                                }
                                break;
                            case "EUR":
                                result = money.clpToEur(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {clpString} = {textBox2.Text} {eurString}, {currentDate}  \n");
                                }
                                break;
                            case "GBP":
                                result = money.clpToGBP(amount);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {clpString} = {textBox2.Text} {gbpString}, {currentDate}  \n");
                                }
                                break;
                            case "CLP":
                                result = Convert.ToDouble(textBox1.Text);
                                textBox2.Text = result.ToString();
                                using (StreamWriter writer = new StreamWriter(filePath, true))
                                {
                                    writer.WriteLine($"{amount.ToString()} {clpString} = {textBox2.Text} {clpString}, {currentDate}  \n");
                                }
                                break;

                        }
                        break;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                radioButton1.Focus();
                
            }
            
           


            
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayConversionFile convFile = new DisplayConversionFile();
            convFile.ShowDialog(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("\nDo you want \n to quit this application \n Money Exchang ? ", "Exit?", MessageBoxButtons.YesNo).ToString() == "Yes") // Asking if the user wants to quit the app

            {
                this.Close();
                timer1.Stop();
                MessageBox.Show($"You spent {timer} seconds in the app.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer += 1;
            
        }
    }
        
} 

