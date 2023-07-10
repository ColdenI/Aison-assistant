using System.Collections.Generic;
using System.Windows.Forms;

namespace Aison___assistant
{
    public partial class ViewAllCommandsForm : Form
    {
        public ViewAllCommandsForm(List<string> list, WindowStyle.WindowTheme s)
        {
            InitializeComponent();
            MainForm.SetStyle(s, this, new Control[] { });
            listBox1.Items.Clear();
            listBox1.Items.AddRange(list.ToArray());
            this.Text = this.Text + " (" + listBox1.Items.Count.ToString() + ")";
        }
    }
}
