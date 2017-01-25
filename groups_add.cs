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
    public partial class groups_add : DevExpress.XtraEditors.XtraForm
    {
        public bool ok = false;
        public bool update = false;
        public string id;
        public groups_add(string _id)
        {
            InitializeComponent();
            if (id != null)
            {
                id = _id;
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                var _group = (from g in ms.groups where g.id == Guid.Parse(id) select g).SingleOrDefault();
                textEdit_name.Text = _group.name;
                textEdit_min_price.Text = _group.minprice.ToString();
                textEdit_member.Text = _group.memberprice.ToString();
                textEdit_timecode.Text = _group.timecodeprice.ToString();
                textEdit_hour.Text = _group.hourprice.ToString();
                if (_group.timecode == false) { checkEdit_timecode_ok.Checked = false; }
                if (_group.member == false) { checkEdit_member_ok.Checked = false; }
                if (_group.hour == false) { checkEdit_hour_ok.Checked = false; }
                if (_group.prepairhour == false) { checkEdit_sethour_ok.Checked = false; }
                if (_group.vip == false) { checkEdit_vip_ok.Checked = false; }
            }
        }

        private void simpleButton_save_Click(object sender, EventArgs e)
        {
            if (textEdit_name.Text.Length > 0 && textEdit_hour.Text.Length > 0 && textEdit_member.Text.Length > 0 && textEdit_min_price.Text.Length > 0 && textEdit_timecode.Text.Length > 0)
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                if (update)
                {
                    var _g = (from r in ms.groups where r.id == Guid.Parse(id) select r).FirstOrDefault();
                    _g.name = textEdit_name.Text;
                    if (checkEdit_vip_ok.Checked) { _g.vip = true; }
                    else { _g.vip = false; }
                    _g.timecodeprice = int.Parse(textEdit_timecode.Text);
                    if (checkEdit_timecode_ok.Checked) { _g.timecode = true; }
                    else { _g.timecode = false; }
                    _g.memberprice = int.Parse(textEdit_member.Text);
                    if (checkEdit_member_ok.Checked) { _g.member = true; }
                    else { _g.member = false; }
                    _g.hourprice = int.Parse(textEdit_hour.Text);
                    if (checkEdit_hour_ok.Checked) { _g.hour = true; }
                    else { _g.hour = false; }
                    if (checkEdit_sethour_ok.Checked) { _g.prepairhour = true; }
                    else { _g.prepairhour = false; }
                    _g.minprice = int.Parse(textEdit_min_price.Text);
                    ms.groups.InsertOnSubmit(_g);
                    ms.SubmitChanges();
                    ok = true;
                    this.Close();
                }
                else
                {
                    group _g = new group();
                    _g.id = Guid.NewGuid();
                    _g.name = textEdit_name.Text;
                    if (checkEdit_vip_ok.Checked) { _g.vip = true; }
                    else { _g.vip = false; }
                    _g.timecodeprice = int.Parse(textEdit_timecode.Text);
                    if (checkEdit_timecode_ok.Checked) { _g.timecode = true; }
                    else { _g.timecode = false; }
                    _g.memberprice = int.Parse(textEdit_member.Text);
                    if (checkEdit_member_ok.Checked) { _g.member = true; }
                    else { _g.member = false; }
                    _g.hourprice = int.Parse(textEdit_hour.Text);
                    if (checkEdit_hour_ok.Checked) { _g.hour = true; }
                    else { _g.hour = false; }
                    if (checkEdit_sethour_ok.Checked) { _g.prepairhour = true; }
                    else { _g.prepairhour = false; }
                    _g.minprice = int.Parse(textEdit_min_price.Text);
                    ms.groups.InsertOnSubmit(_g);
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