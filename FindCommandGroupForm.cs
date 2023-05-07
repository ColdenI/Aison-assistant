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

namespace Aison___assistant
{
    public partial class FindCommandGroupForm : Form
    {
        public FindCommandGroupForm()
        {
            InitializeComponent();
        }

        private void button_find_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var list = new List<string>();
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    FileHelper.GetAllFiles(fbd.SelectedPath, "*.acg", list);
                }
            }

            foreach (var file in list) listBox1.Items.Add(file);
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                File.Delete(listBox1.Items[listBox1.SelectedIndex].ToString());
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }
    }

    public static class FileHelper
    {
        public static void GetAllFiles(string rootDirectory, string fileExtension, List<string> files)
        {
            try
            {
                string[] directories = Directory.GetDirectories(rootDirectory);
                files.AddRange(Directory.GetFiles(rootDirectory, fileExtension));

            foreach (string path in directories)
                GetAllFiles(path, fileExtension, files);
            } catch { }
        }
    }
}
