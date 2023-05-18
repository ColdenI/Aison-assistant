using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aison___assistant
{
    public partial class ErrorStartForm : Form
    {

        Exception Exception;

        public ErrorStartForm()
        {
            InitializeComponent();
        }        
        
        public ErrorStartForm(Exception ex)
        {
            InitializeComponent();
            Exception = ex;
        }

        private void ErrorStartForm_Load(object sender, EventArgs e)
        {
            button_x86_MicrosoftSpeechPlatformSDK.Enabled = File.Exists("x86_MicrosoftSpeechPlatformSDK.msi");
            button_SpeechPlatformRuntime_x32.Enabled = File.Exists("SpeechPlatformRuntime_x32.msi");
            button_MSSpeech_TTS_ru.Enabled = File.Exists("MSSpeech_TTS_ru-RU_Elena.msi");
            button_MSSpeech_SR_ru.Enabled = File.Exists("MSSpeech_SR_ru-RU_TELE.msi");
        }

        private void button_x86_MicrosoftSpeechPlatformSDK_Click(object sender, EventArgs e)
        {
            if (!File.Exists("x86_MicrosoftSpeechPlatformSDK.msi"))
            {
                MessageBox.Show("Файл не найден! ");
                return;
            }
            Process.Start("x86_MicrosoftSpeechPlatformSDK.msi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Exception == null) return;
            MessageBox.Show(Exception.Message + " \n \n \n " + Exception.Source, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_SpeechPlatformRuntime_x32_Click(object sender, EventArgs e)
        {
            if (!File.Exists("SpeechPlatformRuntime_x32.msi"))
            {
                MessageBox.Show("Файл не найден! ");
                return;
            }
            Process.Start("SpeechPlatformRuntime_x32.msi");
        }

        private void button_MSSpeech_TTS_ru_Click(object sender, EventArgs e)
        {
            if (!File.Exists("MSSpeech_TTS_ru-RU_Elena.msi"))
            {
                MessageBox.Show("Файл не найден! ");
                return;
            }
            Process.Start("MSSpeech_TTS_ru-RU_Elena.msi");
        }

        private void button_MSSpeech_SR_ru_Click(object sender, EventArgs e)
        {
            if (!File.Exists("MSSpeech_SR_ru-RU_TELE.msi"))
            {
                MessageBox.Show("Файл не найден! ");
                return;
            }
            Process.Start("MSSpeech_SR_ru-RU_TELE.msi");
        }

        private void button_restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
