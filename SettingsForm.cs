using CWR;
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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var cfg_file = new CWRItem("data/config.cfg");

            trackBar_volue.Value = cfg_file.GetItemInt("aison_volume");
            label_volue.Text = cfg_file.GetItemInt("aison_volume").ToString();

            trackBar_timeAct.Value = cfg_file.GetItemInt("act_time") / 1000;
            label_timeAct.Text = (cfg_file.GetItemInt("act_time") / 1000).ToString();

            trackBar_delayOffView.Value = cfg_file.GetItemInt("del_view_time") / 1000;
            label_delayOffView.Text = (cfg_file.GetItemInt("del_view_time") / 1000).ToString();

            trackBar_sensitivity.Value = (int)(cfg_file.GetItemFloat("sensitivity") * 100);
            label_sensitivity.Text = (cfg_file.GetItemFloat("sensitivity") * 100).ToString();
        }

        private void button_volue_Click(object sender, EventArgs e)
        {
            var cfg_file = new CWRItem("data/config.cfg");
            cfg_file.SetOrAddItem("aison_volume", trackBar_volue.Value);
            if (MessageBox.Show("Изменения вступят в силу только после перезапуска программы.\nХотите перезапустить её сейчас?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) Application.Restart();
        }

        private void trackBar_volue_Scroll(object sender, EventArgs e)
        {
            label_volue.Text = trackBar_volue.Value.ToString() + " %";
        }

        private void trackBar_timeAct_Scroll(object sender, EventArgs e)
        {
            label_timeAct.Text = trackBar_timeAct.Value.ToString();
        }

        private void button_timeAct_Click(object sender, EventArgs e)
        {
            var cfg_file = new CWRItem("data/config.cfg");
            cfg_file.SetOrAddItem("act_time", trackBar_timeAct.Value * 1000);
            if (MessageBox.Show("Изменения вступят в силу только после перезапуска программы.\nХотите перезапустить её сейчас?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) Application.Restart();
        }

        private void button_delayOffView_Click(object sender, EventArgs e)
        {
            var cfg_file = new CWRItem("data/config.cfg");
            cfg_file.SetOrAddItem("del_view_time", trackBar_delayOffView.Value * 1000);
            if (MessageBox.Show("Изменения вступят в силу только после перезапуска программы.\nХотите перезапустить её сейчас?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) Application.Restart();
        }

        private void trackBar_delayOffView_Scroll(object sender, EventArgs e)
        {
            label_delayOffView.Text = trackBar_delayOffView.Value.ToString();
        }

        private void trackBar_sensitivity_Scroll(object sender, EventArgs e)
        {
            label_sensitivity.Text = trackBar_sensitivity.Value.ToString();
        }

        private void button_sensitivity_Click(object sender, EventArgs e)
        {
            var cfg_file = new CWRItem("data/config.cfg");
            cfg_file.SetOrAddItem("sensitivity", trackBar_sensitivity.Value / 100f);
            if (MessageBox.Show("Изменения вступят в силу только после перезапуска программы.\nХотите перезапустить её сейчас?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) Application.Restart();
        }
    }
}
