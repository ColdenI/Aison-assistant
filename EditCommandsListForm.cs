using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aison___assistant
{
    public partial class EditCommandsListForm : Form
    {
        public EditCommandsListForm(WindowStyle.WindowTheme s)
        {
            InitializeComponent();
            MainForm.SetStyle(s, this, new Control[] { textBox1 });
        }

        public EditCommandsListForm(string commands, WindowStyle.WindowTheme s)
        {
            InitializeComponent();
            MainForm.SetStyle(s, this, new Control[] { textBox1 });

            listBox_CommandsList.Items.Clear();
            foreach (string i in commands.Split(new string[] { ";" }, StringSplitOptions.None)) 
                listBox_CommandsList.Items.Add(i);
            //listBox_CommandsList.Items.RemoveAt(listBox_CommandsList.Items.Count - 1);
        }

        private void EditCommandsListForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox_CommandsList.Items.Contains(textBox1.Text)) return;
            listBox_CommandsList.Items.Add(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox_CommandsList.SelectedIndex == -1) return;
            listBox_CommandsList.Items.RemoveAt(listBox_CommandsList.SelectedIndex);
        }
    }
}
