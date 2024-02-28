using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project
{
    public partial class DisplayConversionFile : Form
    {
        public DisplayConversionFile()
        {
            InitializeComponent();
            string filePath = @".\MoneyConv.txt";
            string content = File.ReadAllText(filePath);
            textBox1.Text = content;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
