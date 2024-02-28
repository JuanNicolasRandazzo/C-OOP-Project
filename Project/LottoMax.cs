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
    public partial class LottoMax : Form
    {
        string[] arrStore = new string[8];

        public LottoMax()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Button to generate the random numbers
        {
            arrStore = new string[8]; //Array to store the results and display the index inside the text file. 
            Random random = new Random();
            string tempString = ""; // string to display the random numbers in the lebel. 
            string tempString1 = "";// string to display the random numbers in the text box. 
            List<int> numbers = Enumerable.Range(1,50).ToList();
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
            

            
            //Creation of the text file. 
            string filePath = "LottoNbrs.txt";
            string lotteryName = "Max";
            DateTime currentDate = DateTime.Now;
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{lotteryName}, {currentDate}, {string.Join(",", arrStore)}, Bonus " + arrStore[7]);
            }
            txtRandomMax.Text = tempString1;
            tempString1 = "";

            for (int i = 0; i < 6; i++)
            {
                int randomNumber = random.Next(0, 9);
                tempString += randomNumber.ToString();
            }
            label2.Text = tempString ;
            tempString = "";


        }

        private void button2_Click(object sender, EventArgs e)// Button to read the File 
        {
            
            string filePath = "LottoNbrs.txt";
            // Reading the contents of the text file and displaying it in a message box
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContent = reader.ReadToEnd();
                // MessageBox.Show(fileContent, "File Contents");
                DisplayLottoFile lottoFile = new DisplayLottoFile();
                lottoFile.ShowDialog();

            }

        }

        private void button3_Click(object sender, EventArgs e) //Button Exit. 
        {
            if (MessageBox.Show("Do you want to quit this application.? ", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes") // Asking if the user wants to quit the app

            {
                this.Close();
            }
            
        }
    }
}
