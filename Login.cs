using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;

namespace Monitor
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public bool ok_login = false;
        public Login()
        {
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            string[] servers = new string[Mainfrm.broadcast_servers.Count];
            Mainfrm.broadcast_servers.Keys.CopyTo(servers, 0);
            if (comboBoxEdit_server.InvokeRequired)
            {
                comboBoxEdit_server.Invoke(new MethodInvoker(delegate
                {
                    comboBoxEdit_server.Properties.Items.Clear();
                    for (int i = 0; i < servers.Length; i++)
                    {
                        comboBoxEdit_server.Properties.Items.Add(Mainfrm.broadcast_servers[servers[i]]);
                    }
                    comboBoxEdit_server.SelectedIndex = 0;
                }));
            }
            else
            {
                comboBoxEdit_server.Properties.Items.Clear();
                for (int i = 0; i < servers.Length; i++)
                {
                    comboBoxEdit_server.Properties.Items.Add(Mainfrm.broadcast_servers[servers[i]]);
                }
                comboBoxEdit_server.SelectedIndex = 0;
            }

            
            
        }

        private void comboBoxEdit_server_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] servers = new string[Mainfrm.broadcast_servers.Count];
            Mainfrm.broadcast_servers.Keys.CopyTo(servers, 0);
            for (int i = 0; i < servers.Length; i++)
            {
                if ((string)Mainfrm.broadcast_servers[servers[i]] == (string)comboBoxEdit_server.Text)
                {
                    Mainfrm.serverip = servers[i];
                    Program.constr = @"Data Source=" + Mainfrm.serverip + @"\MASTERCAFE;Initial Catalog=mastercafedb;Persist Security Info=True;User ID=sa;Password=pldifvzz7x;MultipleActiveResultSets=True";
                }
            }
        }
    }
}