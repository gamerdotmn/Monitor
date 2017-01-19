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
    public partial class Screenshot : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        public Screenshot()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ins();
        }
        private void ins()
        {
            if (textEdit_word.Text.Length > 0)
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                int count = (from row in ms.bans
                             where row.word == textEdit_word.Text
                             select row).Count();
                if (count > 0)
                {
                    XtraMessageBox.Show("Бүртгэгдэсэн үг байна.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ban _b = new ban();
                    _b.word = textEdit_word.Text;
                    ms.bans.InsertOnSubmit(_b);
                    ms.SubmitChanges();
                    ok = true;
                    this.Close();
                }
            }
            else
            {
                //.SetText("Хоосон утга оруулах боломжгүй!!!");
            }
        }
        private void textEdit_word_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ins();
            }
        }
    }
}