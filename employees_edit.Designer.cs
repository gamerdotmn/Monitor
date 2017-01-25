namespace Monitor
{
    partial class employees_edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employees_edit));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_username = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_password = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_edit = new DevExpress.XtraEditors.SimpleButton();
            this.labelerr = new Monitor.Labelerr();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Нэвтрэх нэр:";
            // 
            // textEdit_username
            // 
            this.textEdit_username.Location = new System.Drawing.Point(101, 27);
            this.textEdit_username.Name = "textEdit_username";
            this.textEdit_username.Properties.ReadOnly = true;
            this.textEdit_username.Size = new System.Drawing.Size(160, 20);
            this.textEdit_username.TabIndex = 1;
            this.textEdit_username.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(53, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Нууц үг:";
            // 
            // textEdit_password
            // 
            this.textEdit_password.Location = new System.Drawing.Point(101, 57);
            this.textEdit_password.Name = "textEdit_password";
            this.textEdit_password.Properties.PasswordChar = '*';
            this.textEdit_password.Size = new System.Drawing.Size(160, 20);
            this.textEdit_password.TabIndex = 1;
            // 
            // simpleButton_edit
            // 
            this.simpleButton_edit.Location = new System.Drawing.Point(161, 83);
            this.simpleButton_edit.Name = "simpleButton_edit";
            this.simpleButton_edit.Size = new System.Drawing.Size(100, 25);
            this.simpleButton_edit.TabIndex = 3;
            this.simpleButton_edit.Text = "Хадгалах";
            this.simpleButton_edit.Click += new System.EventHandler(this.simpleButton_edit_Click);
            // 
            // labelerr
            // 
            this.labelerr.AutoSize = true;
            this.labelerr.Location = new System.Drawing.Point(98, 111);
            this.labelerr.Name = "labelerr";
            this.labelerr.Size = new System.Drawing.Size(0, 13);
            this.labelerr.TabIndex = 6;
            // 
            // employees_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 137);
            this.Controls.Add(this.labelerr);
            this.Controls.Add(this.simpleButton_edit);
            this.Controls.Add(this.textEdit_password);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEdit_username);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "employees_edit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Хэрэглэгч засах";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit textEdit_username;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit_password;
        private DevExpress.XtraEditors.SimpleButton simpleButton_edit;
        private Labelerr labelerr;
    }
}