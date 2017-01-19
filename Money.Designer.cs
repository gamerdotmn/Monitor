namespace Monitor
{
    partial class Money
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_price = new DevExpress.XtraEditors.TextEdit();
            this.button_ok = new DevExpress.XtraEditors.SimpleButton();
            this.maskedTextBox_price = new System.Windows.Forms.MaskedTextBox();
            this.checkBox_noat = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_price.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Мөнгөн дүн:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Бодогдсон дүн:";
            // 
            // textBox_price
            // 
            this.textBox_price.Enabled = false;
            this.textBox_price.Location = new System.Drawing.Point(15, 115);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Properties.Mask.EditMask = "n0";
            this.textBox_price.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textBox_price.Size = new System.Drawing.Size(218, 20);
            this.textBox_price.TabIndex = 4;
            // 
            // button_ok
            // 
            this.button_ok.Enabled = false;
            this.button_ok.Location = new System.Drawing.Point(158, 152);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 5;
            this.button_ok.Text = "OK";
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // maskedTextBox_price
            // 
            this.maskedTextBox_price.Location = new System.Drawing.Point(15, 56);
            this.maskedTextBox_price.Mask = "00000";
            this.maskedTextBox_price.Name = "maskedTextBox_price";
            this.maskedTextBox_price.Size = new System.Drawing.Size(218, 21);
            this.maskedTextBox_price.TabIndex = 6;
            this.maskedTextBox_price.ValidatingType = typeof(int);
            this.maskedTextBox_price.TextChanged += new System.EventHandler(this.maskedTextBox_price_TextChanged_1);
            this.maskedTextBox_price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox_price_KeyDown_1);
            // 
            // checkBox_noat
            // 
            this.checkBox_noat.AutoSize = true;
            this.checkBox_noat.Location = new System.Drawing.Point(15, 152);
            this.checkBox_noat.Name = "checkBox_noat";
            this.checkBox_noat.Size = new System.Drawing.Size(91, 17);
            this.checkBox_noat.TabIndex = 8;
            this.checkBox_noat.Text = "НӨАТ хэвлэх";
            this.checkBox_noat.UseVisualStyleBackColor = true;
            // 
            // Money
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 198);
            this.Controls.Add(this.checkBox_noat);
            this.Controls.Add(this.maskedTextBox_price);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_price);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Money";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Нээх";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.textBox_price.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit textBox_price;
        private DevExpress.XtraEditors.SimpleButton button_ok;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_price;
        public System.Windows.Forms.CheckBox checkBox_noat;
    }
}