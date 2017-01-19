namespace Monitor
{
    partial class Connecting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connecting));
            this.marqueeProgressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelControl_connecting = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_link = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_copyright = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit_logo = new DevExpress.XtraEditors.PictureEdit();
            this.simpleButton_exit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_logo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl
            // 
            this.marqueeProgressBarControl.EditValue = 0;
            this.marqueeProgressBarControl.Location = new System.Drawing.Point(23, 231);
            this.marqueeProgressBarControl.Name = "marqueeProgressBarControl";
            this.marqueeProgressBarControl.Size = new System.Drawing.Size(404, 12);
            this.marqueeProgressBarControl.TabIndex = 5;
            // 
            // labelControl_connecting
            // 
            this.labelControl_connecting.Location = new System.Drawing.Point(23, 249);
            this.labelControl_connecting.Name = "labelControl_connecting";
            this.labelControl_connecting.Size = new System.Drawing.Size(180, 13);
            this.labelControl_connecting.TabIndex = 7;
            this.labelControl_connecting.Text = "Сервертэй холболт үүсгэж байна...";
            // 
            // labelControl_link
            // 
            this.labelControl_link.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl_link.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl_link.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl_link.Location = new System.Drawing.Point(379, 295);
            this.labelControl_link.Name = "labelControl_link";
            this.labelControl_link.Size = new System.Drawing.Size(48, 13);
            this.labelControl_link.TabIndex = 11;
            this.labelControl_link.Text = "gamer.mn";
            this.labelControl_link.Click += new System.EventHandler(this.labelControl_link_Click);
            // 
            // labelControl_copyright
            // 
            this.labelControl_copyright.Location = new System.Drawing.Point(23, 295);
            this.labelControl_copyright.Name = "labelControl_copyright";
            this.labelControl_copyright.Size = new System.Drawing.Size(10, 13);
            this.labelControl_copyright.TabIndex = 13;
            this.labelControl_copyright.Text = "©";
            // 
            // pictureEdit_logo
            // 
            this.pictureEdit_logo.EditValue = global::Monitor.Properties.Resources.logof;
            this.pictureEdit_logo.Location = new System.Drawing.Point(23, 23);
            this.pictureEdit_logo.Name = "pictureEdit_logo";
            this.pictureEdit_logo.Properties.AllowFocused = false;
            this.pictureEdit_logo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit_logo.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit_logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit_logo.Properties.ShowMenu = false;
            this.pictureEdit_logo.Properties.ZoomPercent = 50D;
            this.pictureEdit_logo.Size = new System.Drawing.Size(404, 180);
            this.pictureEdit_logo.TabIndex = 12;
            // 
            // simpleButton_exit
            // 
            this.simpleButton_exit.Location = new System.Drawing.Point(424, 6);
            this.simpleButton_exit.Name = "simpleButton_exit";
            this.simpleButton_exit.Size = new System.Drawing.Size(20, 20);
            this.simpleButton_exit.TabIndex = 0;
            this.simpleButton_exit.TabStop = false;
            this.simpleButton_exit.Text = "x";
            this.simpleButton_exit.Click += new System.EventHandler(this.simpleButton_exit_Click);
            // 
            // Connecting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.simpleButton_exit);
            this.Controls.Add(this.labelControl_copyright);
            this.Controls.Add(this.pictureEdit_logo);
            this.Controls.Add(this.labelControl_link);
            this.Controls.Add(this.labelControl_connecting);
            this.Controls.Add(this.marqueeProgressBarControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Connecting";
            this.Text = "Form1";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_logo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl;
        private DevExpress.XtraEditors.LabelControl labelControl_connecting;
        private DevExpress.XtraEditors.LabelControl labelControl_link;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_logo;
        private DevExpress.XtraEditors.LabelControl labelControl_copyright;
        private DevExpress.XtraEditors.SimpleButton simpleButton_exit;
    }
}
