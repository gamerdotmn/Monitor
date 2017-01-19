using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Monitor
{
    public partial class changepc : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        public changepc(string[] pcs, string current)
        {
            InitializeComponent();
            for (int i = 0; i < pcs.Length; i++)
            {
                if (pcs[i] == current)
                {
                    continue;
                }
                comboBox_clients.Properties.Items.Add(pcs[i]);
            }
            if (comboBox_clients.Properties.Items.Count > 0)
            {
                comboBox_clients.SelectedIndex = 0;
                button_ok.Enabled = true;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
             ok = true;
                this.Close();
        }
    }
}