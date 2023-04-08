
namespace Aison___assistant
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer_aison_activ = new System.Windows.Forms.Timer(this.components);
            this.button_actAison = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.новаяКомандаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стандартныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.активацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повторитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перезапуститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.калькуляторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проводникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.датаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.времяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.перезагрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гибернацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.браузерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.яндексToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеЗарегистрированныеКомандыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.debagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.писатьLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посмотретьLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автозапускToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исключитьИзСпискаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дополнительноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.установкаИОчисткаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подготовитьКУдалениюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьМестоНаДискеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isAisonAct_indi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.панельКомандToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_bye_aison = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.какРаботаетПрограммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_log_message = new System.Windows.Forms.RichTextBox();
            this.listBox_custom_command = new System.Windows.Forms.ListBox();
            this.button_add_new_custom_command = new System.Windows.Forms.Button();
            this.button_edit_custom_command = new System.Windows.Forms.Button();
            this.button_remove_command = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_aison_activ
            // 
            this.timer_aison_activ.Interval = 5000;
            this.timer_aison_activ.Tick += new System.EventHandler(this.timer_aison_activ_Tick);
            // 
            // button_actAison
            // 
            this.button_actAison.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_actAison.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_actAison.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_actAison.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button_actAison.Location = new System.Drawing.Point(0, 446);
            this.button_actAison.Margin = new System.Windows.Forms.Padding(4);
            this.button_actAison.Name = "button_actAison";
            this.button_actAison.Size = new System.Drawing.Size(371, 64);
            this.button_actAison.TabIndex = 0;
            this.button_actAison.Text = "Позвать";
            this.button_actAison.UseVisualStyleBackColor = true;
            this.button_actAison.Click += new System.EventHandler(this.button_actAison_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.isAisonAct_indi,
            this.toolStripSplitButton2,
            this.toolStripButton1,
            this.toolStripButton_bye_aison,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(586, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяКомандаToolStripMenuItem,
            this.стандартныеToolStripMenuItem,
            this.всеЗарегистрированныеКомандыToolStripMenuItem,
            this.toolStripSeparator2,
            this.debagToolStripMenuItem,
            this.автозапускToolStripMenuItem,
            this.дополнительноToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(85, 24);
            this.toolStripSplitButton1.Text = "Aison";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.isAisonAct_indi_Click);
            // 
            // новаяКомандаToolStripMenuItem
            // 
            this.новаяКомандаToolStripMenuItem.Name = "новаяКомандаToolStripMenuItem";
            this.новаяКомандаToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.новаяКомандаToolStripMenuItem.Text = "Новая команда";
            this.новаяКомандаToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // стандартныеToolStripMenuItem
            // 
            this.стандартныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.активацияToolStripMenuItem,
            this.отключитьToolStripMenuItem,
            this.повторитьToolStripMenuItem,
            this.закрытьToolStripMenuItem,
            this.перезапуститьToolStripMenuItem,
            this.скрытьToolStripMenuItem,
            this.toolStripSeparator1,
            this.калькуляторToolStripMenuItem,
            this.проводникToolStripMenuItem,
            this.датаToolStripMenuItem,
            this.времяToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.webToolStripMenuItem});
            this.стандартныеToolStripMenuItem.Name = "стандартныеToolStripMenuItem";
            this.стандартныеToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.стандартныеToolStripMenuItem.Text = "Стандартные";
            // 
            // активацияToolStripMenuItem
            // 
            this.активацияToolStripMenuItem.Name = "активацияToolStripMenuItem";
            this.активацияToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.активацияToolStripMenuItem.Text = "Активация";
            this.активацияToolStripMenuItem.Click += new System.EventHandler(this.активацияToolStripMenuItem_Click);
            // 
            // отключитьToolStripMenuItem
            // 
            this.отключитьToolStripMenuItem.Name = "отключитьToolStripMenuItem";
            this.отключитьToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.отключитьToolStripMenuItem.Text = "Отключить";
            this.отключитьToolStripMenuItem.Click += new System.EventHandler(this.отключитьToolStripMenuItem_Click);
            // 
            // повторитьToolStripMenuItem
            // 
            this.повторитьToolStripMenuItem.Name = "повторитьToolStripMenuItem";
            this.повторитьToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.повторитьToolStripMenuItem.Text = "Повторить";
            this.повторитьToolStripMenuItem.Click += new System.EventHandler(this.повторитьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // перезапуститьToolStripMenuItem
            // 
            this.перезапуститьToolStripMenuItem.Name = "перезапуститьToolStripMenuItem";
            this.перезапуститьToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.перезапуститьToolStripMenuItem.Text = "Перезапустить";
            this.перезапуститьToolStripMenuItem.Click += new System.EventHandler(this.перезапуститьToolStripMenuItem_Click);
            // 
            // скрытьToolStripMenuItem
            // 
            this.скрытьToolStripMenuItem.Name = "скрытьToolStripMenuItem";
            this.скрытьToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.скрытьToolStripMenuItem.Text = "Скрыть";
            this.скрытьToolStripMenuItem.Click += new System.EventHandler(this.скрытьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // калькуляторToolStripMenuItem
            // 
            this.калькуляторToolStripMenuItem.Name = "калькуляторToolStripMenuItem";
            this.калькуляторToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.калькуляторToolStripMenuItem.Text = "Калькулятор";
            this.калькуляторToolStripMenuItem.Click += new System.EventHandler(this.калькуляторToolStripMenuItem_Click);
            // 
            // проводникToolStripMenuItem
            // 
            this.проводникToolStripMenuItem.Name = "проводникToolStripMenuItem";
            this.проводникToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.проводникToolStripMenuItem.Text = "Проводник";
            this.проводникToolStripMenuItem.Click += new System.EventHandler(this.проводникToolStripMenuItem_Click);
            // 
            // датаToolStripMenuItem
            // 
            this.датаToolStripMenuItem.Name = "датаToolStripMenuItem";
            this.датаToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.датаToolStripMenuItem.Text = "Дата";
            this.датаToolStripMenuItem.Click += new System.EventHandler(this.датаToolStripMenuItem_Click);
            // 
            // времяToolStripMenuItem
            // 
            this.времяToolStripMenuItem.Name = "времяToolStripMenuItem";
            this.времяToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.времяToolStripMenuItem.Text = "Время";
            this.времяToolStripMenuItem.Click += new System.EventHandler(this.времяToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отключитьToolStripMenuItem1,
            this.перезагрузитьToolStripMenuItem,
            this.гибернацияToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // отключитьToolStripMenuItem1
            // 
            this.отключитьToolStripMenuItem1.Name = "отключитьToolStripMenuItem1";
            this.отключитьToolStripMenuItem1.Size = new System.Drawing.Size(195, 26);
            this.отключитьToolStripMenuItem1.Text = "Отключить";
            this.отключитьToolStripMenuItem1.Click += new System.EventHandler(this.отключитьToolStripMenuItem1_Click);
            // 
            // перезагрузитьToolStripMenuItem
            // 
            this.перезагрузитьToolStripMenuItem.Name = "перезагрузитьToolStripMenuItem";
            this.перезагрузитьToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.перезагрузитьToolStripMenuItem.Text = "Перезагрузить";
            this.перезагрузитьToolStripMenuItem.Click += new System.EventHandler(this.перезагрузитьToolStripMenuItem_Click);
            // 
            // гибернацияToolStripMenuItem
            // 
            this.гибернацияToolStripMenuItem.Name = "гибернацияToolStripMenuItem";
            this.гибернацияToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.гибернацияToolStripMenuItem.Text = "Гибернация";
            this.гибернацияToolStripMenuItem.Click += new System.EventHandler(this.гибернацияToolStripMenuItem_Click);
            // 
            // webToolStripMenuItem
            // 
            this.webToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.браузерToolStripMenuItem,
            this.яндексToolStripMenuItem,
            this.googleToolStripMenuItem});
            this.webToolStripMenuItem.Name = "webToolStripMenuItem";
            this.webToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.webToolStripMenuItem.Text = "Web";
            // 
            // браузерToolStripMenuItem
            // 
            this.браузерToolStripMenuItem.Name = "браузерToolStripMenuItem";
            this.браузерToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.браузерToolStripMenuItem.Text = "Браузер";
            this.браузерToolStripMenuItem.Click += new System.EventHandler(this.браузерToolStripMenuItem_Click);
            // 
            // яндексToolStripMenuItem
            // 
            this.яндексToolStripMenuItem.Name = "яндексToolStripMenuItem";
            this.яндексToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.яндексToolStripMenuItem.Text = "Яндекс";
            this.яндексToolStripMenuItem.Click += new System.EventHandler(this.яндексToolStripMenuItem_Click);
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.googleToolStripMenuItem.Text = "Google";
            this.googleToolStripMenuItem.Click += new System.EventHandler(this.googleToolStripMenuItem_Click);
            // 
            // всеЗарегистрированныеКомандыToolStripMenuItem
            // 
            this.всеЗарегистрированныеКомандыToolStripMenuItem.Name = "всеЗарегистрированныеКомандыToolStripMenuItem";
            this.всеЗарегистрированныеКомандыToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.всеЗарегистрированныеКомандыToolStripMenuItem.Text = "Все зарегистрированные команды";
            this.всеЗарегистрированныеКомандыToolStripMenuItem.Click += new System.EventHandler(this.всеЗарегистрированныеКомандыToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(333, 6);
            // 
            // debagToolStripMenuItem
            // 
            this.debagToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.писатьLogToolStripMenuItem,
            this.посмотретьLogToolStripMenuItem});
            this.debagToolStripMenuItem.Name = "debagToolStripMenuItem";
            this.debagToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.debagToolStripMenuItem.Text = "Debag";
            // 
            // писатьLogToolStripMenuItem
            // 
            this.писатьLogToolStripMenuItem.Checked = true;
            this.писатьLogToolStripMenuItem.CheckOnClick = true;
            this.писатьLogToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.писатьLogToolStripMenuItem.Name = "писатьLogToolStripMenuItem";
            this.писатьLogToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.писатьLogToolStripMenuItem.Text = "Писать log";
            this.писатьLogToolStripMenuItem.CheckedChanged += new System.EventHandler(this.писатьLogToolStripMenuItem_CheckedChanged);
            // 
            // посмотретьLogToolStripMenuItem
            // 
            this.посмотретьLogToolStripMenuItem.Name = "посмотретьLogToolStripMenuItem";
            this.посмотретьLogToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.посмотретьLogToolStripMenuItem.Text = "Посмотреть log";
            this.посмотретьLogToolStripMenuItem.Click += new System.EventHandler(this.посмотретьLogToolStripMenuItem_Click);
            // 
            // автозапускToolStripMenuItem
            // 
            this.автозапускToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВСписокToolStripMenuItem,
            this.исключитьИзСпискаToolStripMenuItem});
            this.автозапускToolStripMenuItem.Name = "автозапускToolStripMenuItem";
            this.автозапускToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.автозапускToolStripMenuItem.Text = "Автозапуск";
            // 
            // добавитьВСписокToolStripMenuItem
            // 
            this.добавитьВСписокToolStripMenuItem.Name = "добавитьВСписокToolStripMenuItem";
            this.добавитьВСписокToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.добавитьВСписокToolStripMenuItem.Text = "Добавить в список";
            this.добавитьВСписокToolStripMenuItem.Click += new System.EventHandler(this.добавитьВСписокToolStripMenuItem_Click);
            // 
            // исключитьИзСпискаToolStripMenuItem
            // 
            this.исключитьИзСпискаToolStripMenuItem.Name = "исключитьИзСпискаToolStripMenuItem";
            this.исключитьИзСпискаToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.исключитьИзСпискаToolStripMenuItem.Text = "Исключить из списка";
            this.исключитьИзСпискаToolStripMenuItem.Click += new System.EventHandler(this.исключитьИзСпискаToolStripMenuItem_Click);
            // 
            // дополнительноToolStripMenuItem
            // 
            this.дополнительноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.установкаИОчисткаToolStripMenuItem});
            this.дополнительноToolStripMenuItem.Name = "дополнительноToolStripMenuItem";
            this.дополнительноToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.дополнительноToolStripMenuItem.Text = "Дополнительно";
            // 
            // установкаИОчисткаToolStripMenuItem
            // 
            this.установкаИОчисткаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подготовитьКУдалениюToolStripMenuItem,
            this.очиститьМестоНаДискеToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.установкаИОчисткаToolStripMenuItem.Name = "установкаИОчисткаToolStripMenuItem";
            this.установкаИОчисткаToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.установкаИОчисткаToolStripMenuItem.Text = "Установка и очистка";
            // 
            // подготовитьКУдалениюToolStripMenuItem
            // 
            this.подготовитьКУдалениюToolStripMenuItem.Name = "подготовитьКУдалениюToolStripMenuItem";
            this.подготовитьКУдалениюToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.подготовитьКУдалениюToolStripMenuItem.Text = "Подготовить к удалению";
            this.подготовитьКУдалениюToolStripMenuItem.Click += new System.EventHandler(this.подготовитьКУдалениюToolStripMenuItem_Click);
            // 
            // очиститьМестоНаДискеToolStripMenuItem
            // 
            this.очиститьМестоНаДискеToolStripMenuItem.Name = "очиститьМестоНаДискеToolStripMenuItem";
            this.очиститьМестоНаДискеToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.очиститьМестоНаДискеToolStripMenuItem.Text = "Очистить место на диске";
            this.очиститьМестоНаДискеToolStripMenuItem.Click += new System.EventHandler(this.очиститьМестоНаДискеToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // isAisonAct_indi
            // 
            this.isAisonAct_indi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.isAisonAct_indi.BackColor = System.Drawing.Color.Salmon;
            this.isAisonAct_indi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.isAisonAct_indi.Enabled = false;
            this.isAisonAct_indi.Image = ((System.Drawing.Image)(resources.GetObject("isAisonAct_indi.Image")));
            this.isAisonAct_indi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isAisonAct_indi.Name = "isAisonAct_indi";
            this.isAisonAct_indi.Size = new System.Drawing.Size(29, 24);
            this.isAisonAct_indi.Click += new System.EventHandler(this.isAisonAct_indi_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.панельКомандToolStripMenuItem});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(74, 24);
            this.toolStripSplitButton2.Text = "Вид";
            this.toolStripSplitButton2.ButtonClick += new System.EventHandler(this.toolStripSplitButton2_ButtonClick);
            // 
            // панельКомандToolStripMenuItem
            // 
            this.панельКомандToolStripMenuItem.Checked = true;
            this.панельКомандToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.панельКомандToolStripMenuItem.Enabled = false;
            this.панельКомандToolStripMenuItem.Name = "панельКомандToolStripMenuItem";
            this.панельКомандToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.панельКомандToolStripMenuItem.Text = "Панель команд";
            this.панельКомандToolStripMenuItem.CheckedChanged += new System.EventHandler(this.панельКомандToolStripMenuItem_CheckedChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(108, 24);
            this.toolStripButton1.Text = "Настройки";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton_bye_aison
            // 
            this.toolStripButton_bye_aison.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_bye_aison.Image")));
            this.toolStripButton_bye_aison.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_bye_aison.Name = "toolStripButton_bye_aison";
            this.toolStripButton_bye_aison.Size = new System.Drawing.Size(122, 24);
            this.toolStripButton_bye_aison.Text = "Купить Aison";
            this.toolStripButton_bye_aison.Click += new System.EventHandler(this.toolStripButton_bye_aison_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.какРаботаетПрограммаToolStripMenuItem});
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(143, 24);
            this.toolStripButton2.Text = "О программе";
            this.toolStripButton2.ButtonClick += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // какРаботаетПрограммаToolStripMenuItem
            // 
            this.какРаботаетПрограммаToolStripMenuItem.Name = "какРаботаетПрограммаToolStripMenuItem";
            this.какРаботаетПрограммаToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.какРаботаетПрограммаToolStripMenuItem.Text = "Как работает программа";
            this.какРаботаетПрограммаToolStripMenuItem.Click += new System.EventHandler(this.какРаботаетПрограммаToolStripMenuItem_Click);
            // 
            // textBox_log_message
            // 
            this.textBox_log_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_log_message.Location = new System.Drawing.Point(0, 16);
            this.textBox_log_message.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_log_message.Name = "textBox_log_message";
            this.textBox_log_message.Size = new System.Drawing.Size(210, 494);
            this.textBox_log_message.TabIndex = 3;
            this.textBox_log_message.Text = "";
            // 
            // listBox_custom_command
            // 
            this.listBox_custom_command.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_custom_command.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_custom_command.FormattingEnabled = true;
            this.listBox_custom_command.ItemHeight = 19;
            this.listBox_custom_command.Location = new System.Drawing.Point(4, 51);
            this.listBox_custom_command.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_custom_command.Name = "listBox_custom_command";
            this.listBox_custom_command.Size = new System.Drawing.Size(363, 391);
            this.listBox_custom_command.TabIndex = 4;
            // 
            // button_add_new_custom_command
            // 
            this.button_add_new_custom_command.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_add_new_custom_command.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add_new_custom_command.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add_new_custom_command.Location = new System.Drawing.Point(4, 19);
            this.button_add_new_custom_command.Margin = new System.Windows.Forms.Padding(4);
            this.button_add_new_custom_command.Name = "button_add_new_custom_command";
            this.button_add_new_custom_command.Size = new System.Drawing.Size(363, 32);
            this.button_add_new_custom_command.TabIndex = 5;
            this.button_add_new_custom_command.Text = "Добавить команду";
            this.button_add_new_custom_command.UseVisualStyleBackColor = true;
            this.button_add_new_custom_command.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_edit_custom_command
            // 
            this.button_edit_custom_command.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_edit_custom_command.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_edit_custom_command.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_edit_custom_command.Location = new System.Drawing.Point(0, 0);
            this.button_edit_custom_command.Margin = new System.Windows.Forms.Padding(4);
            this.button_edit_custom_command.Name = "button_edit_custom_command";
            this.button_edit_custom_command.Size = new System.Drawing.Size(363, 32);
            this.button_edit_custom_command.TabIndex = 6;
            this.button_edit_custom_command.Text = "Редактировать";
            this.button_edit_custom_command.UseVisualStyleBackColor = true;
            this.button_edit_custom_command.Click += new System.EventHandler(this.button_edit_custom_command_Click);
            // 
            // button_remove_command
            // 
            this.button_remove_command.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_remove_command.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_remove_command.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_remove_command.Location = new System.Drawing.Point(0, 32);
            this.button_remove_command.Margin = new System.Windows.Forms.Padding(4);
            this.button_remove_command.Name = "button_remove_command";
            this.button_remove_command.Size = new System.Drawing.Size(363, 32);
            this.button_remove_command.TabIndex = 7;
            this.button_remove_command.Text = "Удалить";
            this.button_remove_command.UseVisualStyleBackColor = true;
            this.button_remove_command.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.listBox_custom_command);
            this.groupBox1.Controls.Add(this.button_add_new_custom_command);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(371, 446);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ваши команды";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_remove_command);
            this.panel1.Controls.Add(this.button_edit_custom_command);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 377);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 65);
            this.panel1.TabIndex = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button_actAison);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.Controls.Add(this.textBox_log_message);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(586, 510);
            this.splitContainer1.SplitterDistance = 371;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "История:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 537);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aison";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_aison_activ;
        private System.Windows.Forms.Button button_actAison;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton isAisonAct_indi;
        private System.Windows.Forms.RichTextBox textBox_log_message;
        private System.Windows.Forms.ListBox listBox_custom_command;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.Button button_add_new_custom_command;
        private System.Windows.Forms.Button button_edit_custom_command;
        private System.Windows.Forms.Button button_remove_command;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem панельКомандToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem новаяКомандаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стандартныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem активацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отключитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повторитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перезапуститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem калькуляторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проводникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem датаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem времяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отключитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem перезагрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гибернацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem браузерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem яндексToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеЗарегистрированныеКомандыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem debagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem писатьLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem посмотретьLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem автозапускToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьВСписокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исключитьИзСпискаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дополнительноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem установкаИОчисткаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подготовитьКУдалениюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_bye_aison;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem какРаботаетПрограммаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьМестоНаДискеToolStripMenuItem;
    }
}

