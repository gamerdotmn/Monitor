namespace Monitor
{
    partial class FrmAddEmp
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_username = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_password = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_permission = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_edit = new DevExpress.XtraEditors.SimpleButton();
        
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_permission.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Нэвтрэх нэр :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Нууц үг :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(26, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Эрх :";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(195, 158);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Нэмэх";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // textEdit_username
            // 
            this.textEdit_username.Location = new System.Drawing.Point(100, 25);
            this.textEdit_username.Name = "textEdit_username";
            this.textEdit_username.Size = new System.Drawing.Size(170, 20);
            this.textEdit_username.TabIndex = 4;
            // 
            // textEdit_password
            // 
            this.textEdit_password.Location = new System.Drawing.Point(100, 75);
            this.textEdit_password.Name = "textEdit_password";
            this.textEdit_password.Properties.PasswordChar = '*';
            this.textEdit_password.Size = new System.Drawing.Size(170, 20);
            this.textEdit_password.TabIndex = 5;
            // 
            // comboBoxEdit_permission
            // 
            this.comboBoxEdit_permission.Location = new System.Drawing.Point(100, 120);
            this.comboBoxEdit_permission.Name = "comboBoxEdit_permission";
            this.comboBoxEdit_permission.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_permission.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_permission.Size = new System.Drawing.Size(170, 20);
            this.comboBoxEdit_permission.TabIndex = 6;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(195, 158);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 8;
            this.btn_edit.Text = "Засах";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // FrmAddEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 212);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.comboBoxEdit_permission);
            this.Controls.Add(this.textEdit_password);
            this.Controls.Add(this.textEdit_username);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEmp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ажилтан";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_permission.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.TextEdit textEdit_password;
        public DevExpress.XtraEditors.TextEdit textEdit_username;
        public DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_permission;
        private DevExpress.XtraEditors.SimpleButton btn_edit;
    }
}