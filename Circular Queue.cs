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
        int HP = 8, TP = 2;
        string[] Memory = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Memory[0] = "A";
            Memory[1] = "B";
            Memory[2] = "C";
            Memory[3] = "D";
            Memory[4] = "E";
            Memory[5] = "F";
            Memory[6] = "G";
            Memory[7] = "H";
            Memory[8] = "I";

            DisplayMemory();
        }

        bool IsFull()
        {
            // Checking if memory is full 
            if ((HP == 0 && TP == Memory.Length-1) || (HP == TP - 1))
            {
                // Full
                MessageBox.Show("Memory is full");
                return true;
            }
            return false;
        }

        bool IsEmpty()
        {
            // Checking if memory is full 
            if (HP == TP - 1) // TO DO
            {
                // Full
                MessageBox.Show("Memory is empty");
                return true;
            }
            return false;
        }

        void DisplayMemory()
        {
            lblOutput.Text = "";
            int TempPointer = HP;

            while (TempPointer >= TP)
            {
                lblOutput.Text += Memory[TempPointer] + "\n";
                TempPointer -= 1;
            }

            lblStart.Text = "Start Pointer: " + HP;
            lblEnd.Text = "End Pointer: " + TP;
        }

        // Pop
        private void btnPop_Click(object sender, EventArgs e)
        {
            if (!IsEmpty())
            {
                // Push TP back and chuck data item there
                HP -= 1;
            }

            DisplayMemory();
        }

        // Push
        private void btnPush_Click(object sender, EventArgs e)
        {
            if(!IsFull())
            {
                // Push TP back and chuck data item there
                TP -= 1;
                Memory[TP] = txtPush.Text;
            }

            DisplayMemory();
        }
    }
}
