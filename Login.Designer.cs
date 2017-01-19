namespace Monitor
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_name = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_pwd = new DevExpress.XtraEditors.LabelControl();
            this.login_pwd = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_server = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl_server = new DevExpress.XtraEditors.LabelControl();
            this.login_username = new DevExpress.XtraEditors.TextEdit();
            this.labelerr = new Monitor.Labelerr();
            ((System.ComponentModel.ISupportInitialize)(this.login_pwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_server.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_username.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(210, 115);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_ok.TabIndex = 3;
            this.simpleButton_ok.Text = "Нэвтрэх";
            // 
            // labelControl_name
            // 
            this.labelControl_name.Location = new System.Drawing.Point(25, 27);
            this.labelControl_name.Name = "labelControl_name";
            this.labelControl_name.Size = new System.Drawing.Size(94, 13);
            this.labelControl_name.TabIndex = 1;
            this.labelControl_name.Text = "Хэрэглэгчийн нэр :";
            // 
            // labelControl_pwd
            // 
            this.labelControl_pwd.Location = new System.Drawing.Point(74, 53);
            this.labelControl_pwd.Name = "labelControl_pwd";
            this.labelControl_pwd.Size = new System.Drawing.Size(45, 13);
            this.labelControl_pwd.TabIndex = 3;
            this.labelControl_pwd.Text = "Нууц үг :";
            // 
            // login_pwd
            // 
            this.login_pwd.Location = new System.Drawing.Point(125, 50);
            this.login_pwd.Name = "login_pwd";
            this.login_pwd.Properties.PasswordChar = '*';
            this.login_pwd.Size = new System.Drawing.Size(160, 20);
            this.login_pwd.TabIndex = 2;
            // 
            // comboBoxEdit_server
            // 
            this.comboBoxEdit_server.Location = new System.Drawing.Point(125, 76);
            this.comboBoxEdit_server.Name = "comboBoxEdit_server";
            this.comboBoxEdit_server.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_server.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_server.Size = new System.Drawing.Size(160, 20);
            this.comboBoxEdit_server.TabIndex = 3;
            this.comboBoxEdit_server.TabStop = false;
            this.comboBoxEdit_server.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit_server_SelectedIndexChanged);
            // 
            // labelControl_server
            // 
            this.labelControl_server.Location = new System.Drawing.Point(75, 79);
            this.labelControl_server.Name = "labelControl_server";
            this.labelControl_server.Size = new System.Drawing.Size(44, 13);
            this.labelControl_server.TabIndex = 6;
            this.labelControl_server.Text = "Сервер :";
            // 
            // login_username
            // 
            this.login_username.Location = new System.Drawing.Point(125, 24);
            this.login_username.Name = "login_username";
            this.login_username.Size = new System.Drawing.Size(160, 20);
            this.login_username.TabIndex = 1;
            // 
            // labelerr
            // 
            this.labelerr.AutoSize = true;
            this.labelerr.Location = new System.Drawing.Point(122, 99);
            this.labelerr.Name = "labelerr";
            this.labelerr.Size = new System.Drawing.Size(0, 13);
            this.labelerr.TabIndex = 4;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 160);
            this.Controls.Add(this.login_username);
            this.Controls.Add(this.labelControl_server);
            this.Controls.Add(this.comboBoxEdit_server);
            this.Controls.Add(this.labelerr);
            this.Controls.Add(this.login_pwd);
            this.Controls.Add(this.labelControl_pwd);
            this.Controls.Add(this.labelControl_name);
            this.Controls.Add(this.simpleButton_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нэвтрэх";
            ((System.ComponentModel.ISupportInitialize)(this.login_pwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_server.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_username.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl_name;
        private DevExpress.XtraEditors.LabelControl labelControl_pwd;
        public DevExpress.XtraEditors.SimpleButton simpleButton_ok;
        public DevExpress.XtraEditors.TextEdit login_pwd;
        public Labelerr labelerr;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_server;
        private DevExpress.XtraEditors.LabelControl labelControl_server;
        public DevExpress.XtraEditors.TextEdit login_username;
    }
}