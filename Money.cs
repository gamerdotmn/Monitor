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
    public partial class Money : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        private int min = 0;
        public int price = 0;
        public Money()
        {
            min =0;
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            ok = true;
            this.Close();
        }

        private void maskedTextBox_price_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox_price_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void maskedTextBox_price_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox_price_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (button_ok.Enabled)
                {
                    ok = true;
                    this.Close();
                }
            }
        }

        private void maskedTextBox_price_TextChanged_1(object sender, EventArgs e)
        {
            if (maskedTextBox_price.Text.Length > 0)
            {
                int pr = int.Parse(maskedTextBox_price.Text);
                if (pr <= min)
                {
                    price = min;
                }
                else
                {
                    int m = pr;
                    price = (pr / min) * min;
                    if (m % min != 0)
                    {
                        price += min;
                    }
                }
                textBox_price.Text = price.ToString();
                button_ok.Enabled = true;
            }
            else
            {
                button_ok.Enabled = false;
            }
        }
    }
}