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

namespace Project
{
    public partial class Lotto649 : Form
    {
        string[] arrStore = new string[7];
        public Lotto649()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arrStore = new string[7];
            Random random = new Random();
            string tempString1 = "";
            string tempString2 = "";
            List<int> numbers = Enumerable.Range(1, 49).ToList();
            //Adding the random numbers in the array. 

            for (int i = 0; i < arrStore.Length; i++)
            {
                int index = random.Next(numbers.Count); // index that will save the random numbers. 
                int randomNumber = numbers[index]; // Variable that will have the valuea of every random number inside the list. 
                arrStore[i] = randomNumber.ToString();
                arrStore.ToString();
                tempString1 += randomNumber.ToString() + "\t";
                numbers.RemoveAt(index); // Remove all the repeating numbers. 

            }
            // Showing the random numbers in the Text Box in vertical. 

            //Creation of the text file. 
            string filePath = "LottoNbrs.txt";
            string lotteryName = "649";
            DateTime currentDate = DateTime.Now;
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{lotteryName}, {currentDate}, {string.Join(",", arrStore)}, Bonus " + arrStore[6]);
            }
            txtRandomMax.Text = tempString1;
            tempString1 = "";

            for (int i = 0; i < 6; i++)
            {
                int randomNumber = random.Next(0, 9);
                tempString2 += randomNumber.ToString();
            }
            label2.Text = tempString2;
            tempString2 = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                ////Creation of the text file. 
                string filePath = "LottoNbrs.txt";
                // Reading the contents of the text file and displaying it in a message box
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string fileContent = reader.ReadToEnd();
                    DisplayLottoFile lottoFile = new DisplayLottoFile();
                    lottoFile.ShowDialog();
                }
            }
    }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this application.? ", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes") // Asking if the user wants to quit the app

            {
                this.Close();
            }
        }
    }
}
