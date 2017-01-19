namespace Monitor
{
    partial class chargemember
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.maskedTextBox_money = new System.Windows.Forms.MaskedTextBox();
            this.checkBox_noat = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Нэр :";
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(23, 48);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(192, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Мөнгөн дүн :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Enabled = false;
            this.simpleButton1.Location = new System.Drawing.Point(140, 128);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "OK";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // maskedTextBox_money
            // 
            this.maskedTextBox_money.Location = new System.Drawing.Point(23, 94);
            this.maskedTextBox_money.Mask = "00000";
            this.maskedTextBox_money.Name = "maskedTextBox_money";
            this.maskedTextBox_money.Size = new System.Drawing.Size(192, 21);
            this.maskedTextBox_money.TabIndex = 5;
            this.maskedTextBox_money.ValidatingType = typeof(int);
            this.maskedTextBox_money.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox_money_MaskInputRejected);
            this.maskedTextBox_money.TextChanged += new System.EventHandler(this.maskedTextBox_money_TextChanged);
            // 
            // checkBox_noat
            // 
            this.checkBox_noat.AutoSize = true;
            this.checkBox_noat.Location = new System.Drawing.Point(23, 130);
            this.checkBox_noat.Name = "checkBox_noat";
            this.checkBox_noat.Size = new System.Drawing.Size(91, 17);
            this.checkBox_noat.TabIndex = 6;
            this.checkBox_noat.Text = "НӨАТ хэвлэх";
            this.checkBox_noat.UseVisualStyleBackColor = true;
            // 
            // chargemember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 172);
            this.Controls.Add(this.checkBox_noat);
            this.Controls.Add(this.maskedTextBox_money);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "chargemember";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Цэнэглэх";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.TextEdit textEdit1;
        public System.Windows.Forms.MaskedTextBox maskedTextBox_money;
        public System.Windows.Forms.CheckBox checkBox_noat;
    }
}