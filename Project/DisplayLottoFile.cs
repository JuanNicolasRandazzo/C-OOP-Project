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
    public partial class DisplayLottoFile : Form
    {
        public DisplayLottoFile()
        {
            InitializeComponent();
            string filePath = "LottoNbrs.txt";
            string content = File.ReadAllText(filePath);
            textBox1.Text = content;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
