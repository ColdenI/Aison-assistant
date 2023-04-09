
namespace Aison___assistant
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_volue = new System.Windows.Forms.TrackBar();
            this.button_volue = new System.Windows.Forms.Button();
            this.label_volue = new System.Windows.Forms.Label();
            this.label_timeAct = new System.Windows.Forms.Label();
            this.button_timeAct = new System.Windows.Forms.Button();
            this.trackBar_timeAct = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_delayOffView = new System.Windows.Forms.Label();
            this.button_delayOffView = new System.Windows.Forms.Button();
            this.trackBar_delayOffView = new System.Windows.Forms.TrackBar();
            this.label_sensitivity = new System.Windows.Forms.Label();
            this.button_sensitivity = new System.Windows.Forms.Button();
            this.trackBar_sensitivity = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_timeAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_delayOffView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_sensitivity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Громкость речи:";
            this.toolTip1.SetToolTip(this.label1, "Громкость синтеза речи.");
            // 
            // trackBar_volue
            // 
            this.trackBar_volue.Location = new System.Drawing.Point(247, 15);
            this.trackBar_volue.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_volue.Maximum = 100;
            this.trackBar_volue.Name = "trackBar_volue";
            this.trackBar_volue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_volue.Size = new System.Drawing.Size(320, 56);
            this.trackBar_volue.TabIndex = 1;
            this.trackBar_volue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_volue.Scroll += new System.EventHandler(this.trackBar_volue_Scroll);
            // 
            // button_volue
            // 
            this.button_volue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_volue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_volue.Location = new System.Drawing.Point(663, 23);
            this.button_volue.Margin = new System.Windows.Forms.Padding(4);
            this.button_volue.Name = "button_volue";
            this.button_volue.Size = new System.Drawing.Size(151, 39);
            this.button_volue.TabIndex = 2;
            this.button_volue.Text = "Применить";
            this.button_volue.UseVisualStyleBackColor = true;
            this.button_volue.Click += new System.EventHandler(this.button_volue_Click);
            // 
            // label_volue
            // 
            this.label_volue.AutoSize = true;
            this.label_volue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_volue.Location = new System.Drawing.Point(575, 27);
            this.label_volue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_volue.Name = "label_volue";
            this.label_volue.Size = new System.Drawing.Size(67, 29);
            this.label_volue.TabIndex = 3;
            this.label_volue.Text = "00 %";
            // 
            // label_timeAct
            // 
            this.label_timeAct.AutoSize = true;
            this.label_timeAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_timeAct.Location = new System.Drawing.Point(575, 94);
            this.label_timeAct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_timeAct.Name = "label_timeAct";
            this.label_timeAct.Size = new System.Drawing.Size(70, 24);
            this.label_timeAct.TabIndex = 7;
            this.label_timeAct.Text = "100000";
            // 
            // button_timeAct
            // 
            this.button_timeAct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_timeAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_timeAct.Location = new System.Drawing.Point(663, 86);
            this.button_timeAct.Margin = new System.Windows.Forms.Padding(4);
            this.button_timeAct.Name = "button_timeAct";
            this.button_timeAct.Size = new System.Drawing.Size(151, 39);
            this.button_timeAct.TabIndex = 4;
            this.button_timeAct.Text = "Применить";
            this.button_timeAct.UseVisualStyleBackColor = true;
            this.button_timeAct.Click += new System.EventHandler(this.button_timeAct_Click);
            // 
            // trackBar_timeAct
            // 
            this.trackBar_timeAct.Location = new System.Drawing.Point(247, 78);
            this.trackBar_timeAct.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_timeAct.Maximum = 180;
            this.trackBar_timeAct.Minimum = 5;
            this.trackBar_timeAct.Name = "trackBar_timeAct";
            this.trackBar_timeAct.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_timeAct.Size = new System.Drawing.Size(320, 56);
            this.trackBar_timeAct.TabIndex = 3;
            this.trackBar_timeAct.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_timeAct.Value = 180;
            this.trackBar_timeAct.Scroll += new System.EventHandler(this.trackBar_timeAct_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(19, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Время активности:";
            this.toolTip1.SetToolTip(this.label4, "Время которое будет активен Aison до ого как заснёт. (в секундах)");
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(20, 156);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(194, 17);
            this.label.TabIndex = 8;
            this.label.Text = "Задержка на исчезновение:";
            this.toolTip1.SetToolTip(this.label, "Время через которое Aison скроется. (в секундах)");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 220);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Чувствительность распознания:";
            this.toolTip1.SetToolTip(this.label3, "Чувствительность распознания (20 - 100)");
            // 
            // label_delayOffView
            // 
            this.label_delayOffView.AutoSize = true;
            this.label_delayOffView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_delayOffView.Location = new System.Drawing.Point(575, 156);
            this.label_delayOffView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_delayOffView.Name = "label_delayOffView";
            this.label_delayOffView.Size = new System.Drawing.Size(70, 24);
            this.label_delayOffView.TabIndex = 11;
            this.label_delayOffView.Text = "100000";
            // 
            // button_delayOffView
            // 
            this.button_delayOffView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delayOffView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_delayOffView.Location = new System.Drawing.Point(663, 149);
            this.button_delayOffView.Margin = new System.Windows.Forms.Padding(4);
            this.button_delayOffView.Name = "button_delayOffView";
            this.button_delayOffView.Size = new System.Drawing.Size(151, 39);
            this.button_delayOffView.TabIndex = 6;
            this.button_delayOffView.Text = "Применить";
            this.button_delayOffView.UseVisualStyleBackColor = true;
            this.button_delayOffView.Click += new System.EventHandler(this.button_delayOffView_Click);
            // 
            // trackBar_delayOffView
            // 
            this.trackBar_delayOffView.Location = new System.Drawing.Point(247, 140);
            this.trackBar_delayOffView.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_delayOffView.Maximum = 3600;
            this.trackBar_delayOffView.Minimum = 30;
            this.trackBar_delayOffView.Name = "trackBar_delayOffView";
            this.trackBar_delayOffView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_delayOffView.Size = new System.Drawing.Size(320, 56);
            this.trackBar_delayOffView.TabIndex = 5;
            this.trackBar_delayOffView.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_delayOffView.Value = 30;
            this.trackBar_delayOffView.Scroll += new System.EventHandler(this.trackBar_delayOffView_Scroll);
            // 
            // label_sensitivity
            // 
            this.label_sensitivity.AutoSize = true;
            this.label_sensitivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sensitivity.Location = new System.Drawing.Point(576, 220);
            this.label_sensitivity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_sensitivity.Name = "label_sensitivity";
            this.label_sensitivity.Size = new System.Drawing.Size(30, 24);
            this.label_sensitivity.TabIndex = 15;
            this.label_sensitivity.Text = "70";
            // 
            // button_sensitivity
            // 
            this.button_sensitivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sensitivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_sensitivity.Location = new System.Drawing.Point(663, 213);
            this.button_sensitivity.Margin = new System.Windows.Forms.Padding(4);
            this.button_sensitivity.Name = "button_sensitivity";
            this.button_sensitivity.Size = new System.Drawing.Size(151, 39);
            this.button_sensitivity.TabIndex = 13;
            this.button_sensitivity.Text = "Применить";
            this.button_sensitivity.UseVisualStyleBackColor = true;
            this.button_sensitivity.Click += new System.EventHandler(this.button_sensitivity_Click);
            // 
            // trackBar_sensitivity
            // 
            this.trackBar_sensitivity.Location = new System.Drawing.Point(247, 204);
            this.trackBar_sensitivity.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_sensitivity.Maximum = 100;
            this.trackBar_sensitivity.Minimum = 20;
            this.trackBar_sensitivity.Name = "trackBar_sensitivity";
            this.trackBar_sensitivity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_sensitivity.Size = new System.Drawing.Size(320, 56);
            this.trackBar_sensitivity.TabIndex = 12;
            this.trackBar_sensitivity.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_sensitivity.Value = 30;
            this.trackBar_sensitivity.Scroll += new System.EventHandler(this.trackBar_sensitivity_Scroll);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 275);
            this.Controls.Add(this.label_sensitivity);
            this.Controls.Add(this.button_sensitivity);
            this.Controls.Add(this.trackBar_sensitivity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_delayOffView);
            this.Controls.Add(this.button_delayOffView);
            this.Controls.Add(this.trackBar_delayOffView);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label_timeAct);
            this.Controls.Add(this.button_timeAct);
            this.Controls.Add(this.trackBar_timeAct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_volue);
            this.Controls.Add(this.button_volue);
            this.Controls.Add(this.trackBar_volue);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aison - Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_timeAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_delayOffView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_sensitivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar_volue;
        private System.Windows.Forms.Button button_volue;
        private System.Windows.Forms.Label label_volue;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_timeAct;
        private System.Windows.Forms.Button button_timeAct;
        private System.Windows.Forms.TrackBar trackBar_timeAct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_delayOffView;
        private System.Windows.Forms.Button button_delayOffView;
        private System.Windows.Forms.TrackBar trackBar_delayOffView;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label_sensitivity;
        private System.Windows.Forms.Button button_sensitivity;
        private System.Windows.Forms.TrackBar trackBar_sensitivity;
        private System.Windows.Forms.Label label3;
    }
}