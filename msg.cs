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
    public partial class msg : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        public msg()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            ok = true;
            this.Close();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox.Text.Length > 0)
            {
                button_ok.Enabled = true;
            }
            else
            {
                button_ok.Enabled = false;
            }
        }
    }
}