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
    public partial class editmember : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        private string member_name;
        private int old;
        public editmember(string name)
        {
            InitializeComponent();
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            member_name = name;
            var _c = (from c in ms.members where c.name == name select c).ToList();
            textEdit_name.Text = name;
            textEdit_pwd.Text = _c.Single().password;
            old = _c.Single().money;
            textEdit_stock.Text = _c.Single().money.ToString();
        }

        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            if (textEdit_pwd.Text.Length > 0 && textEdit_stock.Text.Length > 0)
            {
                var _g = (from r in ms.members where r.name == member_name select r).SingleOrDefault();
                _g.password = textEdit_pwd.Text;
                _g.money = int.Parse(textEdit_stock.Text);
                ms.SubmitChanges();
                employee_member em = new employee_member();
                em.employee_name= Mainfrm.name;
                em.member_name = member_name;
                em.price = int.Parse(textEdit_stock.Text) - old;
                em.ot = DateTime.Now;
                ms.employee_members.InsertOnSubmit(em);
                ms.SubmitChanges();
                ok = true;
                this.Close();
            }
            else
            {
                //label_type1.SetText("Бүх талбарыг бөглөнө үү");
            }
        }

        private void editmember_Load(object sender, EventArgs e)
        {

        }
    }
}