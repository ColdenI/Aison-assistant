using CWR;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.Json;
using System.Threading;
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

        private bool isPlayer = true;
        private List<string> citysWords;
        private List<string> cityEx;
        private int score = 0;
        private int MaxScore = 0;

        private const string PathFileWordsCity = "data/CityGame-citys.txt";


        public CityGameForm()
        {
            InitializeComponent();
            label_old_city.Text = "";
            label_old_old_city.Text = "";
            cityEx = new List<string>();
            citysWords = new List<string>();
        }

        private void LoadData()
        {
            var cfg_file = new CWRItem("data/config.cfg");
            if (!cfg_file.ContainsItem("lang_in")) cfg_file.AddItem("lang_in", "ru-ru");
            if (!cfg_file.ContainsItem("lang_out")) cfg_file.AddItem("lang_out", "ru-RU");
            if (!cfg_file.ContainsItem("aison_volume")) cfg_file.AddItem("aison_volume", 100);

            lang_In = cfg_file.GetItemString("lang_in");
            lang_out = cfg_file.GetItemString("lang_out");
            AisonVoiseVolume = cfg_file.GetItemInt("aison_volume");


            var cgd_file = new CWRItem("data/CityGame-data.cfg");
            if (!cgd_file.ContainsItem("max_score")) cgd_file.AddItem("max_score", 0);
            if (!cgd_file.ContainsItem("sensitivity")) cgd_file.AddItem("sensitivity", 40);
            
            MaxScore = cgd_file.GetItemInt("max_score");
            label_maxScore.Text = MaxScore.ToString();
            trackBar1.Value = cgd_file.GetItemInt("sensitivity");
        }

        private void CityGameForm_Load(object sender, EventArgs e)
        {
            LoadData();

            // настройка распознования речи
            CultureInfo ci = new CultureInfo(lang_In); // подключение руского языка  -  русский
            //System.Globalization.CultureInfo ci = new CultureInfo("en-us"); // подключение руского языка  -  англ.
            sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice(); // микрофон по умолчанию (как в системе)
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized); // ссылка на метод обработки при распознании
            Choices words = new Choices();

            citysWords.AddRange(LoadCitys());
            words.Add(citysWords.ToArray());

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

        private string[] LoadCitys()
        {
            List<string> list = new List<string>();
            foreach(string i in File.ReadAllText(PathFileWordsCity).Split(new string[] { ";" }, StringSplitOptions.None)) list.Add(i);
            list.RemoveAt(list.Count - 1);
            return list.ToArray();
        }

        private void CityGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Aison.isWork = true;
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > trackBar1.Value / 100)
            {
                ApplyLogicGame(e.Result.Text.ToString());
            }
        }

        private void button_text_apply_Click(object sender, EventArgs e)
        {
            ApplyLogicGame(textBox_text.Text);
        }

        private void ApplyLogicGame(string text)
        {
            Console.WriteLine(text);

            //проверка на наличие города в списке всех
            if (!citysWords.Contains(text))
            {
                if (MessageBox.Show("Я не знаю такого города...\nХотите добавить его в список?", "Ой...", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    // добавить новый город
                    citysWords.Add(text);
                    MessageBox.Show($"Город {text} добавлен в список.", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SaveCitysWordsInFile();
                }
                else return;
            }

            // проверка на правило буквы
            if (!CheckCityGaweWord(text))
            {
                MessageBox.Show($"Город {text} не подходит по правилам!", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // проверка на повторное использование
            if (cityEx.Contains(text))
            {
                MessageBox.Show($"Город {text} уже был использован!", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBox_text.Text = "";

            Loger.print("City Game - text: " + text);
            label_old_old_city.Text = label_old_city.Text;
            label_old_city.Text = text;
            ScoreWork();
            cityEx.Add(text);

            this.Update();

            Thread.Sleep(new Random().Next(200, 400));

            // AI
            string textAI = GetCity_CityGame();
            if (textAI == null)
            {
                if (MessageBox.Show("Больше слов не осталось!\nВы победили! \nНачать заново?", "Молодец!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    // начать заново
                    label_old_city.Text = "";
                    label_old_old_city.Text = "";
                    cityEx = new List<string>();
                    citysWords = new List<string>();
                }
                else this.Close();
            }
            else
            {
                label_old_old_city.Text = label_old_city.Text;
                label_old_city.Text = textAI;
                cityEx.Add(textAI);
                this.Update();
                synth.Speak(textAI);
            }

            using (var soundPlayer = new SoundPlayer("media\\de_act.wav"))
            {
                soundPlayer.Play();
            }
        }

        private void ScoreWork()
        {
            score++;
            label_score.Text = score.ToString();
            if(score > MaxScore)
            {
                MaxScore = score;
                label_maxScore.Text = MaxScore.ToString();
                var cgd_file = new CWRItem("data/CityGame-data.cfg");
                cgd_file.SetOrAddItem("max_score", MaxScore);
            }
        }

        private bool CheckCityGaweWord(string word)
        {
            // проверка на правило буквы
            if (label_old_city.Text != "")
            {
                if ((label_old_city.Text[label_old_city.Text.Length - 1].ToString().ToLower() != "ь") && (label_old_city.Text[label_old_city.Text.Length - 1].ToString().ToLower() != "ы"))
                {
                    if (word[0].ToString().ToLower() != label_old_city.Text[label_old_city.Text.Length - 1].ToString().ToLower())
                    {               
                        return false;
                    }
                }
                else
                {
                    if (word[0].ToString().ToLower() != label_old_city.Text[label_old_city.Text.Length - 2].ToString().ToLower())
                    {                      
                        return false;
                    }
                }
            }

            return true;
        }

        private string GetCity_CityGame()
        {
            List<string> list = citysWords;
            List<string> list_ = new List<string>();
            foreach(string i in cityEx) if(citysWords.Contains(i)) list.Remove(i);
            foreach(string i in list) if(CheckCityGaweWord(i)) list_.Add(i);
            if (list_.Count > 0) return list_[new Random().Next(0, list_.Count - 1)];
            else return null; // конец игры нет ходов
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            string text = GetCity_CityGame();
            if (text == null) MessageBox.Show("Больше слов не осталось!", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox_text.Text = text;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var cgd_file = new CWRItem("data/CityGame-data.cfg");
            cgd_file.SetOrAddItem("sensitivity", trackBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("media/CityGame-doc.html"))
            {
                MessageBox.Show("Error! file not fuond: media/CityGame-doc.html", "error");
                return;
            }
            Process.Start("media\\CityGame-doc.html");
        }

        private void SaveCitysWordsInFile()
        {
            string str = "";
            foreach(string i in citysWords) str += i + ";";
            File.WriteAllText(PathFileWordsCity, str);
        }

    }
}

