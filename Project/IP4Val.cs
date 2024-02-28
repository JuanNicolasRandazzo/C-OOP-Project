using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Project
{
    public partial class IP4Val : Form
    {
        public int timer = 0;
        public IP4Val()
        {
            InitializeComponent();
        }
        Regex regex = null;
        Match match = null;
        DateTime currDate = DateTime.Today;
        TimeSpan ts = TimeSpan.Zero;
        string timeString;
        string binaryPath = @"./IP4Validator.bin"; // path to binary file
        private void IP4Val_Load(object sender, EventArgs e)
        {
            regex = new Regex((@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"));
            label2.Text = "Today: " + currDate.ToLongDateString();
            timer1.Start();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FileStream fs3 = new FileStream(binaryPath, FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs3);
            bw.Write(textBox1.Text.Trim());
            
           
            try
            {
                string validation = textBox1.Text;
                match = regex.Match(validation);

                if (match.Success)
                {
                    MessageBox.Show(validation + "\n" + "The IP is correct. ");
                }
                else
                {
                    MessageBox.Show(validation + "\n" + "The IP must have 4 bytes \n" + "Integer number between 0 to 255 \n" + "separated by a dot (255.255.255.255)");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            bw.Close();
            fs3.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer += 1;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("\nDo you want \n to quit this application \n IP4 Validator ? ", "Exit?", MessageBoxButtons.YesNo).ToString() == "Yes") // Asking if the user wants to quit the app

            {
                this.Close();

                int elapsedSeconds = timer * timer1.Interval / 1000; // get total elapsed seconds
                int minutes = elapsedSeconds / 60; // get number of minutes
                int seconds = elapsedSeconds % 60; // get remaining seconds
                string timeString = $"{minutes:D2}:{seconds:D2}"; // format the string with leading zeros
                MessageBox.Show($"Elapsed time: {timeString}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }
    }
}
