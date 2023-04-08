using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aison___assistant
{
    public partial class CityGameForm : Form
    {
        static private SpeechRecognitionEngine sre;
        private SpeechSynthesizer synth;

        private string lang_In = "ru-ru", lang_out = "ru-RU";
        private int AisonVoiseVolume = 100;


        public CityGameForm()
        {
            InitializeComponent();
        }

        private void CityGameForm_Load(object sender, EventArgs e)
        {

            // настройка распознования речи
            CultureInfo ci = new CultureInfo(lang_In); // подключение руского языка  -  русский
            //System.Globalization.CultureInfo ci = new CultureInfo("en-us"); // подключение руского языка  -  англ.
            sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice(); // микрофон по умолчанию (как в системе)
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized); // ссылка на метод обработки при распознании
            Choices words = new Choices();

            words.Add(new string[] {"Москва", "Санкт Питербург", "Омск" });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(words);
            sre.LoadGrammar(new Grammar(gb));
            sre.RecognizeAsync(RecognizeMode.Multiple);

            // инициализация синтеза речи
            synth = new SpeechSynthesizer();
            var voices = synth.GetInstalledVoices(new CultureInfo(lang_out));
            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoice(voices[0].VoiceInfo.Name);

            synth.Volume = AisonVoiseVolume;
        }

        private void CityGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Aison.isWork = true;
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.7)
            {
                Loger.print("City Game - text: " + e.Result.Text);


            }
        }
    }
}
