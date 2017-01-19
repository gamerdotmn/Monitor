namespace Monitor
{
    partial class addTimez
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
            this.textEdit_name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_stock = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_price = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit_begd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit_endd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelerr1 = new Monitor.Labelerr();
            this.simpleButton_edit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_stock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_price.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_begd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_endd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_name
            // 
            this.textEdit_name.Location = new System.Drawing.Point(76, 21);
            this.textEdit_name.Name = "textEdit_name";
            this.textEdit_name.Size = new System.Drawing.Size(167, 20);
            this.textEdit_name.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Нэр :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Хэмжээ :";
            // 
            // textEdit_stock
            // 
            this.textEdit_stock.Location = new System.Drawing.Point(76, 55);
            this.textEdit_stock.Name = "textEdit_stock";
            this.textEdit_stock.Properties.Mask.EditMask = "n0";
            this.textEdit_stock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_stock.Size = new System.Drawing.Size(167, 20);
            this.textEdit_stock.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 97);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Үнэ :";
            // 
            // textEdit_price
            // 
            this.textEdit_price.Location = new System.Drawing.Point(76, 94);
            this.textEdit_price.Name = "textEdit_price";
            this.textEdit_price.Properties.Mask.EditMask = "n0";
            this.textEdit_price.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_price.Size = new System.Drawing.Size(167, 20);
            this.textEdit_price.TabIndex = 5;
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(173, 160);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_ok.TabIndex = 6;
            this.simpleButton_ok.Text = "Хадгалах";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // comboBoxEdit_begd
            // 
            this.comboBoxEdit_begd.Location = new System.Drawing.Point(83, 125);
            this.comboBoxEdit_begd.Name = "comboBoxEdit_begd";
            this.comboBoxEdit_begd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_begd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_begd.Size = new System.Drawing.Size(40, 20);
            this.comboBoxEdit_begd.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 130);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Эхлэх цаг:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(133, 129);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(64, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Дуусах цаг :";
            // 
            // comboBoxEdit_endd
            // 
            this.comboBoxEdit_endd.Location = new System.Drawing.Point(203, 126);
            this.comboBoxEdit_endd.Name = "comboBoxEdit_endd";
            this.comboBoxEdit_endd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_endd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_endd.Size = new System.Drawing.Size(40, 20);
            this.comboBoxEdit_endd.TabIndex = 10;
            // 
            // labelerr1
            // 
            this.labelerr1.AutoSize = true;
            this.labelerr1.Location = new System.Drawing.Point(7, 165);
            this.labelerr1.Name = "labelerr1";
            this.labelerr1.Size = new System.Drawing.Size(0, 13);
            this.labelerr1.TabIndex = 11;
            // 
            // simpleButton_edit
            // 
            this.simpleButton_edit.Location = new System.Drawing.Point(173, 160);
            this.simpleButton_edit.Name = "simpleButton_edit";
            this.simpleButton_edit.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_edit.TabIndex = 12;
            this.simpleButton_edit.Text = "Засах";
            this.simpleButton_edit.Click += new System.EventHandler(this.simpleButton_edit_Click);
            // 
            // addTimez
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 195);
            this.Controls.Add(this.simpleButton_edit);
            this.Controls.Add(this.labelerr1);
            this.Controls.Add(this.comboBoxEdit_endd);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.comboBoxEdit_begd);
            this.Controls.Add(this.simpleButton_ok);
            this.Controls.Add(this.textEdit_price);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.textEdit_stock);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit_name);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addTimez";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Цагны загвар нэмэх";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_stock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_price.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_begd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_endd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_name;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit_stock;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit_price;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ok;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_begd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_endd;
        private Labelerr labelerr1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_edit;
    }
}