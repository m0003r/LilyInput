namespace LilyInput
{
    partial class SettingsWindow
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
            this.KeySign = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.major = new System.Windows.Forms.RadioButton();
            this.minor = new System.Windows.Forms.RadioButton();
            this.DeviceList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KeySign)).BeginInit();
            this.SuspendLayout();
            // 
            // KeySign
            // 
            this.KeySign.Location = new System.Drawing.Point(13, 35);
            this.KeySign.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.KeySign.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            -2147483648});
            this.KeySign.Name = "KeySign";
            this.KeySign.Size = new System.Drawing.Size(151, 20);
            this.KeySign.TabIndex = 0;
            this.KeySign.ValueChanged += new System.EventHandler(this.KeySign_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Знаки";
            // 
            // major
            // 
            this.major.AutoSize = true;
            this.major.Checked = true;
            this.major.Location = new System.Drawing.Point(187, 19);
            this.major.Name = "major";
            this.major.Size = new System.Drawing.Size(59, 17);
            this.major.TabIndex = 2;
            this.major.TabStop = true;
            this.major.Text = "мажор";
            this.major.UseVisualStyleBackColor = true;
            this.major.CheckedChanged += new System.EventHandler(this.major_CheckedChanged);
            // 
            // minor
            // 
            this.minor.AutoSize = true;
            this.minor.Location = new System.Drawing.Point(187, 42);
            this.minor.Name = "minor";
            this.minor.Size = new System.Drawing.Size(57, 17);
            this.minor.TabIndex = 3;
            this.minor.Text = "минор";
            this.minor.UseVisualStyleBackColor = true;
            this.minor.CheckedChanged += new System.EventHandler(this.minor_CheckedChanged);
            // 
            // DeviceList
            // 
            this.DeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceList.FormattingEnabled = true;
            this.DeviceList.Location = new System.Drawing.Point(13, 88);
            this.DeviceList.Name = "DeviceList";
            this.DeviceList.Size = new System.Drawing.Size(151, 21);
            this.DeviceList.TabIndex = 4;
            this.DeviceList.SelectedIndexChanged += new System.EventHandler(this.DeviceList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Девайс";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 132);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeviceList);
            this.Controls.Add(this.minor);
            this.Controls.Add(this.major);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeySign);
            this.Name = "SettingsWindow";
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.KeySign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown KeySign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton major;
        private System.Windows.Forms.RadioButton minor;
        private System.Windows.Forms.ComboBox DeviceList;
        private System.Windows.Forms.Label label2;
    }
}

