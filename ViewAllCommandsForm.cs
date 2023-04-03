using System.Collections.Generic;
using System.Windows.Forms;

namespace Aison___assistant
{
    public partial class ViewAllCommandsForm : Form
    {
        public ViewAllCommandsForm(List<string> list)
        {
            InitializeComponent();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(list.ToArray());
        }

    }
}
