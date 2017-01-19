namespace Monitor
{
    partial class transfer
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
            this.textBox_get = new System.Windows.Forms.TextBox();
            this.textBox_in = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            this.textBox_out = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkEdit_vat = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_vat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_get
            // 
            this.textBox_get.BackColor = System.Drawing.Color.Black;
            this.textBox_get.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_get.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_get.ForeColor = System.Drawing.Color.Lime;
            this.textBox_get.Location = new System.Drawing.Point(29, 101);
            this.textBox_get.Name = "textBox_get";
            this.textBox_get.Size = new System.Drawing.Size(200, 35);
            this.textBox_get.TabIndex = 1;
            this.textBox_get.Text = "0";
            this.textBox_get.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_get.TextChanged += new System.EventHandler(this.textBox_get_TextChanged);
            // 
            // textBox_in
            // 
            this.textBox_in.BackColor = System.Drawing.Color.Black;
            this.textBox_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_in.ForeColor = System.Drawing.Color.Lime;
            this.textBox_in.Location = new System.Drawing.Point(29, 44);
            this.textBox_in.Name = "textBox_in";
            this.textBox_in.ReadOnly = true;
            this.textBox_in.Size = new System.Drawing.Size(200, 35);
            this.textBox_in.TabIndex = 6;
            this.textBox_in.TabStop = false;
            this.textBox_in.Text = "5000";
            this.textBox_in.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Авсан:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Авах мөнгө:";
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(29, 227);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(200, 23);
            this.simpleButton_ok.TabIndex = 3;
            this.simpleButton_ok.Text = "OK";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // textBox_out
            // 
            this.textBox_out.BackColor = System.Drawing.Color.Black;
            this.textBox_out.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_out.ForeColor = System.Drawing.Color.Lime;
            this.textBox_out.Location = new System.Drawing.Point(29, 158);
            this.textBox_out.Name = "textBox_out";
            this.textBox_out.ReadOnly = true;
            this.textBox_out.Size = new System.Drawing.Size(200, 35);
            this.textBox_out.TabIndex = 10;
            this.textBox_out.TabStop = false;
            this.textBox_out.Text = "0";
            this.textBox_out.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Хариулт:";
            // 
            // checkEdit_vat
            // 
            this.checkEdit_vat.Location = new System.Drawing.Point(29, 202);
            this.checkEdit_vat.Name = "checkEdit_vat";
            this.checkEdit_vat.Properties.Caption = "НӨАТ хэвлэх";
            this.checkEdit_vat.Size = new System.Drawing.Size(200, 19);
            this.checkEdit_vat.TabIndex = 2;
            this.checkEdit_vat.CheckedChanged += new System.EventHandler(this.checkEdit_vat_CheckedChanged);
            // 
            // transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 279);
            this.Controls.Add(this.checkEdit_vat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_out);
            this.Controls.Add(this.simpleButton_ok);
            this.Controls.Add(this.textBox_get);
            this.Controls.Add(this.textBox_in);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "transfer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Мөнгөн гүйлгээ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.transfer_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_vat.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_get;
        private System.Windows.Forms.TextBox textBox_in;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_out;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ok;
        private DevExpress.XtraEditors.CheckEdit checkEdit_vat;
    }
}