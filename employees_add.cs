using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;

namespace Monitor
{
    public partial class employees_add : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;

        public employees_add()
        {
            InitializeComponent();
        }

        private void simpleButton_add_Click(object sender, EventArgs e)
        {
            if (textEdit_username.Text.Length > 0 && textEdit_password.Text.Length > 0)
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                int count = (from row in ms.employees where row.name == textEdit_username.Text select row).Count();
                if (count > 0)
                {
                    labelerr.Settext("'" + textEdit_username.Text + "' нэртэй хэрэглэгч бүртгэлтэй байна.");
                }
                else
                {
                    employee _emp = new employee();
                    _emp.name = textEdit_username.Text;
                    _emp.password = Program.Compress(textEdit_password.Text.ToLower());
                    _emp.isadmin = false;
                    ms.employees.InsertOnSubmit(_emp);
                    ms.SubmitChanges();
                    ok = true;
                    this.Close();
                }
            }
            else
            {
                labelerr.Settext("Дутуу бөгөлсөн байна.");
            }
        }
        
    }
}