namespace Aison___assistant
{
    partial class FindCommandGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindCommandGroupForm));
            this.button_find = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_find
            // 
            this.button_find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_find.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_find.Location = new System.Drawing.Point(12, 12);
            this.button_find.Name = "button_find";
            this.button_find.Size = new System.Drawing.Size(110, 36);
            this.button_find.TabIndex = 0;
            this.button_find.Text = "Поиск";
            this.button_find.UseVisualStyleBackColor = true;
            this.button_find.Click += new System.EventHandler(this.button_find_Click);
            // 
            // button_del
            // 
            this.button_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_del.Location = new System.Drawing.Point(581, 12);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(110, 36);
            this.button_del.TabIndex = 1;
            this.button_del.Text = "Удалить";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_open
            // 
            this.button_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_open.Location = new System.Drawing.Point(465, 12);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(110, 36);
            this.button_open.TabIndex = 2;
            this.button_open.Text = "Открыть";
            this.button_open.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(679, 276);
            this.listBox1.TabIndex = 4;
            // 
            // FindCommandGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 343);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_find);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindCommandGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aison - Поиск инструкций Command Group";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_find;
        private System.Windows.Forms.Button button_del;
        public System.Windows.Forms.Button button_open;
        public System.Windows.Forms.ListBox listBox1;
    }
}