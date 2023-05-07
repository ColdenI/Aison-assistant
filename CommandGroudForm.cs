using CWR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace Aison___assistant
{
    public partial class CommandGroudForm : Form
    {

        private string Path;
        private List<Command> Commands = new List<Command>();


        public CommandGroudForm()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPreview = true;
            textBox_command_arg_2.Enabled = false;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control) Create();
            if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control) Open();
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control && button_file_save.Enabled) SaveData();
            if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control) Find();
            if (e.KeyCode == Keys.Delete && button_file_del.Enabled) Delete(); 
            
        }

        private void LoadData()
        {
            string str;
            try
            {
                str = File.ReadAllText(Path).Split('{')[1].Split('}')[0];
            }catch 
            {
                MessageBox.Show("Файл повреждён!");
                Path = null;
                UpdataLableForm();
                button_file_del.Enabled = false;
                button_file_save.Enabled = false;
                return;
            }
            Commands.Clear();
            listBox_commands.Items.Clear();
            var list = new List<string>();
            list.AddRange(str.Split(';'));
            list.RemoveAt(list.Count - 1);
            var ci = new CWRItem(Path);
            foreach(string i in list)
            {
                var com = new Command();
                com.Path = i;
                Command.EType eType = Command.EType.EXE;
                string Etype = ci.GetItemString(i+"_type");
                if (Etype == "EXE") eType = Command.EType.EXE;
                if (Etype == "URL") eType = Command.EType.URL;
                if (Etype == "SERIAL") eType = Command.EType.SERIAL;
                if (Etype == "SAY") eType = Command.EType.SAY;
                com.Type = eType;
                com.Arg = ci.GetItemString(i+"_arg1");
                com.Arg_2 = ci.GetItemString(i+"_arg2");

                Commands.Add(com);
                listBox_commands.Items.Add(com.Path);
            }

        }

        private void SaveData()
        {
            string str = "{";
            foreach(Command i in Commands) str += i.Path + ";";
            str += "}\n";
            File.WriteAllText(Path, str);

            var ci = new CWRItem(Path);
            foreach(Command i in Commands)
            {
                ci.AddItem(i.Path + "_type", i.Type.ToString());
                ci.AddItem(i.Path + "_arg1", i.Arg.ToString());
                ci.AddItem(i.Path + "_arg2", i.Arg_2.ToString());
            }

            UpdataLableForm();
            MessageBox.Show("Файл инструкций группы команд был сохранён.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_command_arg_1.Text = AddEditDefCommandForm.GetSerialPort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEditDefCommandForm.ViewMessageInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_command_arg_1.Text = AddEditDefCommandForm.GetFilePath();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_command_type.SelectedItem.ToString() == "SERIAL" || comboBox_command_type.SelectedItem.ToString() == "EXE") textBox_command_arg_2.Enabled = true;
            else
            {
                textBox_command_arg_2.Enabled = false;
                textBox_command_arg_2.Text = "";
                UpdataLableForm("*");
            }
        }

        private void setPath(string value)
        {
            if (File.Exists(value.ToString()))
            {
                button_file_del.Enabled = true;
                button_file_save.Enabled = true;
                this.Path = value;
            }
            else
            {
                button_file_del.Enabled = false;
                button_file_save.Enabled = false;
                MessageBox.Show("Файл не найден!", "Ошибка!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Create();
        }

        private void Create()
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "Aison Command Group files (*.acg)|*.acg";
            dlg.InitialDirectory = new FileInfo("data/custom").FullName;
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            File.Create(dlg.FileName);
            setPath(dlg.FileName);

            if (File.Exists(Path))
                MessageBox.Show("Пустой файл успешно создан!");

            UpdataLableForm();
        }

        private void button_file_del_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            if (File.Exists(Path) && MessageBox.Show("Вы уверены, что хотите удалить инструкцию группы команд?\nВосстановить будет нельзя!", "?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                File.Delete(Path);
                Path = null;
                button_file_del.Enabled = false;
                button_file_save.Enabled = false;
                UpdataLableForm();
            }
        }

        private void button_file_open_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Open()
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = new FileInfo("data/custom").FullName;
            ofd.Filter = "Aison Command Group files (*.acg)|*.acg";
            if (ofd.ShowDialog() == DialogResult.Cancel) return;
            setPath(ofd.FileName);

            LoadData();
            UpdataLableForm();
        }

        private void UpdataLableForm(string addStr = "")
        {
            if(Path != null)
                this.Text = "Aison - Группы команд" + " '" + new FileInfo(Path).Name + "' " + addStr;
            else this.Text = "Aison - Группы команд" + " " + addStr;
        }

        private void button_command_add_Click(object sender, EventArgs e)
        {
            // проверка 
            if (listBox_commands.Items.Contains(textBox_command_name.Text))
            {
                MessageBox.Show("Такая команда уже существует!");
                return;
            }

            if (textBox_command_name.Text.Contains("{") || textBox_command_name.Text.Contains("}"))
            {
                MessageBox.Show("В названии не могут находиться символы ‘{‘ и ‘}’!");
                return;
            }

            if(comboBox_command_type.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните тип!");
                return;
            }

            if (textBox_command_name.Text.Length < 5 || string.IsNullOrEmpty(textBox_command_name.Text))
            {
                MessageBox.Show("Имя должно быть длиннее 5 символов!");
                return;
            }

            // заполнение данных
            Command.EType eType = Command.EType.EXE;
            if (comboBox_command_type.SelectedItem.ToString() == "EXE") eType = Command.EType.EXE;
            if (comboBox_command_type.SelectedItem.ToString() == "URL") eType = Command.EType.URL;
            if (comboBox_command_type.SelectedItem.ToString() == "SERIAL") eType = Command.EType.SERIAL;
            if (comboBox_command_type.SelectedItem.ToString() == "SAY") eType = Command.EType.SAY;
            var new_comm = new Command();
            new_comm.Path = textBox_command_name.Text;
            new_comm.Type = eType;
            new_comm.Arg = textBox_command_arg_1.Text;
            new_comm.Arg_2 = textBox_command_arg_2.Text;

            Commands.Add(new_comm);
            listBox_commands.Items.Add(new_comm.Path.ToString());
            UpdataLableForm("*");
        }

        private void button_command_del_Click(object sender, EventArgs e)
        {
            if(listBox_commands.SelectedIndex != -1)
            {
                Commands.RemoveAt(listBox_commands.SelectedIndex);
                listBox_commands.Items.RemoveAt(listBox_commands.SelectedIndex);
                UpdataLableForm("*");
            }
        }

        private void listBox_commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_commands.SelectedIndex == -1) return;
            textBox_command_arg_2.Text = "";

            textBox_command_name.Text = listBox_commands.SelectedItem.ToString();
            textBox_command_arg_1.Text = Commands[listBox_commands.SelectedIndex].Arg.ToString();
            textBox_command_arg_2.Text = Commands[listBox_commands.SelectedIndex].Arg_2.ToString();
            comboBox_command_type.Text = "";
            comboBox_command_type.SelectedText = Commands[listBox_commands.SelectedIndex].Type.ToString();

            if (comboBox_command_type.Text == "SERIAL" || comboBox_command_type.Text == "EXE") textBox_command_arg_2.Enabled = true;
            else textBox_command_arg_2.Enabled = false;
        }

        private void button_file_save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void textBox_command_arg_1_TextChanged(object sender, EventArgs e)
        {
            UpdataLableForm("*");
        }

        private void textBox_command_arg_2_TextChanged(object sender, EventArgs e)
        {
            UpdataLableForm("*");
        }

        private void textBox_command_name_TextChanged(object sender, EventArgs e)
        {
            UpdataLableForm("*");
        }

        private void CommandGroudForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = this.Owner as MainForm;
            form.Visible = true;
        }

        private void button_file_find_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void Find()
        {
            var form = new FindCommandGroupForm();
            form.Owner = this;
            form.button_open.Click += delegate (object sender_, EventArgs e_)
            {
                if (form.listBox1.SelectedIndex != -1 && File.Exists(form.listBox1.Items[form.listBox1.SelectedIndex].ToString()))
                {
                    setPath(form.listBox1.Items[form.listBox1.SelectedIndex].ToString());
                    LoadData();
                    UpdataLableForm();
                    form.Close();
                }
            };
            form.ShowDialog();
        }
    }
}
