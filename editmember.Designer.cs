namespace Monitor
{
    partial class editmember
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
            this.textEdit_pwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            
            this.textEdit_stock = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_stock.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_name
            // 
            this.textEdit_name.Enabled = false;
            this.textEdit_name.Location = new System.Drawing.Point(56, 26);
            this.textEdit_name.Name = "textEdit_name";
            this.textEdit_name.Size = new System.Drawing.Size(160, 20);
            this.textEdit_name.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Нэр :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 81);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Нууц үг :";
            // 
            // textEdit_pwd
            // 
            this.textEdit_pwd.Location = new System.Drawing.Point(56, 52);
            this.textEdit_pwd.Name = "textEdit_pwd";
            this.textEdit_pwd.Properties.PasswordChar = '*';
            this.textEdit_pwd.Size = new System.Drawing.Size(160, 20);
            this.textEdit_pwd.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Данс :";
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(141, 117);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_ok.TabIndex = 4;
            this.simpleButton_ok.Text = "OK";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // textEdit_stock
            // 
            this.textEdit_stock.Location = new System.Drawing.Point(56, 78);
            this.textEdit_stock.Name = "textEdit_stock";
            this.textEdit_stock.Properties.Mask.EditMask = "d";
            this.textEdit_stock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_stock.Properties.PasswordChar = '*';
            this.textEdit_stock.Size = new System.Drawing.Size(160, 20);
            this.textEdit_stock.TabIndex = 3;
            // 
            // editmember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 162);
            this.Controls.Add(this.textEdit_stock);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEdit_pwd);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit_name);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editmember";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Засах";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.editmember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_stock.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ok;
        public DevExpress.XtraEditors.TextEdit textEdit_name;
        public DevExpress.XtraEditors.TextEdit textEdit_pwd;
        public DevExpress.XtraEditors.TextEdit textEdit_stock;
    }
}