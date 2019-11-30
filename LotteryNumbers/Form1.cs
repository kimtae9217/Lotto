using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LotteryNumbers
{
    public partial class Lottery : Form
    {
        public Lottery()
        {
            InitializeComponent();
        }
        // Setup array as integers 
        int[] myNumbers;

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {   //txtGoodLuck invisible
            txtGoodLuck.Visible = false;
            //set myNumbers invisible
            txtDisplay1.Text = "";
            txtDisplay2.Text = "";
            txtDisplay3.Text = "";
            txtDisplay4.Text = "";
            txtDisplay5.Text = "";
            txtDisplay6.Text = "";
            txtDisplay7.Text = "";
            Delay(1000);
            // set rnd as random variable
            Random rnd = new Random();
            // Set array length
            myNumbers = new int[7];
            //init tempNumber
            int tmpNumber = 0;
            // For loop to iterate through array 
            for (int i = 0; i < 7; i++)
            {
                // Generate random number
                tmpNumber = rnd.Next(1, 45);
                
                //Check tmpNumber is not in myNumbers
                if (!myNumbers.Contains(tmpNumber))
                {
                    //Add number to array
                    myNumbers[i] = tmpNumber;
                }
                else
                {
                    //redo
                    i--;
                }
            }
            // Sort array, lowest number first
            //Array.Sort(myNumbers);

            // Give each textbox the value stored in array[index]
            
            txtDisplay1.Text = myNumbers[0].ToString();
            Delay(1000);
            txtDisplay2.Text = myNumbers[1].ToString();
            Delay(1000);
            txtDisplay3.Text = myNumbers[2].ToString();
            Delay(1000);
            txtDisplay4.Text = myNumbers[3].ToString();
            Delay(1000);
            txtDisplay5.Text = myNumbers[4].ToString();
            Delay(1000);
            txtDisplay6.Text = myNumbers[5].ToString();
            Delay(1000);
            txtDisplay7.Text = myNumbers[6].ToString();

            txtGoodLuck.Visible = true;
        
            

    }
        private int index = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            index %= imageList1.Images.Count;
            label1.Image = imageList1.Images[index++];
        }
    }
}
