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
    public partial class FrmAddEmp : DevExpress.XtraEditors.XtraForm
    {
        Hashtable ht = new Hashtable();
        public bool ok = false;
        string pname;
        public FrmAddEmp(string id)
        {
            InitializeComponent();
            comboBoxEdit_permission.Properties.Items.Add("Кашир");
            comboBoxEdit_permission.Properties.Items.Add("Админ");
            comboBoxEdit_permission.SelectedIndex = 0;
            if (id == "")
            {
                
                btn_edit.Visible = false;
            }
            else
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                var _emp=(from r in ms.employees
                             where r.name == id
                          select r).SingleOrDefault();
                textEdit_username.Text = _emp.name;
                textEdit_password.Text = Program.Decompress(_emp.password);
                if (_emp.isadmin == true)
                {
                    comboBoxEdit_permission.SelectedIndex = 1;
                }
                pname = id;
                btnadd.Visible = false;
            }
            
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (textEdit_username.Text.Length < 5)
            {
                //label_type1.SetText("Нэвтрэх нэр 5-с дээш тэмдэгт байх ёстой!!!");
            }
            else if (textEdit_password.Text.Length < 5)
            {
                //label_type1.SetText("Нууц үг 5-с дээш тэмдэгт байх ёстой!!!");
            }
            else
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                bool permission = true;
                if (comboBoxEdit_permission.Text == "Кашир")
                {
                    permission = false;
                }
                int count = (from row in ms.employees
                             where row.name == textEdit_username.Text
                             select row).Count();
                if (count > 0)
                {
                    XtraMessageBox.Show(textEdit_username.Text+" нэртэй хэрэглэгч бүртгэлтэй байна", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    employee _emp = new employee();
                    _emp.name = textEdit_username.Text;
                    _emp.password = Program.Compress(textEdit_password.Text);
                    _emp.isadmin = permission;
                    ms.employees.InsertOnSubmit(_emp);
                    ms.SubmitChanges();
                    ok = true;
                    this.Close();
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (textEdit_username.Text.Length < 5)
            {
                //label_type1.SetText("Нэвтрэх нэр 5-с дээш тэмдэгт байх ёстой!!!");
            }
            else if (textEdit_password.Text.Length < 5)
            {
                //label_type1.SetText("Нууц үг 5-с дээш тэмдэгт байх ёстой!!!");
            }
            else
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                bool permission = true;
                if (comboBoxEdit_permission.Text == "Кашир")
                {
                    permission = false;
                }
                
                var _emp = (from r in ms.employees
                            where r.name == pname
                            select r).SingleOrDefault();
                _emp.name = textEdit_username.Text;
                _emp.password = Program.Compress(textEdit_password.Text);
                _emp.isadmin = permission;
                ms.SubmitChanges();
                ok = true;
                this.Close();
                
            }
        }
        
    }
}