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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LottoMax lotto= new LottoMax();
            lotto.ShowDialog();
            

        }

        private void btnExitMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lotto649 lotto649 = new Lotto649();
            lotto649.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnMoneyConv_Click(object sender, EventArgs e)
        {
            MoneyEx moneyEx= new MoneyEx();
            moneyEx.ShowDialog();
        }

        private void btnTempConv_Click(object sender, EventArgs e)
        {
            TempApp tempApp= new TempApp();
            tempApp.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calculator calculator= new Calculator();
            calculator.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IP4Val iP4Val = new IP4Val();
            iP4Val.ShowDialog();
        }
    }
}
