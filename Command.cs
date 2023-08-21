using CWR;
using System;
using System.Collections.Generic;
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
            Type = EType.SERIAL;
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
                EType eType = EType.EXE;
                string _st = item.GetItemString("type");
                if (_st == "EXE") eType = Command.EType.EXE;
                if (_st == "URL") eType = Command.EType.URL;
                if (_st == "SERIAL") eType = Command.EType.SERIAL;
                if (_st == "SAY") eType = Command.EType.SAY;
                if (_st == "COMGP") eType = Command.EType.COMGP;
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
                case EType.EXE:
                    try
                    {
                        if (Arg_2 == "") System.Diagnostics.Process.Start(Arg);
                        else Aison.OpenProcessArg(Arg, Arg_2);
                        Loger.print("Start: " + Arg + "  args: " + Arg_2);
                    }
                    catch(Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Ошибка при исполнении команды!\n Файл команды: " + Path + "\n Тип: EXE\n  Аргумент 1: " + Arg + "\n Аргумент 2:" + Arg_2 + "\n\nИсключение: " + ex.ToString(), "Ой...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error) ;
                    }
                    break;
                case EType.URL:
                    using (var wb = new WebClient())
                    {
                        try
                        {
                            var v = wb.DownloadString(Arg);
                            Loger.print("URL start: " + Arg);
                        }
                        catch (System.Net.WebException)
                        {
                            MessageBox.Show("URL адрес неверен!", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case EType.SERIAL:
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
                            Loger.print("Serial start: " + Arg + " args: " + Arg_2);
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
                case EType.SAY:
                    MainForm.Aison.Say(Arg.ToString(), false);

                    break;
                case EType.COMGP:
                    //Console.WriteLine("make COMGP . . .");
                    if (!File.Exists(Arg))
                    {
                        MessageBox.Show("Ошибка! Файл инструкций не найден по указанному адресу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }

                    string str = File.ReadAllText(Arg).Split('{')[1].Split('}')[0];
                    var list = new List<string>();
                    list.AddRange(str.Split(';'));
                    list.RemoveAt(list.Count - 1);
                    var ci = new CWRItem(Arg);
                    foreach (string i in list)
                    {
                        var com = new Command();
                        com.Path = i;
                        Command.EType eType = Command.EType.EXE;
                        string Etype = ci.GetItemString(i + "_type");
                        if (Etype == "EXE") eType = Command.EType.EXE;
                        if (Etype == "URL") eType = Command.EType.URL;
                        if (Etype == "SERIAL") eType = Command.EType.SERIAL;
                        if (Etype == "SAY") eType = Command.EType.SAY;
                        com.Type = eType;
                        com.Arg = ci.GetItemString(i + "_arg1");
                        com.Arg_2 = ci.GetItemString(i + "_arg2");

                        com.Make();
                    }

                    break;
            }
            
        }


        public enum EType
        {
            EXE = 0,
            URL = 1,
            SERIAL = 2,
            SAY = 3,
            COMGP = 4
        };
    }
}
