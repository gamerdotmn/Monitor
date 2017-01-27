using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
namespace Monitor
{
    public partial class stats : DevExpress.XtraEditors.XtraForm
    {
        public stats()
        {
            InitializeComponent();
            clientstats cs=Newtonsoft.Json.JsonConvert.DeserializeObject<clientstats>(File.ReadAllText("clients.json"));
            if (File.Exists("clients.json"))
            {
                File.Delete("clients.json");
            }
            foreach (var c in cs.clients_list)
            {
                ListViewItem lvi = new ListViewItem(new string[] { c.name, c.group, c.member, c.used, c.remain, "", c.start, c.app, c.title, c.ip, c.mac }, c.status);
                lvi.Name = c.name;
                listView_clients.Items.Add(lvi);
                int cw = listView_clients.Width / listView_clients.Columns.Count;
                for (int i = 0; i < listView_clients.Columns.Count; i++)
                {
                    listView_clients.Columns[i].Width = cw;
                }
            }
        }

        private void listView_clients_SizeChanged(object sender, EventArgs e)
        {
            int cw = listView_clients.Width / listView_clients.Columns.Count;
            for (int i = 0; i < listView_clients.Columns.Count; i++)
            {
                listView_clients.Columns[i].Width = cw;
                listView_clients.Columns[i].TextAlign = HorizontalAlignment.Center;
            }
        }
    }
}