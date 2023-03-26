namespace Enc_And_Dec_By_DES_Or_AES
{
    partial class FileEncAndDec
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
            this.EncOrDec = new System.Windows.Forms.Button();
            this.fileDrop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.strKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbDES = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAES = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.genKey = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fileDrop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EncOrDec
            // 
            this.EncOrDec.Enabled = false;
            this.EncOrDec.Location = new System.Drawing.Point(434, 395);
            this.EncOrDec.Name = "EncOrDec";
            this.EncOrDec.Size = new System.Drawing.Size(144, 32);
            this.EncOrDec.TabIndex = 0;
            this.EncOrDec.Text = "Зашифровать";
            this.EncOrDec.UseVisualStyleBackColor = true;
            this.EncOrDec.Click += new System.EventHandler(this.EncOrDec_Click);
            // 
            // fileDrop
            // 
            this.fileDrop.AllowDrop = true;
            this.fileDrop.Controls.Add(this.label1);
            this.fileDrop.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileDrop.Location = new System.Drawing.Point(0, 0);
            this.fileDrop.Name = "fileDrop";
            this.fileDrop.Size = new System.Drawing.Size(800, 368);
            this.fileDrop.TabIndex = 1;
            this.fileDrop.Click += new System.EventHandler(this.fileDrop_Click);
            this.fileDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileDrop_DragDrop);
            this.fileDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileDrop_DragEnter);
            this.fileDrop.DragLeave += new System.EventHandler(this.fileDrop_DragLeave);
            this.fileDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.fileDrop_Paint);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(797, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Перетащите сюда файл или нажмите на область, чтобы выбрать файл";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // strKey
            // 
            this.strKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.strKey.Location = new System.Drawing.Point(56, 400);
            this.strKey.MaxLength = 8;
            this.strKey.Name = "strKey";
            this.strKey.Size = new System.Drawing.Size(199, 22);
            this.strKey.TabIndex = 2;
            this.strKey.Tag = "";
            this.strKey.Text = "MySecret";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key:";
            // 
            // rbDES
            // 
            this.rbDES.AutoSize = true;
            this.rbDES.Checked = true;
            this.rbDES.Location = new System.Drawing.Point(18, 27);
            this.rbDES.Name = "rbDES";
            this.rbDES.Size = new System.Drawing.Size(56, 20);
            this.rbDES.TabIndex = 4;
            this.rbDES.TabStop = true;
            this.rbDES.Text = "DES";
            this.rbDES.UseVisualStyleBackColor = true;
            this.rbDES.CheckedChanged += new System.EventHandler(this.rbDES_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAES);
            this.groupBox1.Controls.Add(this.rbDES);
            this.groupBox1.Location = new System.Drawing.Point(584, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 64);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Алгоритм шифрования";
            // 
            // rbAES
            // 
            this.rbAES.AutoSize = true;
            this.rbAES.Location = new System.Drawing.Point(129, 27);
            this.rbAES.Name = "rbAES";
            this.rbAES.Size = new System.Drawing.Size(55, 20);
            this.rbAES.TabIndex = 5;
            this.rbAES.Text = "AES";
            this.rbAES.UseVisualStyleBackColor = true;
            this.rbAES.CheckedChanged += new System.EventHandler(this.rbAES_CheckedChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // genKey
            // 
            this.genKey.Location = new System.Drawing.Point(266, 395);
            this.genKey.Name = "genKey";
            this.genKey.Size = new System.Drawing.Size(162, 32);
            this.genKey.TabIndex = 6;
            this.genKey.Text = "Сгенерировать ключ";
            this.genKey.UseVisualStyleBackColor = true;
            this.genKey.Click += new System.EventHandler(this.genKey_Click);
            // 
            // FileEncAndDec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.genKey);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.strKey);
            this.Controls.Add(this.fileDrop);
            this.Controls.Add(this.EncOrDec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FileEncAndDec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileEncAndDec";
            this.fileDrop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EncOrDec;
        private System.Windows.Forms.Panel fileDrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox strKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbDES;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAES;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button genKey;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

