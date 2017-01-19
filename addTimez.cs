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
    public partial class addTimez : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        private int pid;
        public addTimez(string id)
        {
            InitializeComponent();
            for (int i = 0; i < 24; i++)
            {
                comboBoxEdit_begd.Properties.Items.Add(i);
                comboBoxEdit_endd.Properties.Items.Add(i);
                comboBoxEdit_endd.SelectedIndex = 0;
                comboBoxEdit_begd.SelectedIndex = 0;
            }
            if (id == null)
            {
                simpleButton_edit.Visible = false;
            }
            else
            {
                pid = int.Parse(id);
                simpleButton_ok.Visible = false;
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                var _c = from c in ms.hourtemplates where c.id == Guid.Parse(pid.ToString()) select c;
                textEdit_name.Text = _c.Single().name;
                textEdit_stock.Text = _c.Single().minute.ToString();
                textEdit_price.Text = _c.Single().price.ToString();
                comboBoxEdit_begd.Text = _c.Single().beghour.ToString();
                comboBoxEdit_endd.Text = _c.Single().endhour.ToString();
            }
        }

        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            if (textEdit_name.Text.Length > 0 && textEdit_price.Text.Length > 0 && textEdit_stock.Text.Length > 0)
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                hourtemplate h = new hourtemplate();
                h.name = textEdit_name.Text;
                h.price = int.Parse(textEdit_price.Text);
                h.minute = int.Parse(textEdit_stock.Text);
                h.beghour = int.Parse(comboBoxEdit_begd.Text);
                h.endhour = int.Parse(comboBoxEdit_endd.Text);
                ms.hourtemplates.InsertOnSubmit(h);
                ms.SubmitChanges();
                ok = true;
                this.Close();
            }
            else
            {
                labelerr1.Settext("Хоосон талбарыг бөглөнө үү !!!");
            }
        }

        private void simpleButton_edit_Click(object sender, EventArgs e)
        {
            if (textEdit_name.Text.Length > 0 && textEdit_price.Text.Length > 0 && textEdit_stock.Text.Length > 0)
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                var _g = (from r in ms.hourtemplates
                          where r.id == Guid.Parse(pid.ToString())
                          select r).SingleOrDefault();
                _g.name = textEdit_name.Text;
                _g.price = int.Parse(textEdit_price.Text);
                _g.minute = int.Parse(textEdit_stock.Text);
                _g.beghour = int.Parse(comboBoxEdit_begd.Text);
                _g.endhour = int.Parse(comboBoxEdit_endd.Text);
                ms.SubmitChanges();
                ok = true;
                this.Close();
            }
            else
            {
                labelerr1.Settext("Хоосон талбарыг бөглөнө үү !!!");
            }
        }
    }
}