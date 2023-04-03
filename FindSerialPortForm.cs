using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aison___assistant
{
    public partial class FindSerialPortForm : Form
    {
        public FindSerialPortForm()
        {
            InitializeComponent(); 
            SerialPortsUpdate();

        }

        private void SerialPortsUpdate()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void FindSerialPortForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPortsUpdate();
        }
    }
}
