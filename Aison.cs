using Microsoft.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Windows.Forms;

namespace Aison___assistant
{
    public class Aison
    {
        public bool isActive = false;
        public bool isWork = true;
        public string[] Active_Words;
        public SpeechSynthesizer Say_sound;
        private string lastSay = "Я ничего не говорил";
        public Timer timer_activAison;
        public List<Command> commands;
        public MainForm Obj_MainForm;

        public Aison()
        {
            commands = new List<Command>();
        }

        public string[] TCom_Time, TCom_Data, TCom_replayLast, TCom_aisonSleep, TCom_aisonClose, TCom_MediaPause, TCom_MediaNext, TCom_MediaPrev, TCom_ProcessCalc, TCom_Explorer,
            TCom_WebBrowser, TCom_WebBrowser_Yandex, TCom_WebBrowser_Google, TCom_WindowsRes, TCom_WindowsOff, TCom_WindowsSleep, TCom_aisonRes, TCom_aisonDeView, TCom_playCityGame;


        public void Active()
        {
            isActive = true;
            timer_activAison.Stop();
            timer_activAison.Start();
            Obj_MainForm.UI_Update();
            Obj_MainForm.Visible = true;
            Obj_MainForm.timer1.Stop();
            Obj_MainForm.timer1.Start();
            using (var soundPlayer = new SoundPlayer("media\\act.wav"))
            {
                soundPlayer.Play();
            }

        }

        public void DeActive()
        {
            isActive = false;
            timer_activAison.Stop();
            Obj_MainForm.UI_Update();
            Obj_MainForm.timer1.Stop();
            Obj_MainForm.timer1.Start();
            using (var soundPlayer = new SoundPlayer("media\\de_act.wav"))
            {
                soundPlayer.Play();
            }
        }

        public void Say(string str)
        {
            lastSay = str;
            Say_sound.Speak(str);
            Active();
        }

        public void Save_CustomCommandsFile()
        {
            string str = "";
            foreach (Command i in commands)
            {
                str += i.Path + ";";
            }
            /*for(int i = 0; i < commands.Count - 1; i++)
            {
                str += commands[i].Path + ";";
                // if (i < commands.Count - 2) str += ";";
            }*/
            //Console.WriteLine(str);
            new CWR.CWRFile("data/custom-c.cfg").Write(str);
        }

        public void Com_Time()
        {
            Say("Сейчас: " + DateTime.Now.Hour.ToString() + " " + DateTime.Now.Minute.ToString() + ". и " + DateTime.Now.Second.ToString() + " секунд");
        }
        public void Com_Data()
        {
            Say("Сегодня: " + __DATA__.MounthDay_say[DateTime.Now.Day - 1] + " " + __DATA__.Month_say[DateTime.Now.Month - 1] + ". Год: " + DateTime.Now.Year.ToString());
        }
        public void Com_replayLastMessage()
        {
            Say(lastSay);
        }
        public void Com_MediaPause()
        {
            new Keyboard().Send(Keyboard.ScanCodeShort.MEDIA_PLAY_PAUSE);
            Active();
        }
        public void Com_MediaNext()
        {
            new Keyboard().Send(Keyboard.ScanCodeShort.MEDIA_NEXT_TRACK);
            Active();
        }
        public void Com_MediaPrev()
        {
            new Keyboard().Send(Keyboard.ScanCodeShort.MEDIA_PREV_TRACK);
            Active();
        }
        public void Com_Calculator()
        {
            System.Diagnostics.Process.Start("calc");
            Active();
        }
        public void Com_Explorer()
        {
            System.Diagnostics.Process.Start("explorer.exe");
            Active();
        }
        public void Com_WebBrowser()
        {
            System.Diagnostics.Process.Start("https://");
            Active();
        }
        public void Com_WebBrowser_Yandex()
        {
            System.Diagnostics.Process.Start("https://yandex.ru");
            Active();
        }
        public void Com_WebBrowser_Google()
        {
            System.Diagnostics.Process.Start("https://google.com");
            Active();
        }
        public void Com_Windows_Res()
        {
            Obj_MainForm.BringToFront();
            if (MessageBox.Show("Вы уверенны что хотите перезагрузить ПК?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                OpenProcessArg("cmd", "shutdown.exe -r -t 0");
                Active();
            }
        }
        public void Com_Windows_Off()
        {
            Obj_MainForm.BringToFront();
            if (MessageBox.Show("Вы уверенны что хотите выключить ПК?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                OpenProcessArg("cmd", "Shutdown.exe -s -t 0");
                Active();
            }
        }
        public void Com_Windows_Sleep()
        {
            Obj_MainForm.BringToFront();
            if (MessageBox.Show("Вы уверенны что хотите заблокировать ПК?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                OpenProcessArg("cmd", "rundll32 powrprof.dll,SetSuspendState 0,1,0");
                Active();
            }
        }
        public void Com_AisonProgramReStart()
        {
            Application.Restart();
        }
        public void Com_aisonDeView()
        {
            Obj_MainForm.timer1.Stop();
            Obj_MainForm.Visible = false;
            DeActive();
        }

        public static void OpenProcessArg(string command, string arg)
        {
            var proc = new ProcessStartInfo(){
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/C " + arg
                ,WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(proc);
        }

        public void OpenCityGame()
        {
            isWork = false;
            var form = new CityGameForm();
            //form.Show();
            DeActive();
            Obj_MainForm.Text = Obj_MainForm.Text + " - Игра в города";
            Obj_MainForm.Enabled = false;
            Obj_MainForm.Update();
            form.ShowDialog();
            Obj_MainForm.Text = Obj_MainForm.Text.Split(new string[] { " - Игра в города" }, StringSplitOptions.None)[0];
            Obj_MainForm.Enabled = true;
            Obj_MainForm.Update();
        }

    }

}
