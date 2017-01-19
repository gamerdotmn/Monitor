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
    public partial class total : DevExpress.XtraEditors.XtraForm
    {
        public total()
        {
            InitializeComponent();
            
        }

        private void total_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape||e.KeyCode==Keys.Enter)
            {
                this.Close();
            }
        }

        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}