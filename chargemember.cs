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
    public partial class chargemember : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        public chargemember(string name)
        {
            InitializeComponent();
            textEdit1.Text = name;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ok = true;
            this.Close();
        }

        private void maskedTextBox_money_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void maskedTextBox_money_TextChanged(object sender, EventArgs e)
        {

            if (maskedTextBox_money.Text.Length > 0)
            {
                simpleButton1.Enabled = true;
            }
            else
            {
                simpleButton1.Enabled = false;
            }
        }

    }
}