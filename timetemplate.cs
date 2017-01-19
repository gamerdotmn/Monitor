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
    public partial class timetemplate : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        public timetemplate(string templatename)
        {
            InitializeComponent();
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            var c = from row in ms.hourtemplates
                    where row.name == templatename
                    select row;
            labelControl3.Text = c.Single().price.ToString();
            //labelControl4.Text = c.Single().stock.ToString();
            labelControl6.Text = c.Single().beghour.ToString();
            labelControl8.Text = c.Single().endhour.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ok = true;
            this.Close();
        }
    }
}