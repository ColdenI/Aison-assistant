using CWR;
using System;
using System.IO;
using System.Windows.Forms;

namespace Aison___assistant
{
    public partial class AddEditDefCommandForm : Form
    {

        public Command command = null;
        private MainForm MainForm_;
        private string commands = "";

        public AddEditDefCommandForm()
        {
            InitializeComponent();
            MainForm_ = this.Owner as MainForm;
            textBox4.Enabled = false;
        }

        public AddEditDefCommandForm(Command command_)
        {
            command = command_;
            InitializeComponent();
            MainForm_ = this.Owner as MainForm;
            textBox4.Enabled = false;
            if (command.Type == Command.EType.Serial || command.Type == Command.EType.Exe) textBox4.Enabled = true;

            textBox2.Text = command.Path.Remove(command.Path.Length - 4, 4);
            if (command.Type == Command.EType.Exe) comboBox1.SelectedItem = "EXE";
            if (command.Type == Command.EType.Url) comboBox1.SelectedItem = "URL";
            if (command.Type == Command.EType.Serial) comboBox1.SelectedItem = "SERIAL";
            commands = command.Commands;
            textBox3.Text = command.Arg;
            textBox4.Text = command.Arg_2;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "SERIAL" || comboBox1.SelectedItem.ToString() == "EXE") textBox4.Enabled = true;
            else textBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните тип!");
                return;
            }

            if(textBox2.Text.Length < 5 || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Имя должно быть длиннее 5 символов!");
                return;
            }

            try
            {
               foreach(string i in commands.Split(';'))
                {
                    if(string.IsNullOrEmpty(i))
                    {
                        MessageBox.Show("Ошмбка в списке моманд!\n \nКоманды не должны быть пустыми или состоять из пробелов.\nИх должно быть хотя бы 2.");
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошмбка в списке моманд!\n \nКоманды не должны быть пустыми или состоять из пробелов.\nИх должно быть хотя бы 2.");
                return;
            }
            

            if (command != null)
            {
                File.Delete("data/custom/" + command.Path);
                MainForm.Aison.commands.Remove(command);
            }

            Command.EType eType = Command.EType.Exe;
            if (comboBox1.SelectedItem.ToString() == "EXE") eType = Command.EType.Exe;
            if (comboBox1.SelectedItem.ToString() == "URL") eType = Command.EType.Url;
            if (comboBox1.SelectedItem.ToString() == "SERIAL") eType = Command.EType.Serial;
            var new_comm = new Command();
            new_comm.Path = textBox2.Text + ".txt";
            new_comm.Commands = commands;
            new_comm.Type = eType;
            new_comm.Arg = textBox3.Text;
            new_comm.Arg_2 = textBox4.Text;

            // добавить в список только если такого ещё нет
            bool _b = false;
            if (MainForm.Aison.commands.Count != 0)
            {
                foreach (Command i in MainForm.Aison.commands)
                {
                    if (i.Path == new_comm.Path) _b = true;
                }
            }
            if (!_b)
            {
                MainForm.Aison.commands.Add(new_comm);
                MainForm.Aison.Save_CustomCommandsFile();
            }

            var cwrI = new CWRItem("data/custom/" + new_comm.Path);
            cwrI.SetOrAddItem("path", new_comm.Path);
            cwrI.SetOrAddItem("coms", new_comm.Commands);
            string str = "";
            if (new_comm.Type == Command.EType.Exe) str = "EXE";
            if (new_comm.Type == Command.EType.Url) str = "URL";
            if (new_comm.Type == Command.EType.Serial) str = "SERIAL";
            cwrI.SetOrAddItem("type", str);
            cwrI.SetOrAddItem("arg1", new_comm.Arg);
            cwrI.SetOrAddItem("arg2", new_comm.Arg_2);

            MainForm_ = this.Owner as MainForm;
            MainForm_.UI_Update();

            if (DialogResult.OK == MessageBox.Show("Данные сохранены.\nНо для работы нужно перезагрузить программу.\nХотите это сделать сейчас?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                MainForm.Aison.Com_AisonProgramReStart();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditCommandsListForm editCommandsForm = new EditCommandsListForm(commands);
            string str = "";
            editCommandsForm.buttonSave.Click += delegate (object sender_, EventArgs e_) 
            { 
                if(editCommandsForm.listBox_CommandsList.Items.Count <= 1)
                {
                    MessageBox.Show("Добавьте минимум 2 команды.", "Ой...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach(string i in editCommandsForm.listBox_CommandsList.Items)
                {
                    str += i;
                    if (editCommandsForm.listBox_CommandsList.Items.IndexOf(i) < editCommandsForm.listBox_CommandsList.Items.Count - 1) str += ";";
                }              
                //Console.WriteLine(str);
                commands = str;
                editCommandsForm.Close();
            };
            editCommandsForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            textBox3.Text = ofd.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Если вы хотите открыть какой-то сайт, то используйте тип ‘EXE’. \nВведите url адрес или путь в аргумент.\nДля типа ‘EXE’ аргумент 2 передаётся в открывающуюся программу в качестве аргумента. \n(если ненужно оставить пустым)\n \nЕсли вы хотите выполнить url запрос, то используйте тип ‘URL’\n \nПри использовании типа ‘SERIAL’: \nаргумент 1 – COM-port и скорость через ';' пример: 'COM1;9600'\nаргумент 2 - запрос", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FindSerialPortForm form = new FindSerialPortForm();
            form.button2.Click += delegate (object sender_, EventArgs e_)
            {
                textBox3.Text = form.comboBox1.Text + ";";
                form.Close();
            };
            form.ShowDialog();
        }
    }
}
