using CWR;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using WindowStyle;


namespace Aison___assistant
{
    public partial class MainForm : Form
    {
        public const string PRcode = "TKeYz-RxxKf-45w77-hzdOI-qbfQ5";

        public bool isPRactive = false;
        private string lang_In = "ru-ru", lang_out = "ru-RU";
        public static Aison Aison = new Aison();
        private int AisonVoiseVolume = 100;
        private float sensitivity = 0.7f;
        private bool _isWelcomeSay = false;
        private int _speedSay_synth = 0;
        private string _welcome_text_say = "Здравствуйте, вас приветствует Эйсон! Я ваш голосовой ассистент.";
        public WindowTheme _WindowStyle;
        public int _setVolume = 2;
        private static Control[] _controlsArray;

        static private SpeechRecognitionEngine sre;
        private SpeechSynthesizer synth;
        private List<string> _comms = new List<string>();

        public MainForm()
        {
            InitializeComponent();

            _controlsArray = new Control[]
            {
                listBox_custom_command,
                groupBox1,
                textBox_log_message,
                button_actAison

            };

            this.KeyDown += new KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPreview = true;


            Loger.print("The program is running.");
            Load_DATA();
            SetStyle(_WindowStyle, this, _controlsArray);

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
                _comms.AddRange(Aison.TCom_playCityGame);
                _comms.AddRange(Aison.TCom_SysVolumeUp);
                _comms.AddRange(Aison.TCom_SysVolumeDown);
                _comms.AddRange(Aison.TCom_SysVolumeMute);

                // мои кастомные команды регистрация
                _comms.AddRange(new string[] {"как тебя зовут", "кто ты такой", "што ты умеешь", "што ты можешь" });


                foreach (Command i in Aison.commands) 
                {
                    foreach (string i_ in i.Commands.Split(new string[] { ";" }, StringSplitOptions.None))
                        _comms.Add(i_);
                }

                _comms.AddRange(new string[] { });
            }
            catch (Exception ex)
            {
                PlayErrorSound();
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
                PlayErrorSound();
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

            Init_synth();
        }

        private void Init_synth()
        {
            // инициализация синтеза речи
            synth = new SpeechSynthesizer();
            synth.SpeakCompleted += Aison.Synth_SpeakCompleted;
            var voices = synth.GetInstalledVoices(new CultureInfo(lang_out));
            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoice(voices[0].VoiceInfo.Name);
            /*
            for (int i = 0; i < voices.Count; i++)
                Console.WriteLine(voices[i].VoiceInfo.Name);
            */
            synth.Volume = AisonVoiseVolume;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control) Open_AddCommand();
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control) RegistCommand();
            if (e.KeyCode == Keys.U && e.Modifiers == Keys.Control) ExcludeCommand();
            if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control) Open_EditCommand();
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control) 
            {
                if (!Aison.isActive)
                {
                    Aison.Active();
                    timer_aison_activ.Stop();
                    timer_aison_activ.Start();
                    UI_Update();
                }
            }
            if (e.KeyCode == Keys.Delete) DeleteCommand();
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Alt)
            {
                this.Visible = false;
                timer1.Stop();
            }

        }

        private void PrintAndLogUserCommand(string str)
        {
            Console.WriteLine(str);
            Loger.print("Command: " + str);
            textBox_log_message.Text = str + "\n" + textBox_log_message.Text;
        }


        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > sensitivity && Aison.isWork) 
            {
                // активировать
                if (ContainsItemInArray<string>(Aison.Active_Words, e.Result.Text))
                {
                    PrintAndLogUserCommand(e.Result.Text);
                    Aison.Say_sound.SpeakAsyncCancelAll();
                    Aison.Active();
                    timer_aison_activ.Stop();
                    timer_aison_activ.Start();
                    UI_Update();
                    return;
                }

                if (Aison.isActive)
                {
                    Aison.Say_sound.SpeakAsyncCancelAll();
                    PrintAndLogUserCommand(e.Result.Text);

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
                    if (ContainsItemInArray<string>(Aison.TCom_playCityGame, e.Result.Text)) Aison.OpenCityGame();
                    if (ContainsItemInArray<string>(Aison.TCom_SysVolumeUp, e.Result.Text)) Aison.Com_SysVolUp();
                    if (ContainsItemInArray<string>(Aison.TCom_SysVolumeDown, e.Result.Text)) Aison.Com_SysVolDown();
                    if (ContainsItemInArray<string>(Aison.TCom_SysVolumeMute, e.Result.Text)) Aison.Com_SysMute();

                    if (ContainsItemInArray<string>(new string[] { "как тебя зовут", "кто ты такой" }, e.Result.Text)) Aison.Say("меня зовут эйсон. я ваш голосовой ассистент");
                    if (ContainsItemInArray<string>(new string[] { "што ты умеешь", "што ты можешь" }, e.Result.Text)) Aison.Say("Я могу открывать программы, помогать с управлением вашим компьютером, отправлять Ю Р Л и сериал запросы, выполнять группы команд и отвечать на ваши вопросы.");

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

        private void PlayErrorSound()
        {
            if (File.Exists("media/error.wav"))
            {
                using (var soundPlayer = new SoundPlayer("media\\error.wav"))
                {
                    soundPlayer.Play();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Aison.Say_sound = synth;
            Aison.timer_activAison = timer_aison_activ;
            Aison.Obj_MainForm = this;
            Aison.Say_sound.Rate = _speedSay_synth;

            if (_isWelcomeSay)
            {
                int _w = Aison.Say_sound.Rate;
                Aison.Say_sound.Rate = 2;
                Aison.Say(_welcome_text_say);
                Aison.Say_sound.Rate = _w;
            }

            Aison.Active();
        }

        public void UI_Update()
        {
            UI_Updata_2();

            if (Aison.isActive)isAisonAct_indi.BackColor = Color.LimeGreen;
            else isAisonAct_indi.BackColor = Color.Salmon;

            listBox_custom_command.Items.Clear();
            try
            {
                foreach (Command i in Aison.commands) listBox_custom_command.Items.Add(i.Path);
            }catch (Exception e)
            {
                PlayErrorSound();
                MessageBox.Show($"Произошла критическая ошибка и файлом дополнительных команд!\nПопробуйте удалить:\n{Path.GetFullPath("data\\custom-c.cfg")}\nИли переустановите программу.");
                Loger.print($"Произошла критическая ошибка и файлом дополнительных команд!\nПопробуйте удалить:\n{Path.GetFullPath("data\\custom-c.cfg")}\nИли переустановите программу.");
                Application.Exit();
            }
        }

        public void UI_Updata_2()
        {
            bool v = listBox_custom_command.SelectedIndex != -1;
            редактироватьToolStripMenuItem.Enabled = v;
            удалитьToolStripMenuItem1.Enabled = v;
            исключитьToolStripMenuItem.Enabled = v;
            экспортToolStripMenuItem.Enabled = v;
            исполнитьКомандуToolStripMenuItem.Enabled = v;
            активироватьToolStripMenuItem.Enabled = !Aison.isActive;
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
            if (!cfg_file.ContainsItem("lang_in")) cfg_file.AddItem("lang_in", "ru-ru");                                                // язык распознания
            if (!cfg_file.ContainsItem("lang_out")) cfg_file.AddItem("lang_out", "ru-RU");                                              // язык синтеза 
            if (!cfg_file.ContainsItem("act_time")) cfg_file.AddItem("act_time", 7000);                                                 // время активности
            if (!cfg_file.ContainsItem("view_hist_pan")) cfg_file.AddItem("view_hist_pan", true);                                       // отображать панель истории (неработ.)
            if (!cfg_file.ContainsItem("size_win-h")) cfg_file.AddItem("size_win-h", 475);                                              // размер окна
            if (!cfg_file.ContainsItem("size_win-w")) cfg_file.AddItem("size_win-w", 500);                                              // размер окна
            if (!cfg_file.ContainsItem("write_log")) cfg_file.AddItem("write_log", true);                                               // писать логи?
            if (!cfg_file.ContainsItem("aison_volume")) cfg_file.AddItem("aison_volume", 100);                                          // громкость синтеза речи
            if (!cfg_file.ContainsItem("PRc_user")) cfg_file.AddItem("PRc_user", "");                                                   // активный код пользователя
            if (!cfg_file.ContainsItem("del_view_time")) cfg_file.AddItem("del_view_time", 60000);                                      // задержка на скрытие окна
            if (!cfg_file.ContainsItem("sensitivity")) cfg_file.AddItem("sensitivity", 0.7);                                            // чувствительность распознания
            if (!cfg_file.ContainsItem("is_welcome_say")) cfg_file.AddItem("is_welcome_say", false);                                    // приветвтвие пользователя при старте
            if (!cfg_file.ContainsItem("speed_say")) cfg_file.AddItem("speed_say", 0);                                                  // скорость синтеза речи
            if (!cfg_file.ContainsItem("text_welcome_say")) cfg_file.AddItem("text_welcome_say", "Здравствуйте, вас приветствует Эйсон! Я ваш голосовой ассистент.");                                                  // скорость синтеза речи
            if (!cfg_file.ContainsItem("theme_window")) cfg_file.AddItem("theme_window", "LIGHT");                                                  // скорость синтеза речи
            if (!cfg_file.ContainsItem("set_volume")) cfg_file.AddItem("set_volume", 2);                                                  // скорость синтеза речи

            try
            {
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
                купитьAisonToolStripMenuItem.Visible = !isPRactive;
                //windowsToolStripMenuItem.Enabled = isPRactive;
                timer1.Interval = cfg_file.GetItemInt("del_view_time");
                sensitivity = cfg_file.GetItemFloat("sensitivity");
                _isWelcomeSay = cfg_file.GetItemBoolean("is_welcome_say");
                _speedSay_synth = cfg_file.GetItemInt("speed_say");
                _welcome_text_say = cfg_file.GetItemString("text_welcome_say");
                if (_speedSay_synth > 10 || _speedSay_synth < -10)
                {
                    PlayErrorSound();
                    MessageBox.Show("Ошибка в файле конфигураций! Скорость синтеза речи должен быть в пределах (от -10 до 10) (int) параметр: “speed_say” файл: “data/config.cfg”\nПараметр установлен по умолчанию. (0)", "Ой!", MessageBoxButtons.OK);
                    cfg_file.SetOrAddItem("speed_say", 0);
                    _speedSay_synth = 0;
                }
                if (cfg_file.GetItemString("theme_window") == "LIGHT") _WindowStyle = WindowTheme.Light;
                else if (cfg_file.GetItemString("theme_window") == "DARK") _WindowStyle = WindowTheme.Dark;
                else if (cfg_file.GetItemString("theme_window") == "BLUE") _WindowStyle = WindowTheme.Blue;
                else if (cfg_file.GetItemString("theme_window") == "GREEN") _WindowStyle = WindowTheme.Green;
                else if (cfg_file.GetItemString("theme_window") == "RED") _WindowStyle = WindowTheme.Red;
                _setVolume = cfg_file.GetItemInt("set_volume");


            }
            catch(Exception ex)
            {
                PlayErrorSound();
                Loger.print("Критическая ошибка! Файл конфигураций повреждён!");
                if (DialogResult.Yes == MessageBox.Show("Критическая ошибка! Файл конфигураций повреждён. Хотите восстановить файл по умолчанию?", "Критическая Ошибка!", MessageBoxButtons.YesNo, MessageBoxIcon.Error))
                {
                    if (File.Exists("data/config.cfg")) File.Delete("data/config.cfg");
                }
            }


            if (!Check_ExistFile(new string[] {
                "data/AW.txt", "data/CW-time.txt" , "data/CW-data.txt" , "data/CW-replayLastMessage.txt" , "data/CW-AisonSleep.txt",
                "data/CW-AisonClose.txt","data/CW-MediaPause.txt","data/CW-MediaNext.txt","data/CW-MediaPrev.txt","data/CW-OpenCalc.txt", "data/CW-OpenExplorer.txt",
                "data/CW-OpenWebBrowser.txt","data/CW-OpenWebBrowser_Yandex.txt","data/CW-OpenWebBrowser_Google.txt","data/CW-WindowsOff.txt","data/CW-WindowsRes.txt",
                "data/CW-WindowsSleep.txt", "data/CW-AisonRes.txt", "data/CW-AisonDeView.txt", "data/CW-CityGame.txt", "data/CW-SysVolumeUp.txt", "data/CW-SysVolumeDown.txt", 
                "data/CW-SysVolumeMute.txt"
            })) { }

            if (!Directory.Exists("data/custom"))
                Directory.CreateDirectory("data/custom");

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
                        PlayErrorSound();
                        MessageBox.Show("File error or not found: " + i);
                        Loger.print("File error or not found: " + i);
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
            Aison.TCom_aisonDeView = new CWRFile("data/CW-AisonDeView.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_playCityGame = new CWRFile("data/CW-CityGame.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_SysVolumeUp = new CWRFile("data/CW-SysVolumeUp.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_SysVolumeDown = new CWRFile("data/CW-SysVolumeDown.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);
            Aison.TCom_SysVolumeMute = new CWRFile("data/CW-SysVolumeMute.txt").Read().Split(new string[] { ";" }, StringSplitOptions.None);


            if (!File.Exists("data/isTraining") && DialogResult.OK == MessageBox.Show("Хотите пройти обучение пользование программой?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                File.Create("data/isTraining");
                TrainingProgram();
            }
            else if (!File.Exists("data/isTraining") && DialogResult.No == MessageBox.Show("Хотите видеть это сообщение в последующие запуски программы?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                File.Create("data/isTraining");


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
                    PlayErrorSound();
                    MessageBox.Show("Отсутствует файл с командами!\n" + i + "\nПрогрмма создаст файл, но вам нужно его заполнить.\nФормат заполнения: ”слово 3;слово 2;слово 3”", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Loger.print("Отсутствует файл с командами!\n" + i);
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
                    PlayErrorSound();
                    if (MessageBox.Show("Вы не можете добавить больше 5 собственных команд, потому что у вас пробная версия программы.\n \nХотите купить сейчас?", "Ой...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                        Open_ByeAisonForm();
                    return;
                }

            timer1.Stop();
            var Form = new AddEditDefCommandForm(_WindowStyle);
            Form.Owner = this;
            Form.Show();
        }

        private void Open_ByeAisonForm()
        {
            timer1.Stop();
            new ByeAisonForm(_WindowStyle).Show();
        }

        private void Open_EditCommand()
        {
            if (listBox_custom_command.SelectedIndex != -1)
            {
                timer1.Stop();
                var Form = new AddEditDefCommandForm(Aison.commands[listBox_custom_command.SelectedIndex], _WindowStyle);
                Form.Owner = this;
                Form.Show();
            }
        }

        private void ExecudeCommandClick(object sender, EventArgs e)
        {
            if (listBox_custom_command.SelectedIndex == -1) return;
            Aison.commands[listBox_custom_command.SelectedIndex].Make();
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
            DeleteCommand();
        }

        private void DeleteCommand()
        {
            if (listBox_custom_command.SelectedIndex == -1) return;
            if (MessageBox.Show("Вы уверенны, что хотите удалить элемент?\nВосстановить будет невозможно!", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
            File.Delete("data/custom/" + listBox_custom_command.Items[listBox_custom_command.SelectedIndex]);
            Loger.print("Удалён элемент: " + listBox_custom_command.Items[listBox_custom_command.SelectedIndex]);
            Aison.commands.Remove(Aison.commands[listBox_custom_command.SelectedIndex]);
            Aison.Save_CustomCommandsFile();
            UI_Update();
        }

        private void ExcludeCommand()
        {
            if (listBox_custom_command.SelectedIndex == -1) return;
            if (MessageBox.Show("Вы уверенны, что хотите исключить элемент?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
            Aison.commands.Remove(Aison.commands[listBox_custom_command.SelectedIndex]);
            Aison.Save_CustomCommandsFile();
            Loger.print("Элемент исключён из списка кастомных команд! : " + Aison.commands[listBox_custom_command.SelectedIndex].Path);
            UI_Update();

            if (MessageBox.Show("Чтобы изменения вступили в силу нужно перезапустить программу. Хотите сделать это сейчас?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) Application.Restart();
        }

        private void OpenEditStandartCommands(string path)
        {
            EditCommandsListForm editCommandsForm = new EditCommandsListForm(new CWRFile(path).Read(), _WindowStyle);
            string str = "";
            editCommandsForm.buttonSave.Click += delegate (object sender_, EventArgs e_)
            {
                if (editCommandsForm.listBox_CommandsList.Items.Count <= 1)
                {
                    PlayErrorSound();
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
            var form = new ViewAllCommandsForm(_comms, _WindowStyle);
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
            new SettingsForm(_WindowStyle).ShowDialog();
        }

        private void подготовитьКУдалениюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите выполнить подготовку к удалению программы Aison assistant?\nБудут удалены все пользовательские команды и файлы log.", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

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
            new AboutForm(_WindowStyle).Show();
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
            TrainingProgram();
        }

        private void скрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-AisonDeView.txt");
        }

        private void очиститьМестоНаДискеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isError = false;
            if (MessageBox.Show("Продолжить процедуру по очистке диска:\n\t-Из папки программы будут удалены установочные файлы (MSSpeech_SR_ru-RU_TELE.msi, SpeechPlatformRuntime_x32.msi, x86_MicrosoftSpeechPlatformSDK.msi, MSSpeech_TTS_ru-RU_Elena.msi)\n\t-Будут удалены файлы log\n \nПродолжить?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;

            if (Directory.Exists("data/logs"))
                foreach (string file in Directory.EnumerateFiles("data/logs/", "*.*", SearchOption.AllDirectories))
                {
                    File.Delete(file);
                }
            else isError = true;

            if (File.Exists("MSSpeech_SR_ru-RU_TELE.msi")) File.Delete("MSSpeech_SR_ru-RU_TELE.msi");
            if (File.Exists("SpeechPlatformRuntime_x32.msi")) File.Delete("SpeechPlatformRuntime_x32.msi");
            if (File.Exists("x86_MicrosoftSpeechPlatformSDK.msi")) File.Delete("x86_MicrosoftSpeechPlatformSDK.msi");
            if (File.Exists("MSSpeech_TTS_ru-RU_Elena.msi")) File.Delete("MSSpeech_TTS_ru-RU_Elena.msi");

            if (isError)
            {
                PlayErrorSound();
                MessageBox.Show("Во время выполнения процедуры по очистке диска произошла ошибка.\nДиректория с файлами log не обнаружена!", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Directory.CreateDirectory("data/logs");
            }
            else MessageBox.Show("Очистка диска прошла успешно.", "Успешно");
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

        private void играВГородаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-CityGame.txt");
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_EditCommand();
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteCommand();
        }

        private void активироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Aison.isActive)
            {
                Aison.Active();
                timer_aison_activ.Stop();
                timer_aison_activ.Start();
                UI_Update();
            }
        }

        private void купитьAisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_ByeAisonForm();
        }

        private void скрытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            timer1.Stop();
        }

        private void управлениеГруппамиКомандToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CommandGroudForm(_WindowStyle);
            form.Owner = this;
            form.ShowDialog();
        }

        private void очиститьИсториюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_log_message.Text = string.Empty;
        }

        private void исключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcludeCommand();
        }

        private void импортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistCommand();
        }

        private void RegistCommand()
        {
            if (!isPRactive && listBox_custom_command.Items.Count >= 5)
            {
                PlayErrorSound();
                if (MessageBox.Show("Вы не можете добавить больше 5 собственных команд, потому что у вас пробная версия программы.\n \nХотите купить сейчас?", "Ой...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    Open_ByeAisonForm();
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetFullPath("data/custom");
            if (ofd.ShowDialog() == DialogResult.Cancel) return;
            string in_file = ofd.FileName;
            // находится в data/custom ?
            if(Path.GetDirectoryName(in_file) != Path.GetFullPath("data/custom"))
            {
                // предложить переместить
                if(DialogResult.OK == MessageBox.Show("Файл команд должен быть расположен по пути «..Aison/data/custom/file.cfg»\nХотите переместить файл?", "Ой!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    if(new CWRItem(in_file).ContainsItem("type") && new CWRItem(in_file).ContainsItem("arg1"))
                        if(new CWRItem(in_file).GetItemString("type") == "COMGP")
                        {
                            string path_acg = Path.GetDirectoryName(in_file) + "\\" + new CWRItem(in_file).GetItemString("arg1");
                            if (File.Exists(path_acg))
                            {
                                File.Copy(path_acg, "data/custom/" + Path.GetFileName(path_acg));
                                new CWRItem(in_file).SetOrAddItem("arg1", Path.GetFullPath("data/custom/" + Path.GetFileName(path_acg)));
                            }
                            else
                            {
                                MessageBox.Show("File Aison Command Group not found!");
                            }
                        }
                            
                    File.Copy(in_file, "data/custom/" + Path.GetFileName(in_file));

                    in_file = Path.GetFullPath("data/custom/") + Path.GetFileName(in_file);
                }
            }   

            // проверка на файл команд
            CWRItem cwi;
            try
            {
                cwi = new CWRItem("data/custom/" + Path.GetFileName(in_file));
            }
            catch
            {
                PlayErrorSound();
                MessageBox.Show("Файл не является файлом команд или повреждён!", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!cwi.ContainsItem("path") || !cwi.ContainsItem("coms") || !cwi.ContainsItem("type") || !cwi.ContainsItem("arg1"))
            {
                PlayErrorSound();
                MessageBox.Show("Файл не является файлом команд или повреждён!", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cwi.GetItemString("path") != Path.GetFileName(in_file))
            {
                PlayErrorSound();
                MessageBox.Show("Файл не является файлом команд или повреждён!", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // проверка на есть ли такойже уже добавленый 
            string[] arr = new string[listBox_custom_command.Items.Count];
            for(int i =0;i<listBox_custom_command.Items.Count;i++) arr[i] = listBox_custom_command.Items[i].ToString();
            if (ContainsItemInArray<string>(arr, Path.GetFileName(in_file).ToString()))
            {
                PlayErrorSound();
                MessageBox.Show("Такой файл уже зарегистрирован!", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newC = new Command(Path.GetFileName(in_file));
            if (newC == null)
            {
                PlayErrorSound();
                MessageBox.Show("File error or not found: " + Path.GetFileName(in_file));
                Loger.print("File error or not found: " + Path.GetFileName(in_file));
                return;
            }
            else
                Aison.commands.Add(newC);

            Aison.Save_CustomCommandsFile();
            UI_Update();
            if (MessageBox.Show("Чтобы изменения вступили в силу нужно перезапустить программу. Хотите сделать это сейчас?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) Application.Restart();

        }

        private void ExportCommandFile()
        {
            /* выполнить экспорт (копирование) выделеного файла команд файла команд
             * если тип "группа команд" то переместить и его тоже
            */

            if (listBox_custom_command.SelectedIndex == -1) return;
            Command com = Aison.commands[listBox_custom_command.SelectedIndex];
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = ".cfg|.cfg";
            if(saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            string path_out = saveFileDialog.FileName;
            string path_fn = saveFileDialog.FileName;
            /* проврить наличие файлов
             * перемесить в папку с такимже названием
             * в папку положить если нужно файл с инструкциями командных групп
            */
            if (!File.Exists("data/custom/" + com.Path))
            {
                PlayErrorSound();
                MessageBox.Show("Файл команд не найден!", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //-----------------
            path_out = Path.GetDirectoryName(path_out + "/" + Path.GetFileName(path_out)) + " - exporting Aison command file";
            if (Directory.Exists(path_out)) 
            {
                PlayErrorSound();
                if (DialogResult.OK == MessageBox.Show("Файл с таким названием уже экспортирован! Хотите заменить файлы?", "Ой!", MessageBoxButtons.OKCancel))
                {
                    Directory.Delete(path_out, true);
                }
                else return;
            }
            try
            {               
                Directory.CreateDirectory(path_out);
            }
            catch
            {
                PlayErrorSound();
                MessageBox.Show("Ошибка! При создание директории для файлов…", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            path_fn = Path.GetFileName(path_fn) + ".cfg";

            // Console.WriteLine(path_fn);
            try
            {
                File.Copy(Path.GetFullPath("data/custom/" + com.Path), path_out + "/" + path_fn);
            }
            catch (Exception ex)
            {
                PlayErrorSound();
                MessageBox.Show(ex.Message);
            }

            CWRItem cwi = new CWRItem(path_out + "/" + path_fn);
            cwi.SetOrAddItem("path", path_fn);

            if (com.Type == Command.EType.COMGP) 
            {
                try
                {
                    File.Copy(com.Arg, path_out + "/" + Path.GetFileName(com.Arg));
                    cwi.SetOrAddItem("arg1", Path.GetFileName(com.Arg));
                }
                catch (Exception ex)
                {
                    PlayErrorSound();
                    MessageBox.Show(ex.Message);
                }
            }
            //-----------------
            MessageBox.Show("Экспорт файлов команд успешно завершён!", "Экспорт", MessageBoxButtons.OK);
            Process.Start("explorer.exe", path_out);
        }

        private void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportCommandFile();
        }

        private void toolStripSplitButton1_Click(object sender, EventArgs e)
        {
            UI_Updata_2();
        }

        private void TrainingProgram()
        {
            if (!File.Exists("media\\infoWork.pdf"))
            {
                PlayErrorSound();
                MessageBox.Show("Файл с информацией не найден! \n\"media\\\\infoWork.pdf\"", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process.Start("media\\infoWork.pdf");
        }

        private void файлыКомандToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "data\\custom");
        }

        private void удалитьLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data/logs"))
            {
                foreach (string file in Directory.EnumerateFiles("data/logs/", "*.*", SearchOption.AllDirectories))
                {
                    File.Delete(file);
                }
                MessageBox.Show("Файлы log успешно удалены.", "Успешно", MessageBoxButtons.OK);
            }
            else
            {
                PlayErrorSound();
                MessageBox.Show("Директория с файлами log не обнаружена!", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Directory.CreateDirectory("data/logs");
            }
        }

        public static void SetStyle(WindowTheme style, Form form, Control[] controls)
        {
            var list = controls.ToList();
            foreach(Control i in form.Controls) list.Add(i);

            Color _bg = WindowColors.BG_Light, _fg = WindowColors.FG_Light;

            if (style == WindowTheme.Light)
            {
                _bg = WindowColors.BG_Light;
                _fg = WindowColors.FG_Light;
            }
            if (style == WindowTheme.Dark)
            {
                _bg = WindowColors.BG_Dark;
                _fg = WindowColors.FG_Dark;
            }
            
            if (style == WindowTheme.Blue)
            {
                _bg = WindowColors.BG_Blue;
                _fg = WindowColors.FG_Blue;
            }
            
            if (style == WindowTheme.Green)
            {
                _bg = WindowColors.BG_Green;
                _fg = WindowColors.FG_Green;
            }
            
            if (style == WindowTheme.Red)
            {
                _bg = WindowColors.BG_Red;
                _fg = WindowColors.FG_Red;
            }


            form.ForeColor = _fg;
            form.BackColor = _bg;
            foreach (Control control in list)
            {
                control.BackColor = _bg;
                control.ForeColor = _fg;
                if (control is Panel)
                {
                    control.BackColor = Color.FromArgb(0, 0, 0, 0);
                    control.ForeColor = _fg;
                }
                if (control is TrackBar)
                {
                    control.BackColor = _bg;
                    control.ForeColor = _fg;
                }
                if (control is Label)
                {
                    control.BackColor = Color.FromArgb(0, 0, 0, 0);
                    control.ForeColor = _fg;
                }
                if (control is CheckBox)
                {
                    control.BackColor = Color.FromArgb(0, 0, 0, 0);
                    control.ForeColor = _fg;
                }
            }

        }

        private void увеличитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-SysVolumeUp.txt");
        }

        private void уменьшитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-SysVolumeDown.txt");
        }

        private void включитьВыключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditStandartCommands("data/CW-SysVolumeMute.txt");
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
