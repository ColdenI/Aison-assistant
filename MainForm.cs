using CWR;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Aison___assistant
{
    public partial class MainForm : Form
    {
        public const string PRcode = "TKeYz-RxxKf-45w77-hzdOI-qbfQ5";

        public bool isPRactive = false;
        private string lang_In = "ru-ru", lang_out = "ru-RU";
        public static Aison Aison = new Aison();
        private int AisonVoiseVolume = 100;

        static private SpeechRecognitionEngine sre;
        private SpeechSynthesizer synth;
        private List<string> _comms = new List<string>();

        public MainForm()
        {
            InitializeComponent();

            Loger.print("The program is running.");
            Load_DATA();

            // настройка распознования речи
            CultureInfo ci = new CultureInfo(lang_In); // подключение руского языка  -  русский
            //System.Globalization.CultureInfo ci = new CultureInfo("en-us"); // подключение руского языка  -  англ.
            sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice(); // микрофон по умолчанию (как в системе)
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized); // ссылка на метод обработки при распознании
            Choices words = new Choices();

            Loger.print("initializing commands.");
            // список распознаваемых слов и слово сочетаний

            
            try {          
                _comms.AddRange(Aison.Active_Words);
                _comms.AddRange(Aison.TCom_Time);
                _comms.AddRange(Aison.TCom_Data);
                _comms.AddRange(Aison.TCom_replayLast);
                _comms.AddRange(Aison.TCom_aisonClose);
                _comms.AddRange(Aison.TCom_aisonSleep);
                _comms.AddRange(Aison.TCom_MediaPause);
                _comms.AddRange(Aison.TCom_MediaPrev);
                _comms.AddRange(Aison.TCom_MediaNext);
                _comms.AddRange(Aison.TCom_ProcessCalc);
                _comms.AddRange(Aison.TCom_Explorer);
                _comms.AddRange(Aison.TCom_WebBrowser);
                _comms.AddRange(Aison.TCom_WebBrowser_Yandex);
                _comms.AddRange(Aison.TCom_WebBrowser_Google);
                _comms.AddRange(Aison.TCom_WindowsOff);
                _comms.AddRange(Aison.TCom_WindowsRes);
                _comms.AddRange(Aison.TCom_WindowsSleep);
                _comms.AddRange(Aison.TCom_aisonRes);
                _comms.AddRange(Aison.TCom_aisonDeView);

                // мои кастомные команды регистрация
                _comms.AddRange(new string[] {"как тебя зовут", "кто ты такой" });


                foreach (Command i in Aison.commands) 
                {
                    foreach (string i_ in i.Commands.Split(new string[] { ";" }, StringSplitOptions.None))
                        _comms.Add(i_);
                }

                _comms.AddRange(new string[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Старт невозможен!\n\nПричина: " + ex.ToString());
                Loger.print(ex.ToString());
                return;
            }

            try
            {
                words.Add(_comms.ToArray());
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Старт невозможен!\nПричина: ArgumentNullException\nВ фале(ах) команд (data\\CW_...txt). Дополните команды!");
                Loger.print("ArgumentNullException");
                return;
            }

            //foreach (string i in _comms) Console.WriteLine(i);
            //Console.WriteLine("____________________________");

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

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.7 && Aison.isWork) 
            {
                Console.WriteLine(e.Result.Text);
                Loger.print("Command: " + e.Result.Text);
                textBox_log_message.Text = e.Result.Text + "\n" + textBox_log_message.Text;

                // активировать
                if (ContainsItemInArray<string>(Aison.Active_Words, e.Result.Text))
                {
                    Aison.Active();
                    timer_aison_activ.Stop();
                    timer_aison_activ.Start();
                    UI_Update();
                }

                if (Aison.isActive)
                {
                    if (ContainsItemInArray<string>(Aison.TCom_Time, e.Result.Text)) Aison.Com_Time(); // сказаьть время
                    if (ContainsItemInArray<string>(Aison.TCom_Data, e.Result.Text)) Aison.Com_Data(); // сказать дату
                    if (ContainsItemInArray<string>(Aison.TCom_replayLast, e.Result.Text)) Aison.Com_replayLastMessage(); // повторить последнюю фразу
                    if (ContainsItemInArray<string>(Aison.TCom_aisonSleep, e.Result.Text)) Aison.DeActive(); // усыпить Aison
                    if (ContainsItemInArray<string>(Aison.TCom_aisonClose, e.Result.Text)) Application.Exit(); // закрыть программу
                    if (ContainsItemInArray<string>(Aison.TCom_MediaPause, e.Result.Text)) Aison.Com_MediaPause();
                    if (ContainsItemInArray<string>(Aison.TCom_MediaPrev, e.Result.Text)) Aison.Com_MediaPrev();
                    if (ContainsItemInArray<string>(Aison.TCom_MediaNext, e.Result.Text)) Aison.Com_MediaNext();
                    if (ContainsItemInArray<string>(Aison.TCom_ProcessCalc, e.Result.Text)) Aison.Com_Calculator(); // открыть калькулятор
                    if (ContainsItemInArray<string>(Aison.TCom_Explorer, e.Result.Text)) Aison.Com_Explorer(); // открыть проводник
                    if (ContainsItemInArray<string>(Aison.TCom_WebBrowser, e.Result.Text)) Aison.Com_WebBrowser(); // открыть браузер
                    if (ContainsItemInArray<string>(Aison.TCom_WebBrowser_Yandex, e.Result.Text)) Aison.Com_WebBrowser_Yandex(); // открыть браузер яндекс
                    if (ContainsItemInArray<string>(Aison.TCom_WebBrowser_Google, e.Result.Text)) Aison.Com_WebBrowser_Google(); // открыть браузер гугл
                    if (ContainsItemInArray<string>(Aison.TCom_WindowsOff, e.Result.Text)) Aison.Com_Windows_Off();
                    if (ContainsItemInArray<string>(Aison.TCom_WindowsRes, e.Result.Text)) Aison.Com_Windows_Res();
                    if (ContainsItemInArray<string>(Aison.TCom_WindowsSleep, e.Result.Text)) Aison.Com_Windows_Sleep();
                    if (ContainsItemInArray<string>(Aison.TCom_aisonRes, e.Result.Text)) Aison.Com_AisonProgramReStart();
                    if (ContainsItemInArray<string>(Aison.TCom_aisonDeView, e.Result.Text)) Aison.Com_aisonDeView();

                    if (ContainsItemInArray<string>(new string[] { "как тебя зовут", "кто ты такой" }, e.Result.Text)) Aison.Say("меня зовут эйсон. я ваш голосовой ассистент");

                    // мои кастомные команды (исполнения)

                    foreach (Command i in Aison.commands)
                    {
                        if (ContainsItemInArray<string>(i.Commands.Split(new string[] { ";" }, StringSplitOptions.None), e.Result.Text))
                        {
                            i.Make();
                            Aison.Active();
                        }
                    }


                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // synth.Speak("Здраствуйте. Вас приветствует программа Эйсон!");
            Aison.Say_sound = synth;
            Aison.timer_activAison = timer_aison_activ;
            Aison.Obj_MainForm = this;

            Aison.Active();
        }

        public void UI_Update()
        {
            if (Aison.isActive)isAisonAct_indi.BackColor = Color.LimeGreen;
            else isAisonAct_indi.BackColor = Color.Salmon;

            listBox_custom_command.Items.Clear();
            try
            {
                foreach (Command i in Aison.commands) listBox_custom_command.Items.Add(i.Path);
            }catch (Exception e)
            {
                MessageBox.Show($"Произошла критическая ошибка и файлом дополнительных команд!\nПопробуйте удалить:\n{Path.GetFullPath("data\\custom-c.cfg")}\nИли переустановите программу.");
                Application.Exit();
            }
        }

        private void timer_aison_activ_Tick(object sender, EventArgs e)
        {
            Aison.DeActive();
            UI_Update();
        }

        private void Load_DATA()
        {
            Loger.print("Loading data...");

            var cfg_file = new CWRItem("data/config.cfg");
            if (!cfg_file.ContainsItem("lang_in")) cfg_file.AddItem("lang_in", "ru-ru");
            if (!cfg_file.ContainsItem("lang_out")) cfg_file.AddItem("lang_out", "ru-RU");
            if (!cfg_file.ContainsItem("act_time")) cfg_file.AddItem("act_time", 7000);
            if (!cfg_file.ContainsItem("view_hist_pan")) cfg_file.AddItem("view_hist_pan", true);
            if (!cfg_file.ContainsItem("size_win-h")) cfg_file.AddItem("size_win-h", 475);
            if (!cfg_file.ContainsItem("size_win-w")) cfg_file.AddItem("size_win-w", 500);
            if (!cfg_file.ContainsItem("write_log")) cfg_file.AddItem("write_log", true);
            if (!cfg_file.ContainsItem("aison_volume")) cfg_file.AddItem("aison_volume", 100);
            if (!cfg_file.ContainsItem("PRc_user")) cfg_file.AddItem("PRc_user", "");
            if (!cfg_file.ContainsItem("del_view_time")) cfg_file.AddItem("del_view_time", 60000);

            lang_In = cfg_file.GetItemString("lang_in");
            lang_out = cfg_file.GetItemString("lang_out");
            timer_aison_activ.Interval = cfg_file.GetItemInt("act_time");
            панельКомандToolStripMenuItem.Checked = cfg_file.GetItemBoolean("view_hist_pan");
            писатьLogToolStripMenuItem.Checked = cfg_file.GetItemBoolean("write_log");
            Loger.isLog = cfg_file.GetItemBoolean("write_log");
            this.Size = new Size(cfg_file.GetItemInt("size_win-w"), cfg_file.GetItemInt("size_win-h"));
            AisonVoiseVolume = cfg_file.GetItemInt("aison_volume");
            if (cfg_file.GetItemString("PRc_user") == PRcode) isPRactive = true;
            toolStripButton_bye_aison.Visible = !isPRactive;
            windowsToolStripMenuItem.Enabled = isPRactive;
            timer1.Interval = cfg_file.GetItemInt("del_view_time");

            
            if (!Check_ExistFile(new string[] {
                "data/AW.txt", "data/CW-time.txt" , "data/CW-data.txt" , "data/CW-replayLastMessage.txt" , "data/CW-AisonSleep.txt",
                "data/CW-AisonClose.txt","data/CW-MediaPause.txt","data/CW-MediaNext.txt","data/CW-MediaPrev.txt","data/CW-OpenCalc.txt", "data/CW-OpenExplorer.txt",
                "data/CW-OpenWebBrowser.txt","data/CW-OpenWebBrowser_Yandex.txt","data/CW-OpenWebBrowser_Google.txt","data/CW-WindowsOff.txt","data/CW-WindowsRes.txt",
                "data/CW-WindowsSleep.txt", "data/CW-AisonRes.txt", "data/CW-AisonDeViev.txt"
            })) { }

            // загрузить список файлов с кастомными командами
            if (new CWRFile("data/custom-c.cfg").Read().Contains(";"))
            {
                List<string> arr = new List<string>();
                arr.AddRange(new CWRFile("data/custom-c.cfg").Read().Split(new string[] { ";" }, StringSplitOptions.None));
                arr.RemoveAt(arr.Count - 1);
                foreach (string i in arr)
                {
                    var newC = new Command(i);
                    if(newC == null)
                    {
                        MessageBox.Show("File error or not found: " + i);
                    }
                    else
                        Aison.commands.Add(newC);
                }
                    
            }


            Aison.Active_Words = new CWRFile("data/AW.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);

            Aison.TCom_Time = new CWRFile("data/CW-time.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_Data = new CWRFile("data/CW-data.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_replayLast = new CWRFile("data/CW-replayLastMessage.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_aisonSleep = new CWRFile("data/CW-AisonSleep.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_aisonClose = new CWRFile("data/CW-AisonClose.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_MediaPause = new CWRFile("data/CW-MediaPause.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_MediaNext = new CWRFile("data/CW-MediaNext.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_MediaPrev = new CWRFile("data/CW-MediaPrev.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_ProcessCalc = new CWRFile("data/CW-OpenCalc.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_Explorer = new CWRFile("data/CW-OpenExplorer.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_WebBrowser = new CWRFile("data/CW-OpenWebBrowser.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_WebBrowser_Yandex = new CWRFile("data/CW-OpenWebBrowser_Yandex.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_WebBrowser_Google = new CWRFile("data/CW-OpenWebBrowser_Google.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_WindowsOff = new CWRFile("data/CW-WindowsOff.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_WindowsRes = new CWRFile("data/CW-WindowsRes.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_WindowsSleep = new CWRFile("data/CW-WindowsSleep.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_aisonRes = new CWRFile("data/CW-AisonRes.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_aisonDeView = new CWRFile("data/CW-AisonDeViev.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);

            Loger.print("Loading data... end");
            UI_Update();
        }

        private bool Check_ExistFile(string[] paths)
        {
            bool _e = true;
            foreach (string i in paths)
            {
                if (!File.Exists(i))
                {
                    using (var soundPlayer = new SoundPlayer("media\\error.wav"))
                    {
                        soundPlayer.Play();
                    }
                    MessageBox.Show("Отсутствует файл с командами!\n" + i + "\nПрогрмма создаст файл, но вам нужно его заполнить.", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _e = false;
                    new CWRFile(i).Write(i);
                }
            }

            return _e;
        }

        private void Open_AddCommand()
        {
            if(!isPRactive)
                if(listBox_custom_command.Items.Count >= 5)
                {
                    if(MessageBox.Show("Вы не можете добавить больше 5 собственных команд, потому что у вас пробная версия программы.\n \nХотите купить сейчас?", "Ой...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                        Open_ByeAisonForm();
                    return;
                }

            timer1.Stop();
            var Form = new AddEditDefCommandForm();
            Form.Owner = this;
            Form.Show();
        }

        private void Open_ByeAisonForm()
        {
            timer1.Stop();
            new ByeAisonForm().Show();
        }

        private void Open_EditCommand()
        {
            if (listBox_custom_command.SelectedIndex != -1)
            {
                timer1.Stop();
                var Form = new AddEditDefCommandForm(Aison.commands[listBox_custom_command.SelectedIndex]);
                Form.Owner = this;
                Form.Show();
            }
        }

        private void button_actAison_Click(object sender, EventArgs e)
        {
            if (!Aison.isActive)
            {
                Aison.Active();
                timer_aison_activ.Stop();
                timer_aison_activ.Start();
                UI_Update();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Open_AddCommand();
        }

        private void button_edit_custom_command_Click(object sender, EventArgs e)
        {
            Open_EditCommand();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listBox_custom_command.SelectedIndex == -1) return;
            if (MessageBox.Show("Вы уверенны, что хотите удалить элемент?\nВосстановить будет невозможно!", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
            File.Delete("data/custom/" + listBox_custom_command.Items[listBox_custom_command.SelectedIndex]);
            Aison.commands.Remove(Aison.commands[listBox_custom_command.SelectedIndex]);
            Aison.Save_CustomCommandsFile();
            UI_Update();
        }

        private void OpenEditStandartCommands(string path)
        {
            EditCommandsListForm editCommandsForm = new EditCommandsListForm(new CWRFile(path).Read());
            string str = "";
            editCommandsForm.buttonSave.Click += delegate (object sender_, EventArgs e_)
            {
                if (editCommandsForm.listBox_CommandsList.Items.Count <= 1)
                {
                    MessageBox.Show("Добавьте минимум 2 команды.", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (string i in editCommandsForm.listBox_CommandsList.Items)
                {
                    str += i;
                    if (editCommandsForm.listBox_CommandsList.Items.IndexOf(i) < editCommandsForm.listBox_CommandsList.Items.Count - 1) str += ";";
                }
                new CWRFile(path).Write(str);
                if(MessageBox.Show("Изменения вступят в силу только после перезапуска программы.\n Хотите перезапустить сейчас?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Aison.Com_AisonProgramReStart();
                }
                editCommandsForm.Close();
            };
            editCommandsForm.ShowDialog();
        }

        private void активацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/AW.txt");
        }
        private void отключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-AisonSleep.txt");
        }
        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-replayLastMessage.txt");
        }
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-AisonClose.txt");
        }
        private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-OpenCalc.txt");
        }
        private void проводникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-OpenExplorer.txt");
        }
        private void датаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-data.txt");
        }
        private void времяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-time.txt");
        }
        private void отключитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-WindowsOff.txt");
        }
        private void перезагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-WindowsRes.txt");
        }
        private void гибернацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-WindowsSleep.txt");
        }
        private void браузерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-OpenWebBrowser.txt");
        }
        private void яндексToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-OpenWebBrowser_Yandex.txt");
        }
        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-OpenWebBrowser_Google.txt");
        }
        private void перезапуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-AisonRes.txt");
        }

        private void панельКомандToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            var cfg_file = new CWRItem("data/config.cfg");
            cfg_file.SetOrAddItem("view_hist_pan", панельКомандToolStripMenuItem.Checked);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var cfg_file = new CWRItem("data/config.cfg");
            cfg_file.SetOrAddItem("size_win-h", this.Size.Height);
            cfg_file.SetOrAddItem("size_win-w", this.Size.Width);
        }

        private void писатьLogToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            var cfg_file = new CWRItem("data/config.cfg");
            cfg_file.SetOrAddItem("write_log", писатьLogToolStripMenuItem.Checked);
            Loger.isLog = писатьLogToolStripMenuItem.Checked;
        }

        private void всеЗарегистрированныеКомандыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ViewAllCommandsForm(_comms);
            form.ShowDialog();
        }

        private void посмотретьLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "data\\logs\\");
        }

        private void isAisonAct_indi_Click(object sender, EventArgs e)
        {
            if (Aison.isActive) Aison.DeActive();
            else Aison.Active();
        }

        public void IncludeInAutoStart()
        {
            string str_bat = "@echo off\ncd /d \"" + Path.GetDirectoryName(Application.ExecutablePath) + "\"\nstart " + Application.ExecutablePath.Split('/')[Application.ExecutablePath.Split('/').Length - 1] + "\nexit";
            new CWRFile(Environment.GetFolderPath(Environment.SpecialFolder.Startup).Replace("\\", "/") + "/Aison-autostart.bat").Write(str_bat);
        }
        public void DeIncludeInAutoStart()
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup).Replace("\\", "/") + "/Aison-autostart.bat")) File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup).Replace("\\", "/") + "/Aison-autostart.bat");

        }

        private void добавитьВСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncludeInAutoStart();
        }

        private void исключитьИзСпискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeIncludeInAutoStart();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenSettingsWindow();
        }

        private void OpenSettingsWindow()
        {
            timer1.Stop();
            timer1.Start();
            new SettingsForm().ShowDialog();
        }

        private void подготовитьКУдалениюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeIncludeInAutoStart();
            try 
            {
                if (Directory.Exists("data/logs"))
                    foreach (string file in Directory.EnumerateFiles("data/logs/", "*.*", SearchOption.AllDirectories))
                    {
                        File.Delete(file);
                    }

                if (Directory.Exists("data/custom"))
                    foreach (string file in Directory.EnumerateFiles("data/custom/", "*.*", SearchOption.AllDirectories))
                    {
                        File.Delete(file);
                    }

                var cfg_file = new CWRItem("data/config.cfg");
                cfg_file.SetOrAddItem("write_log", false);
                Loger.isLog = false;

                if (File.Exists("data/custom-c.cfg")) File.Delete("data/custom-c.cfg");

                MessageBox.Show("Программа подготовлна к удалению.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists("unins000.exe"))
            {
                MessageBox.Show("Программа деинсталляции отсутствует!", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process.Start("unins000.exe");
            Application.Exit();
        }

        private void toolStripButton_bye_aison_Click(object sender, EventArgs e)
        {
            Open_ByeAisonForm();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
            new AboutForm().Show();
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            this.Visible = false;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }

        private void какРаботаетПрограммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("media\\infoWork.pdf");
        }

        private void скрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-AisonDeView.txt");
        }

        private void очиститьМестоНаДискеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Продолжить процедуру по очистке диска:\n\t-Из папки программы будут удалены установочные файлы (MSSpeech_SR_ru-RU_TELE.msi, SpeechPlatformRuntime_x32.msi, x86_MicrosoftSpeechPlatformSDK.msi, MSSpeech_TTS_ru-RU_Elena.msi)\n\t-Будут удалены файлы log\n \nПродолжить?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;

            if (Directory.Exists("data/logs"))
                foreach (string file in Directory.EnumerateFiles("data/logs/", "*.*", SearchOption.AllDirectories))
                {
                    File.Delete(file);
                }

            if (File.Exists("MSSpeech_SR_ru-RU_TELE.msi")) File.Delete("MSSpeech_SR_ru-RU_TELE.msi");
            if (File.Exists("SpeechPlatformRuntime_x32.msi")) File.Delete("SpeechPlatformRuntime_x32.msi");
            if(File.Exists("x86_MicrosoftSpeechPlatformSDK.msi")) File.Delete("x86_MicrosoftSpeechPlatformSDK.msi");
            if (File.Exists("MSSpeech_TTS_ru-RU_Elena.msi")) File.Delete("MSSpeech_TTS_ru-RU_Elena.msi");

        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettingsWindow();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void играВГородаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aison.OpenCityGame();
        }

        static private bool ContainsItemInArray<T>(T[] arr, T i)
        {
            foreach (T _i in arr)
                if (_i.Equals(i)) return true;
            return false;
        }
    }


    static class __DATA__
    {
        public static string[] Month_say = new string[]{ "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря"};
        public static string[] MounthDay_say = new string[]{"первое", "второе", "третье", "четвёртое", "пятое", "шестое", "седьмое", "восьмое", "девятое", "десятое", "одинадцатое", "двенадцатое",
        "тринадцатое", "четырнадцатое", "пятнадцатое", "шестнадцатое", "семнадцатое", "весемьнадцатое", "девятнадцатое", "двадцатое", "двадцать первое",
        "двадцать второе", "двадцать третье", "двадцать четвёртое", "двадцать пятое", "двадцать шестое",
        "двадцать седьмое","двадцать восьмое","двадцать девятое","тридцатое", "тридцать первое"};

    }
  
}
