namespace DES
{
    partial class DES
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OT = new System.Windows.Forms.TextBox();
            this.ET = new System.Windows.Forms.TextBox();
            this.DT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Count1 = new System.Windows.Forms.Label();
            this.Count2 = new System.Windows.Forms.Label();
            this.Count3 = new System.Windows.Forms.Label();
            this.CBC = new System.Windows.Forms.RadioButton();
            this.ECB = new System.Windows.Forms.RadioButton();
            this.ModeDES = new System.Windows.Forms.GroupBox();
            this.Encrypt = new System.Windows.Forms.Button();
            this.keyText = new System.Windows.Forms.TextBox();
            this.Decryption = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Generate = new System.Windows.Forms.Button();
            this.GenError = new System.Windows.Forms.Button();
            this.PosErr = new System.Windows.Forms.Label();
            this.ModeDES.SuspendLayout();
            this.SuspendLayout();
            // 
            // OT
            // 
            this.OT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OT.Location = new System.Drawing.Point(21, 153);
            this.OT.Margin = new System.Windows.Forms.Padding(4);
            this.OT.Multiline = true;
            this.OT.Name = "OT";
            this.OT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OT.Size = new System.Drawing.Size(400, 150);
            this.OT.TabIndex = 0;
            this.OT.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // ET
            // 
            this.ET.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ET.Location = new System.Drawing.Point(427, 153);
            this.ET.Margin = new System.Windows.Forms.Padding(4);
            this.ET.Multiline = true;
            this.ET.Name = "ET";
            this.ET.ReadOnly = true;
            this.ET.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ET.Size = new System.Drawing.Size(400, 150);
            this.ET.TabIndex = 1;
            this.ET.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // DT
            // 
            this.DT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT.Location = new System.Drawing.Point(837, 153);
            this.DT.Margin = new System.Windows.Forms.Padding(4);
            this.DT.Multiline = true;
            this.DT.Name = "DT";
            this.DT.ReadOnly = true;
            this.DT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DT.Size = new System.Drawing.Size(400, 150);
            this.DT.TabIndex = 2;
            this.DT.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "ОТ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "ШТ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(837, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "ОТ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Символов:";
            // 
            // Count1
            // 
            this.Count1.AutoSize = true;
            this.Count1.Location = new System.Drawing.Point(378, 133);
            this.Count1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Count1.Name = "Count1";
            this.Count1.Size = new System.Drawing.Size(16, 17);
            this.Count1.TabIndex = 16;
            this.Count1.Text = "0";
            // 
            // Count2
            // 
            this.Count2.AutoSize = true;
            this.Count2.Location = new System.Drawing.Point(787, 133);
            this.Count2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Count2.Name = "Count2";
            this.Count2.Size = new System.Drawing.Size(16, 17);
            this.Count2.TabIndex = 18;
            this.Count2.Text = "0";
            this.Count2.Visible = false;
            // 
            // Count3
            // 
            this.Count3.AutoSize = true;
            this.Count3.Location = new System.Drawing.Point(1194, 133);
            this.Count3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Count3.Name = "Count3";
            this.Count3.Size = new System.Drawing.Size(16, 17);
            this.Count3.TabIndex = 19;
            this.Count3.Text = "0";
            this.Count3.Visible = false;
            // 
            // CBC
            // 
            this.CBC.AutoSize = true;
            this.CBC.Location = new System.Drawing.Point(28, 53);
            this.CBC.Margin = new System.Windows.Forms.Padding(4);
            this.CBC.Name = "CBC";
            this.CBC.Size = new System.Drawing.Size(241, 21);
            this.CBC.TabIndex = 13;
            this.CBC.TabStop = true;
            this.CBC.Text = "CBC (сцепление блоков шифра)";
            this.CBC.UseVisualStyleBackColor = true;
            this.CBC.CheckedChanged += new System.EventHandler(this.modeCheckedChanged);
            // 
            // ECB
            // 
            this.ECB.AutoSize = true;
            this.ECB.Checked = true;
            this.ECB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ECB.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.ECB.Location = new System.Drawing.Point(28, 23);
            this.ECB.Margin = new System.Windows.Forms.Padding(4);
            this.ECB.Name = "ECB";
            this.ECB.Size = new System.Drawing.Size(253, 22);
            this.ECB.TabIndex = 12;
            this.ECB.TabStop = true;
            this.ECB.Text = " ECB (электронный кодоблокнот)";
            this.ECB.UseVisualStyleBackColor = true;
            this.ECB.CheckedChanged += new System.EventHandler(this.modeCheckedChanged);
            // 
            // ModeDES
            // 
            this.ModeDES.Controls.Add(this.ECB);
            this.ModeDES.Controls.Add(this.CBC);
            this.ModeDES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModeDES.Location = new System.Drawing.Point(24, 35);
            this.ModeDES.Margin = new System.Windows.Forms.Padding(4);
            this.ModeDES.Name = "ModeDES";
            this.ModeDES.Padding = new System.Windows.Forms.Padding(4);
            this.ModeDES.Size = new System.Drawing.Size(456, 88);
            this.ModeDES.TabIndex = 11;
            this.ModeDES.TabStop = false;
            this.ModeDES.Text = "Режима работы";
            // 
            // Encrypt
            // 
            this.Encrypt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Encrypt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Encrypt.Location = new System.Drawing.Point(672, 40);
            this.Encrypt.Margin = new System.Windows.Forms.Padding(4);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(131, 31);
            this.Encrypt.TabIndex = 12;
            this.Encrypt.Text = "Зашифровать";
            this.Encrypt.UseVisualStyleBackColor = false;
            this.Encrypt.Click += new System.EventHandler(this.ButtonClick);
            // 
            // keyText
            // 
            this.keyText.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.keyText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyText.Location = new System.Drawing.Point(559, 47);
            this.keyText.Margin = new System.Windows.Forms.Padding(4);
            this.keyText.MaxLength = 8;
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(73, 22);
            this.keyText.TabIndex = 13;
            // 
            // Decryption
            // 
            this.Decryption.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Decryption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Decryption.Location = new System.Drawing.Point(672, 87);
            this.Decryption.Margin = new System.Windows.Forms.Padding(4);
            this.Decryption.Name = "Decryption";
            this.Decryption.Size = new System.Drawing.Size(131, 31);
            this.Decryption.TabIndex = 21;
            this.Decryption.Text = "Расшифровать";
            this.Decryption.UseVisualStyleBackColor = false;
            this.Decryption.Click += new System.EventHandler(this.ButtonClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(504, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ключ:";
            // 
            // Generate
            // 
            this.Generate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Generate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Generate.Location = new System.Drawing.Point(507, 77);
            this.Generate.Margin = new System.Windows.Forms.Padding(4);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(125, 30);
            this.Generate.TabIndex = 23;
            this.Generate.Text = "Сгенерировать";
            this.Generate.UseVisualStyleBackColor = false;
            this.Generate.Click += new System.EventHandler(this.ButtonClick);
            // 
            // GenError
            // 
            this.GenError.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GenError.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GenError.Location = new System.Drawing.Point(840, 56);
            this.GenError.Margin = new System.Windows.Forms.Padding(4);
            this.GenError.Name = "GenError";
            this.GenError.Size = new System.Drawing.Size(131, 53);
            this.GenError.TabIndex = 12;
            this.GenError.Text = "Ошибка в ШТ";
            this.GenError.UseVisualStyleBackColor = false;
            this.GenError.Visible = false;
            this.GenError.Click += new System.EventHandler(this.ButtonClick);
            // 
            // PosErr
            // 
            this.PosErr.AutoSize = true;
            this.PosErr.Location = new System.Drawing.Point(978, 60);
            this.PosErr.Name = "PosErr";
            this.PosErr.Size = new System.Drawing.Size(51, 17);
            this.PosErr.TabIndex = 24;
            this.PosErr.Text = "PosErr";
            this.PosErr.Visible = false;
            // 
            // DES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1252, 323);
            this.Controls.Add(this.PosErr);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Decryption);
            this.Controls.Add(this.Count3);
            this.Controls.Add(this.Count2);
            this.Controls.Add(this.Count1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.GenError);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.ModeDES);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DT);
            this.Controls.Add(this.ET);
            this.Controls.Add(this.OT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DES";
            this.Text = "DES: ECB, CBC";
            this.ModeDES.ResumeLayout(false);
            this.ModeDES.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OT;
        private System.Windows.Forms.TextBox ET;
        private System.Windows.Forms.TextBox DT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Count1;
        private System.Windows.Forms.Label Count2;
        private System.Windows.Forms.Label Count3;
        private System.Windows.Forms.RadioButton CBC;
        private System.Windows.Forms.RadioButton ECB;
        private System.Windows.Forms.GroupBox ModeDES;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.Button Decryption;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Button GenError;
        private System.Windows.Forms.Label PosErr;
    }
}

