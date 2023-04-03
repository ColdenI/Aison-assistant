using CWR;
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
    public partial class ByeAisonForm : Form
    {
        public ByeAisonForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://akylinandrej.wixsite.com/colden-i/aison");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == MainForm.PRcode)
            {
                var cfg_file = new CWRItem("data/config.cfg");
                cfg_file.SetOrAddItem("PRc_user", textBox1.Text);
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Код неверен!", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
