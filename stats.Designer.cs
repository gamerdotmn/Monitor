namespace Monitor
{
    partial class stats
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stats));
            this.imageList_client = new System.Windows.Forms.ImageList(this.components);
            this.listView_clients = new Monitor.ListViewNew();
            this.columnHeader_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_group = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_member = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_usedt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_remaint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_money = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_startt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_app = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_mac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // imageList_client
            // 
            this.imageList_client.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_client.ImageStream")));
            this.imageList_client.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_client.Images.SetKeyName(0, "0.png");
            this.imageList_client.Images.SetKeyName(1, "1.png");
            this.imageList_client.Images.SetKeyName(2, "2.png");
            this.imageList_client.Images.SetKeyName(3, "3.png");
            this.imageList_client.Images.SetKeyName(4, "4.png");
            this.imageList_client.Images.SetKeyName(5, "5.png");
            this.imageList_client.Images.SetKeyName(6, "6.png");
            this.imageList_client.Images.SetKeyName(7, "7.png");
            this.imageList_client.Images.SetKeyName(8, "8.png");
            this.imageList_client.Images.SetKeyName(9, "9.png");
            this.imageList_client.Images.SetKeyName(10, "10.png");
            // 
            // listView_clients
            // 
            this.listView_clients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_name,
            this.columnHeader_group,
            this.columnHeader_member,
            this.columnHeader_usedt,
            this.columnHeader_remaint,
            this.columnHeader_money,
            this.columnHeader_startt,
            this.columnHeader_app,
            this.columnHeader_title,
            this.columnHeader_ip,
            this.columnHeader_mac});
            this.listView_clients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_clients.FullRowSelect = true;
            this.listView_clients.LargeImageList = this.imageList_client;
            this.listView_clients.Location = new System.Drawing.Point(0, 0);
            this.listView_clients.Name = "listView_clients";
            this.listView_clients.Size = new System.Drawing.Size(1008, 730);
            this.listView_clients.SmallImageList = this.imageList_client;
            this.listView_clients.TabIndex = 2;
            this.listView_clients.UseCompatibleStateImageBehavior = false;
            this.listView_clients.View = System.Windows.Forms.View.Details;
            this.listView_clients.SizeChanged += new System.EventHandler(this.listView_clients_SizeChanged);
            // 
            // columnHeader_name
            // 
            this.columnHeader_name.Text = "Нэр";
            this.columnHeader_name.Width = 75;
            // 
            // columnHeader_group
            // 
            this.columnHeader_group.Text = "Тасалгаа";
            this.columnHeader_group.Width = 75;
            // 
            // columnHeader_member
            // 
            this.columnHeader_member.Text = "Гишүүн";
            this.columnHeader_member.Width = 75;
            // 
            // columnHeader_usedt
            // 
            this.columnHeader_usedt.Text = "Ашигласан";
            this.columnHeader_usedt.Width = 100;
            // 
            // columnHeader_remaint
            // 
            this.columnHeader_remaint.Text = "Үлдсэн";
            this.columnHeader_remaint.Width = 100;
            // 
            // columnHeader_money
            // 
            this.columnHeader_money.Text = "Мөнгөн дүн";
            this.columnHeader_money.Width = 100;
            // 
            // columnHeader_startt
            // 
            this.columnHeader_startt.Text = "Эхэлсэн";
            this.columnHeader_startt.Width = 75;
            // 
            // columnHeader_app
            // 
            this.columnHeader_app.Text = "Программ";
            this.columnHeader_app.Width = 75;
            // 
            // columnHeader_title
            // 
            this.columnHeader_title.Text = "Гарчиг";
            this.columnHeader_title.Width = 75;
            // 
            // columnHeader_ip
            // 
            this.columnHeader_ip.Text = "IP";
            this.columnHeader_ip.Width = 75;
            // 
            // columnHeader_mac
            // 
            this.columnHeader_mac.Text = "MAC";
            // 
            // stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.listView_clients);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "stats";
            this.Text = "Буцаалтын мэдээлэл";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList_client;
        private ListViewNew listView_clients;
        private System.Windows.Forms.ColumnHeader columnHeader_name;
        private System.Windows.Forms.ColumnHeader columnHeader_group;
        private System.Windows.Forms.ColumnHeader columnHeader_member;
        private System.Windows.Forms.ColumnHeader columnHeader_usedt;
        private System.Windows.Forms.ColumnHeader columnHeader_remaint;
        private System.Windows.Forms.ColumnHeader columnHeader_money;
        private System.Windows.Forms.ColumnHeader columnHeader_startt;
        private System.Windows.Forms.ColumnHeader columnHeader_app;
        private System.Windows.Forms.ColumnHeader columnHeader_title;
        private System.Windows.Forms.ColumnHeader columnHeader_ip;
        private System.Windows.Forms.ColumnHeader columnHeader_mac;
    }
}