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
    public partial class addmember : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        int newmemberprice = 0;
        int newmemberstock = 0;

        public addmember()
        {
            InitializeComponent();
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);

            var _c = from c in ms.configs select c;
            if (_c.Count() > 0)
            {
                 //newmemberprice = int.Parse(_c.Single().newmemberprice);
                 //newmemberstock = int.Parse(_c.Single().newmemberstock);
                 textEdit1.Text = newmemberprice.ToString();
                 textEdit2.Text = newmemberstock.ToString();
            }
            else
            {
                textEdit1.Text = newmemberprice.ToString();
                textEdit2.Text = newmemberstock.ToString();
                //this.Close();
                MessageBox.Show("Тохиргоо хэсэгт мэдээлэлээ оруулна уу!!!");
            }
        }

        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            var _check = (from c in ms.members where c.name == textEdit_name.Text select c).ToList();
            if (_check.Count < 1)
            {
                member m = new member();
                m.name = textEdit_name.Text;
                m.password = textEdit_name.Text;
                m.ot = DateTime.Now;
                m.money = newmemberstock;
                //m.bonus = 0;
                ms.members.InsertOnSubmit(m);
                ms.SubmitChanges();
                employee_member _em = new employee_member();
                _em.member_name = textEdit_name.Text;
                _em.member_name = Mainfrm.name;
                _em.price = newmemberprice;
                _em.ot = DateTime.Now;
                ms.employee_members.InsertOnSubmit(_em);
                ms.SubmitChanges();
                ok = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(textEdit_name.Text+" нэртэй хэрэглэгч үүссэн байна!!!");
            }
        }
        private void textEdit_name_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit_name.Text.Length > 0)
            {
                simpleButton_ok.Enabled = true;
            }
            else
            {
                simpleButton_ok.Enabled = false;
            }
        }
    }
}