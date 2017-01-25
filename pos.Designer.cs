namespace Monitor
{
    partial class pos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl_top = new DevExpress.XtraEditors.PanelControl();
            this.listView_order = new System.Windows.Forms.ListView();
            this.columnHeader_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_del = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl_bottom = new DevExpress.XtraEditors.PanelControl();
            this.textEdit_sum = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_save = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl_cats = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_top)).BeginInit();
            this.panelControl_top.SuspendLayout();
            this.contextMenuStrip_del.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_bottom)).BeginInit();
            this.panelControl_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_sum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_cats)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl_top
            // 
            this.panelControl_top.Controls.Add(this.listView_order);
            this.panelControl_top.Controls.Add(this.panelControl_bottom);
            this.panelControl_top.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_top.Location = new System.Drawing.Point(0, 550);
            this.panelControl_top.Name = "panelControl_top";
            this.panelControl_top.Size = new System.Drawing.Size(250, 250);
            this.panelControl_top.TabIndex = 0;
            // 
            // listView_order
            // 
            this.listView_order.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_id,
            this.columnHeader_name,
            this.columnHeader_cnt,
            this.columnHeader_price});
            this.listView_order.ContextMenuStrip = this.contextMenuStrip_del;
            this.listView_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_order.FullRowSelect = true;
            this.listView_order.Location = new System.Drawing.Point(2, 2);
            this.listView_order.MultiSelect = false;
            this.listView_order.Name = "listView_order";
            this.listView_order.Size = new System.Drawing.Size(246, 161);
            this.listView_order.TabIndex = 1;
            this.listView_order.UseCompatibleStateImageBehavior = false;
            this.listView_order.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_id
            // 
            this.columnHeader_id.Text = "№";
            this.columnHeader_id.Width = 40;
            // 
            // columnHeader_name
            // 
            this.columnHeader_name.Text = "Нэр";
            this.columnHeader_name.Width = 80;
            // 
            // columnHeader_cnt
            // 
            this.columnHeader_cnt.Text = "Тоо";
            // 
            // columnHeader_price
            // 
            this.columnHeader_price.Text = "Үнэ";
            // 
            // contextMenuStrip_del
            // 
            this.contextMenuStrip_del.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delToolStripMenuItem});
            this.contextMenuStrip_del.Name = "contextMenuStrip1";
            this.contextMenuStrip_del.Size = new System.Drawing.Size(205, 48);
            this.contextMenuStrip_del.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.delToolStripMenuItem.Text = "Сонгосон барааг устгах";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // panelControl_bottom
            // 
            this.panelControl_bottom.Controls.Add(this.textEdit_sum);
            this.panelControl_bottom.Controls.Add(this.simpleButton_save);
            this.panelControl_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_bottom.Location = new System.Drawing.Point(2, 163);
            this.panelControl_bottom.Name = "panelControl_bottom";
            this.panelControl_bottom.Size = new System.Drawing.Size(246, 85);
            this.panelControl_bottom.TabIndex = 0;
            // 
            // textEdit_sum
            // 
            this.textEdit_sum.EditValue = "0";
            this.textEdit_sum.Enabled = false;
            this.textEdit_sum.Location = new System.Drawing.Point(5, 6);
            this.textEdit_sum.Name = "textEdit_sum";
            this.textEdit_sum.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.textEdit_sum.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_sum.Properties.Appearance.ForeColor = System.Drawing.Color.LimeGreen;
            this.textEdit_sum.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_sum.Properties.Appearance.Options.UseFont = true;
            this.textEdit_sum.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_sum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.textEdit_sum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit_sum.Size = new System.Drawing.Size(236, 36);
            this.textEdit_sum.TabIndex = 2;
            this.textEdit_sum.TabStop = false;
            // 
            // simpleButton_save
            // 
            this.simpleButton_save.Location = new System.Drawing.Point(5, 48);
            this.simpleButton_save.Name = "simpleButton_save";
            this.simpleButton_save.Size = new System.Drawing.Size(236, 30);
            this.simpleButton_save.TabIndex = 1;
            this.simpleButton_save.Text = "Тооцоо хийх";
            this.simpleButton_save.Click += new System.EventHandler(this.simpleButton_save_Click);
            // 
            // xtraTabControl_cats
            // 
            this.xtraTabControl_cats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_cats.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_cats.Name = "xtraTabControl_cats";
            this.xtraTabControl_cats.Size = new System.Drawing.Size(250, 550);
            this.xtraTabControl_cats.TabIndex = 1;
            // 
            // pos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl_cats);
            this.Controls.Add(this.panelControl_top);
            this.Name = "pos";
            this.Size = new System.Drawing.Size(250, 800);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_top)).EndInit();
            this.panelControl_top.ResumeLayout(false);
            this.contextMenuStrip_del.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_bottom)).EndInit();
            this.panelControl_bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_sum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_cats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl_top;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl_cats;
        private DevExpress.XtraEditors.PanelControl panelControl_bottom;
        private DevExpress.XtraEditors.SimpleButton simpleButton_save;
        private System.Windows.Forms.ListView listView_order;
        private System.Windows.Forms.ColumnHeader columnHeader_id;
        private System.Windows.Forms.ColumnHeader columnHeader_name;
        private System.Windows.Forms.ColumnHeader columnHeader_cnt;
        private System.Windows.Forms.ColumnHeader columnHeader_price;
        private DevExpress.XtraEditors.TextEdit textEdit_sum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_del;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;

    }
}
