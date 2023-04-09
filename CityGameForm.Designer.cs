namespace Aison___assistant
{
    partial class CityGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CityGameForm));
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_maxScore = new System.Windows.Forms.Label();
            this.label_score = new System.Windows.Forms.Label();
            this.label_old_city = new System.Windows.Forms.Label();
            this.label_old_old_city = new System.Windows.Forms.Label();
            this.button_help = new System.Windows.Forms.Button();
            this.button_text_apply = new System.Windows.Forms.Button();
            this.textBox_text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(7, 342);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(130, 56);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.trackBar1, "Чувствительность распознания");
            this.trackBar1.Value = 45;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.label_maxScore);
            this.panel1.Controls.Add(this.label_score);
            this.panel1.Location = new System.Drawing.Point(7, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 245);
            this.panel1.TabIndex = 0;
            // 
            // label_maxScore
            // 
            this.label_maxScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_maxScore.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_maxScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_maxScore.Location = new System.Drawing.Point(171, 0);
            this.label_maxScore.Name = "label_maxScore";
            this.label_maxScore.Size = new System.Drawing.Size(100, 23);
            this.label_maxScore.TabIndex = 1;
            this.label_maxScore.Text = "0";
            this.label_maxScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_score
            // 
            this.label_score.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_score.Font = new System.Drawing.Font("MingLiU-ExtB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label_score.Location = new System.Drawing.Point(-1, 0);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(271, 57);
            this.label_score.TabIndex = 0;
            this.label_score.Text = "0";
            this.label_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_old_city
            // 
            this.label_old_city.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_old_city.Location = new System.Drawing.Point(7, 216);
            this.label_old_city.Name = "label_old_city";
            this.label_old_city.Size = new System.Drawing.Size(271, 29);
            this.label_old_city.TabIndex = 1;
            this.label_old_city.Text = "ujhjl";
            this.label_old_city.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label_old_city, "Последний город");
            // 
            // label_old_old_city
            // 
            this.label_old_old_city.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_old_old_city.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_old_old_city.Location = new System.Drawing.Point(7, 243);
            this.label_old_old_city.Name = "label_old_old_city";
            this.label_old_old_city.Size = new System.Drawing.Size(271, 25);
            this.label_old_old_city.TabIndex = 2;
            this.label_old_old_city.Text = "ijhjl";
            this.label_old_old_city.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label_old_old_city, "Предыдущий город");
            // 
            // button_help
            // 
            this.button_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_help.Location = new System.Drawing.Point(7, 303);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(130, 31);
            this.button_help.TabIndex = 3;
            this.button_help.Text = "Подсказка";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // button_text_apply
            // 
            this.button_text_apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_text_apply.Location = new System.Drawing.Point(148, 303);
            this.button_text_apply.Name = "button_text_apply";
            this.button_text_apply.Size = new System.Drawing.Size(130, 31);
            this.button_text_apply.TabIndex = 2;
            this.button_text_apply.Text = "Применить";
            this.button_text_apply.UseVisualStyleBackColor = true;
            this.button_text_apply.Click += new System.EventHandler(this.button_text_apply_Click);
            // 
            // textBox_text
            // 
            this.textBox_text.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_text.Location = new System.Drawing.Point(7, 271);
            this.textBox_text.Name = "textBox_text";
            this.textBox_text.Size = new System.Drawing.Size(271, 28);
            this.textBox_text.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox_text, "Введите или произнесите имя города");
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(148, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Правила";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CityGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 380);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_text);
            this.Controls.Add(this.button_text_apply);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.label_old_old_city);
            this.Controls.Add(this.label_old_city);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CityGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра в города";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CityGameForm_FormClosing);
            this.Load += new System.EventHandler(this.CityGameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_old_city;
        private System.Windows.Forms.Label label_old_old_city;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_text_apply;
        private System.Windows.Forms.TextBox textBox_text;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Label label_maxScore;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}