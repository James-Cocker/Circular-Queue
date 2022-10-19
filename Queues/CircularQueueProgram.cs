using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queues
{
    public partial class Form1 : Form
    {
        int HP = 0, TP = 8, JobsLeft = 8;
        string[] Memory = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Fill in memory with the current 'jobs'
            Memory[0] = "Job A";
            Memory[1] = "Job B";
            Memory[2] = "Job C";
            Memory[3] = "Job D";
            Memory[4] = "Job E";
            Memory[5] = "Job F";
            Memory[6] = "Job G";
            Memory[7] = "Job H";
            Memory[8] = "Job I";

            // And fill into output label
            DisplayMemory();
        }

        void DisplayMemory()
        {
            lblOutput.Text = "";
            int TempPointer = HP;

            // Loop though and print out memory items whilst the temp pointer is less than or equal to the Tail Pointer
            while (TempPointer != TP)
            {
                lblOutput.Text += Memory[TempPointer] + "\n";

                // If the temporary pointer has reached the end of memory, and it is still not equal to the TP, then it must loop round
                if (TempPointer == Memory.Length - 1)
                {
                    // Hence set the temp pointer back to 0 - the start of the memory
                    TempPointer = 0;
                }
                else
                {
                    TempPointer++;
                }
            }

            // Fill in extra labels
            lblJobsLeft.Text = "Total jobs left: " + JobsLeft;
            lblStart.Text = "Head Pointer: " + HP;
            lblEnd.Text = "Tail Pointer: " + TP;
        }

        bool IsFull()
        {
            // Checking if memory is full 
            if ((HP == 0 && TP == Memory.Length-1) || (HP == TP + 1))
            {
                MessageBox.Show("Memory is full");
                return true;
            }
            return false;
        }

        bool IsEmpty()
        {
            // Checking if memory is full 
            if (HP == TP)
            {
                MessageBox.Show("Memory is empty");
                return true;
            }
            return false;
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            if (!IsEmpty())
            {
                // If the Head Pointer is at the end of the memory, then put it back to the start
                if (HP == (Memory.Length - 1))
                {
                    HP = 0;
                }
                // Otherwise simply push it back
                else
                {
                    HP++;
                }

                JobsLeft--;
            }

            DisplayMemory();
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            if(!IsFull())           // Check memory isnt empty before pushing on another job
            {
                // If the Tail Pointer is at the end of the memory, then put it back to the start
                if (TP == (Memory.Length - 1))      
                {
                    TP = 0;
                }
                // Otherwise push it back
                else
                {
                    TP++;
                }

                JobsLeft++;
            }

            DisplayMemory();
        }
    }
}
