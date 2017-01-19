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
    public partial class transfer : DevExpress.XtraEditors.XtraForm
    {
        public int _in=0;
        public int _get = 0;
        public int _out = 0;
        public bool vat = false;
        public bool ok = false;

        public transfer(int _i)
        {
            _in = _i;
            InitializeComponent();
            textBox_in.Text = _in.ToString("#,##0");
            simpleButton_ok.Enabled = false;
        }

        private void textBox_get_TextChanged(object sender, EventArgs e)
        {
            string nt="";
            for (int i = 0; i < textBox_get.Text.Length;i++ )
            {
                if (textBox_get.Text[i] == '0' || textBox_get.Text[i] == '1' || textBox_get.Text[i] == '2' || textBox_get.Text[i] == '3' || textBox_get.Text[i] == '4' || textBox_get.Text[i] == '5' || textBox_get.Text[i] == '6' || textBox_get.Text[i] == '7' || textBox_get.Text[i] == '8' || textBox_get.Text[i] == '9')
                {
                    nt = nt + textBox_get.Text[i];
                }
            }
            textBox_get.Text = nt;
            textBox_get.SelectionStart = textBox_get.Text.Length;
            textBox_get.SelectionLength = 0;
            if (nt.Length == 0)
            {
                _get = 0;
            }
            else
            {
                _get = Convert.ToInt32(textBox_get.Text);
            }
            _out = _get - _in;
            textBox_out.Text = _out.ToString("#,##0");
            if (_get > 0 && _out >= 0)
            {
                simpleButton_ok.Enabled = true;
            }
            else
            {
                simpleButton_ok.Enabled = false;
            }
        }

        private void transfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (this.checkEdit_vat.Checked)
                {
                    checkEdit_vat.Checked = false;
                }
                else
                {
                    checkEdit_vat.Checked = true;
                }
            }
            if (e.KeyCode == Keys.Enter && simpleButton_ok.Enabled == true)
            {
                ok = true;
                this.Close();
            }
        }

        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            ok = true;
            this.Close();
        }

        private void checkEdit_vat_CheckedChanged(object sender, EventArgs e)
        {
            vat = checkEdit_vat.Checked;
        }

    }
}