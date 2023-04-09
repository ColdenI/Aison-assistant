using CWR;
using System;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Windows.Forms;

namespace Aison___assistant
{
    public class Command
    {
        public string Path { get; set; }
        public string Commands { get; set; }
        public EType Type { get; set; }
        public string Arg { get; set; }
        public string Arg_2 { get; set; }

        public Command(string name, string commands, EType type, string arg)
        {
            Path = name;
            Commands = commands;
            Type = type;
            Arg = arg;
        }
        public Command(string name, string commands, string arg1, string arg2)
        {
            Path = name;
            Commands = commands;
            Type = EType.Serial;
            Arg = arg1;
            Arg_2 = arg2;
        }
        public Command() { }
        public Command(string path)
        {
            try
            {
                if (!File.Exists("data/custom/" + path)) return;

                var item = new CWRItem("data/custom/" + path);
                Path = path;
                Commands = item.GetItemString("coms");
                EType eType = EType.Exe;
                string _st = item.GetItemString("type");
                if (_st == "EXE") eType = Command.EType.Exe;
                if (_st == "URL") eType = Command.EType.Url;
                if (_st == "SERIAL") eType = Command.EType.Serial;
                if (_st == "SAY") eType = Command.EType.Say;
                Type = eType;
                Arg = item.GetItemString("arg1");
                Arg_2 = item.GetItemString("arg2");
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

        }

        public void Make()
        {
            switch (Type)
            {
                case EType.Exe:
                    try
                    {
                        if (Arg_2 == "") System.Diagnostics.Process.Start(Arg);
                        else Aison.OpenProcessArg(Arg, Arg_2);
                    }
                    catch(Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Ошибка при исполнении команды!\n Файл команды: " + Path + "\n Тип: EXE\n  Аргумент 1: " + Arg + "\n Аргумент 2:" + Arg_2 + "\n\nИсключение: " + ex.ToString(), "Ой...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error) ;
                    }
                    break;
                case EType.Url:
                    using (var wb = new WebClient())
                    {
                        try
                        {
                            var v = wb.DownloadString(Arg);
                        }
                        catch (System.Net.WebException)
                        {
                            MessageBox.Show("URL адрес неверен!", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case EType.Serial:
                    SerialPort serialPort = new SerialPort();
                    try
                    {
                        if(serialPort.IsOpen) serialPort.Close();
                        if (!serialPort.IsOpen)
                        {
                            serialPort.PortName = Arg.Split(new string[] { ";" }, StringSplitOptions.None)[0];
                            serialPort.BaudRate = Convert.ToInt32(Arg.Split(new string[] { ";" }, StringSplitOptions.None)[1]);
                            serialPort.Open();

                            serialPort.Write(Arg_2);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка Seriel или в формате аргумента 1\n \n \n  Исключение: " + ex.ToString(), "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        serialPort.Close();
                    }
                    break;
                case EType.Say:
                    MainForm.Aison.Say(Arg.ToString());

                    break;
            }
            
        }


        public enum EType
        {
            Exe = 0,
            Url = 1,
            Serial = 2,
            Say = 3
        };
    }
}
