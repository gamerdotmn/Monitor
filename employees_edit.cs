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
    public partial class employees_edit : DevExpress.XtraEditors.XtraForm
    {
        DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
        public employee emp;
        public bool ok = false;
        public employees_edit(string name)
        {
            InitializeComponent();
            emp=ms.employees.Where(e => e.name == name).FirstOrDefault();
            textEdit_username.Text = emp.name;
            textEdit_password.Text = Program.Decompress(emp.password);
        }

        private void simpleButton_edit_Click(object sender, EventArgs e)
        {
            if (textEdit_username.Text.Length > 0 && textEdit_password.Text.Length > 0)
            {
                emp.name = textEdit_username.Text;
                emp.password = Program.Compress(textEdit_password.Text);
                ms.SubmitChanges();
                ok = true;
                this.Close();
            }
            else
            {
                labelerr.Settext("Дутуу бөгөлсөн байна.");
            }
        }
    }
}