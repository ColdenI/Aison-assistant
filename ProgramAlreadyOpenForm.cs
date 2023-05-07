using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aison___assistant
{
 
    public partial class ProgramAlreadyOpenForm : Form
    {
        private const int CountSecondCloseProgram = 15;
        private int SecCount = CountSecondCloseProgram;
        private Process process;

        public ProgramAlreadyOpenForm(Process pr)
        {
            InitializeComponent();
            process = pr;
            label2.Text = "Это окно закроется через: " + SecCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SecCount--;
            label2.Text = "Это окно закроется через: " + SecCount.ToString();
            if (SecCount <= 0) Application.Exit();
        }

        private void button_restartPr_Click(object sender, EventArgs e)
        {
            process.Kill();
            process.Close();

            Application.Restart();
        }
    }
}
