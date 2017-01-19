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
    public partial class Password : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        public Password()
        {
            InitializeComponent();
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            if (textBox_password.Text.Length > 0)
            {
                button_ok.Enabled = true;
            }
            else
            {
                button_ok.Enabled = false;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            ok = true;
            this.Close();
        }
    }
}