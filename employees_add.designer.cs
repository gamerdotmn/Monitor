namespace Monitor
{
    partial class employees_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employees_add));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_add = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_username = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_password = new DevExpress.XtraEditors.TextEdit();
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
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Нэвтрэх нэр:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(53, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Нууц үг:";
            // 
            // simpleButton_add
            // 
            this.simpleButton_add.Location = new System.Drawing.Point(161, 83);
            this.simpleButton_add.Name = "simpleButton_add";
            this.simpleButton_add.Size = new System.Drawing.Size(100, 25);
            this.simpleButton_add.TabIndex = 3;
            this.simpleButton_add.Text = "Хадгалах";
            this.simpleButton_add.Click += new System.EventHandler(this.simpleButton_add_Click);
            // 
            // textEdit_username
            // 
            this.textEdit_username.Location = new System.Drawing.Point(101, 27);
            this.textEdit_username.Name = "textEdit_username";
            this.textEdit_username.Size = new System.Drawing.Size(160, 20);
            this.textEdit_username.TabIndex = 1;
            // 
            // textEdit_password
            // 
            this.textEdit_password.Location = new System.Drawing.Point(101, 57);
            this.textEdit_password.Name = "textEdit_password";
            this.textEdit_password.Properties.PasswordChar = '*';
            this.textEdit_password.Size = new System.Drawing.Size(160, 20);
            this.textEdit_password.TabIndex = 2;
            // 
            // labelerr
            // 
            this.labelerr.AutoSize = true;
            this.labelerr.Location = new System.Drawing.Point(101, 111);
            this.labelerr.Name = "labelerr";
            this.labelerr.Size = new System.Drawing.Size(0, 13);
            this.labelerr.TabIndex = 4;
            // 
            // employees_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 137);
            this.Controls.Add(this.labelerr);
            this.Controls.Add(this.textEdit_password);
            this.Controls.Add(this.textEdit_username);
            this.Controls.Add(this.simpleButton_add);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "employees_add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Хэрэглэгч";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_add;
        private DevExpress.XtraEditors.TextEdit textEdit_password;
        public DevExpress.XtraEditors.TextEdit textEdit_username;
        private Labelerr labelerr;
    }
}