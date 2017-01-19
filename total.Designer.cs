namespace Monitor
{
    partial class total
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
            this.listView_sale = new System.Windows.Forms.ListView();
            this.panelControl_bottom = new DevExpress.XtraEditors.PanelControl();
            this.panelControl_top = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.columnHeader_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_money = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_minute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_startt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_bottom)).BeginInit();
            this.panelControl_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_top)).BeginInit();
            this.panelControl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_sale
            // 
            this.listView_sale.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_name,
            this.columnHeader_startt,
            this.columnHeader_minute,
            this.columnHeader_money});
            this.listView_sale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_sale.Location = new System.Drawing.Point(0, 0);
            this.listView_sale.Name = "listView_sale";
            this.listView_sale.Size = new System.Drawing.Size(624, 360);
            this.listView_sale.TabIndex = 0;
            this.listView_sale.TabStop = false;
            this.listView_sale.UseCompatibleStateImageBehavior = false;
            this.listView_sale.View = System.Windows.Forms.View.Details;
            // 
            // panelControl_bottom
            // 
            this.panelControl_bottom.Controls.Add(this.textBox_total);
            this.panelControl_bottom.Controls.Add(this.simpleButton_ok);
            this.panelControl_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_bottom.Location = new System.Drawing.Point(0, 360);
            this.panelControl_bottom.Name = "panelControl_bottom";
            this.panelControl_bottom.Size = new System.Drawing.Size(624, 82);
            this.panelControl_bottom.TabIndex = 1;
            // 
            // panelControl_top
            // 
            this.panelControl_top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl_top.Controls.Add(this.listView_sale);
            this.panelControl_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl_top.Location = new System.Drawing.Point(0, 0);
            this.panelControl_top.Name = "panelControl_top";
            this.panelControl_top.Size = new System.Drawing.Size(624, 360);
            this.panelControl_top.TabIndex = 2;
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(5, 46);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(614, 30);
            this.simpleButton_ok.TabIndex = 1;
            this.simpleButton_ok.Text = "OK";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // textBox_total
            // 
            this.textBox_total.BackColor = System.Drawing.Color.Black;
            this.textBox_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_total.ForeColor = System.Drawing.Color.Lime;
            this.textBox_total.Location = new System.Drawing.Point(5, 5);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.ReadOnly = true;
            this.textBox_total.Size = new System.Drawing.Size(614, 35);
            this.textBox_total.TabIndex = 7;
            this.textBox_total.TabStop = false;
            this.textBox_total.Text = "0";
            this.textBox_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader_name
            // 
            this.columnHeader_name.Text = "Нэр";
            this.columnHeader_name.Width = 160;
            // 
            // columnHeader_money
            // 
            this.columnHeader_money.Text = "Дүн";
            this.columnHeader_money.Width = 160;
            // 
            // columnHeader_minute
            // 
            this.columnHeader_minute.Text = "Минут";
            this.columnHeader_minute.Width = 160;
            // 
            // columnHeader_startt
            // 
            this.columnHeader_startt.Text = "Эхэлсэн";
            this.columnHeader_startt.Width = 160;
            // 
            // total
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.panelControl_top);
            this.Controls.Add(this.panelControl_bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "total";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Нийт";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.total_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_bottom)).EndInit();
            this.panelControl_bottom.ResumeLayout(false);
            this.panelControl_bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_top)).EndInit();
            this.panelControl_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl_bottom;
        private DevExpress.XtraEditors.PanelControl panelControl_top;
        private DevExpress.XtraEditors.SimpleButton simpleButton_ok;
        private System.Windows.Forms.ColumnHeader columnHeader_name;
        private System.Windows.Forms.ColumnHeader columnHeader_money;
        private System.Windows.Forms.ColumnHeader columnHeader_minute;
        private System.Windows.Forms.ColumnHeader columnHeader_startt;
        public System.Windows.Forms.ListView listView_sale;
        public System.Windows.Forms.TextBox textBox_total;
    }
}