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
    public partial class DisplayTempFile : Form
    {
        public DisplayTempFile()
        {
            InitializeComponent();
        }

        private void DisplayTempFile_Load(object sender, EventArgs e)
        {
            FileStream fs2 = null;
            StreamReader textIn = null;
            string textToPrint = "";

            try
            {
                fs2 = new FileStream("TempConv.txt", FileMode.OpenOrCreate, FileAccess.Read);
                // create the object for the input stream for a text file
                textIn = new StreamReader(fs2);
                string from, to, date, text;
                // read the data from the file and displaying it. 
                while (textIn.Peek() != -1)
                {

                    from = textIn.ReadLine();
                    to = textIn.ReadLine();
                    date = textIn.ReadLine();
                    text = textIn.ReadLine();
                    textToPrint += from + ", \t" + to + /*"\n" +*/ date /*+ "\n"*/ + text + "\n";

                }
            }
            catch (IOException ex)
            {
                // Handle exception
            }
            finally
            {
                // close the input stream for the text file
                if (textIn != null)
                    textIn.Close();

                if (fs2 != null)
                    fs2.Close();
            }

            textBox1.Text = textToPrint;
        }
    }
}
