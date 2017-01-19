using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using System.Drawing.Printing;

namespace Monitor
{
    public partial class pos : UserControl
    {
        private string seperator = "---------------------------------------";
        private DataTable dt;
        private bool sep_header;
        private bool sep_rows;
        int c = 0;
        private int[] maxs;
        public string p_header = string.Empty;
        public string p_text = string.Empty;
        public string p_footer = string.Empty;
        public FontStyle h_fontstyle = FontStyle.Regular;
        public float h_size = 9.25f;
        public FontStyle f_fontstyle = FontStyle.Bold;
        public float f_size = 9.25f;
        public string printername = "";
        Hashtable[] ht;
        Hashtable ti = new Hashtable();

        public void fill()
        {
            try
            {
                int w = xtraTabControl_cats.Width;
                int h = xtraTabControl_cats.Height;
                int cw = w / 90;

                for (int i = 0; i < xtraTabControl_cats.TabPages.Count; i++)
                {
                    xtraTabControl_cats.TabPages[i].Controls.Clear();
                     PanelControl _panel_control = new PanelControl();
                    _panel_control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                    DevExpress.XtraEditors.VScrollBar _vs = new DevExpress.XtraEditors.VScrollBar();
                    _vs.Dock = DockStyle.Right;
                    _vs.Width = 25;
                    _vs.LargeChange = 80;
                    _vs.SmallChange = 10;
                    _vs.Scroll += new ScrollEventHandler(_vs_Scroll);
                    _vs.Maximum = 40 * ht[i].Keys.Count;
                    _panel_control.Dock = DockStyle.Fill;
                    xtraTabControl_cats.TabPages[i].Controls.Add(_panel_control);
                    xtraTabControl_cats.TabPages[i].Controls.Add(_vs);

                    int x = 0;
                    int y = 0;
                    int[] keys = new int[ht[i].Keys.Count];
                    ht[i].Keys.CopyTo(keys, 0);
                    for (int j = 0; j < ht[i].Keys.Count; j++)
                    {
                        DevExpress.XtraEditors.SimpleButton _sb = new SimpleButton();
                        item _i = (item)ht[i][keys[j]];
                        _sb.Text = _i.name.ToString();
                        _sb.Name = _i.id.ToString();
                        _sb.Size = new Size(90, 30);
                        _sb.Font = new Font("Tohama", 8.25f);
                        _sb.Location = new Point(x*100+20,y*40+20);
                        _sb.Click += new EventHandler(_sb_Click);
                        _sb.Tag = (y * 40 + 20).ToString();
                        _panel_control.Controls.Add(_sb);
                        x++;
                        if (cw == x)
                        {
                            y++;
                            x = 0;
                        }
                    }
                    _panel_control.Refresh();
                }
            }
            catch { ;}
        }
        private void recalc()
        {
            int sum = 0;
            for (int i = 0; i < listView_order.Items.Count; i++)
            {
                sum += int.Parse(listView_order.Items[i].SubItems[3].Text.ToString());
            }
            textEdit_sum.Text = sum.ToString("#,##0");
            if (sum > 0)
            {
                simpleButton_save.Enabled = true;
            }
            else
            {
                simpleButton_save.Enabled = false;
            }
        }
        void _vs_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                DevExpress.XtraEditors.VScrollBar _vs = (DevExpress.XtraEditors.VScrollBar)sender;
                for (int i = 0; i < xtraTabControl_cats.SelectedTabPage.Controls[0].Controls.Count; i++)
                {
                    DevExpress.XtraEditors.SimpleButton _sb = (DevExpress.XtraEditors.SimpleButton)xtraTabControl_cats.SelectedTabPage.Controls[0].Controls[i];
                    _sb.Top = int.Parse(_sb.Tag.ToString()) - _vs.Value;
                }
                xtraTabControl_cats.SelectedTabPage.Controls[0].Refresh();
            }
        }
        void _sb_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton _sb = (DevExpress.XtraEditors.SimpleButton)sender;
            int id = int.Parse(_sb.Name);
            int j=0;
            if (ti.ContainsKey(id))
            {
                for (int i = 0; i < listView_order.Items.Count; i++)
                {
                    if (listView_order.Items[i].Name == id.ToString())
                    {
                        int price = int.Parse(listView_order.Items[i].SubItems[3].Text) / int.Parse(listView_order.Items[i].SubItems[2].Text);
                        listView_order.Items[i].SubItems[2].Text = (int.Parse(listView_order.Items[i].SubItems[2].Text) + 1).ToString();
                        listView_order.Items[i].SubItems[3].Text = (int.Parse(listView_order.Items[i].SubItems[3].Text) +price).ToString();
                    }
                }
            }
            else
            {
               DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
               var _item = (from k in ms.items where k.id == Guid.Parse(id.ToString()) select k).SingleOrDefault();
               string[] row = { (listView_order.Items.Count+1).ToString(), _item.name, "1",_item.price.ToString() };
               var listViewItem = new ListViewItem(row);
               listViewItem.Name = _item.id.ToString();
               listView_order.Items.Add(listViewItem);
               ti.Add(id, j);
               j++;
            }
            recalc();
        }

        public pos()
        {
            InitializeComponent();
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            var _cats = (from r in ms.categories orderby r.name select r).ToList();
            int i = 0;
            ht = new Hashtable[_cats.Count()];
            foreach (var _c in _cats)
            {
                DevExpress.XtraTab.XtraTabPage _XtraTabPage = new DevExpress.XtraTab.XtraTabPage();
                _XtraTabPage.Name = _c.id.ToString();
                _XtraTabPage.Text = _c.name;
                _XtraTabPage.ImageIndex = 0;
                _XtraTabPage.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                _XtraTabPage.Appearance.Header.Options.UseFont = true;
                xtraTabControl_cats.TabPages.Add(_XtraTabPage);
                ht[i] = new Hashtable();
                var _items = from _i in ms.items orderby _i.name where  _i.category_id == _c.id select _i;
                foreach (var _item in _items)
                {
                    ht[i].Add(_item.id, _item);
                }
                i++;
            }
            textEdit_sum.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            fill();
            simpleButton_save.Enabled = false;
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (listView_order.SelectedItems.Count ==0)
            {
                e.Cancel=true;
            }
        }

        private void simpleButton_save_Click(object sender, EventArgs e)
        {
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            string employee_name = "admin";
            for (int i = 0; i < listView_order.Items.Count; i++)
            {
                employee_sale sale = new employee_sale();
                sale.item_id = Guid.Parse(listView_order.Items[i].Name);
                sale.qnt = int.Parse(listView_order.Items[i].SubItems[2].Text);
                sale.total = int.Parse(listView_order.Items[i].SubItems[3].Text);
                sale.price = int.Parse(listView_order.Items[i].SubItems[3].Text) / int.Parse(listView_order.Items[i].SubItems[2].Text);
                sale.ot = DateTime.Now;
                sale.empoyee_name = employee_name;
                ms.employee_sales.InsertOnSubmit(sale);
                ms.SubmitChanges();

            }
            try
            {
                var _cfg = (from c in ms.configs select c).SingleOrDefault();
                //print
                print(_cfg.org_name,"Нийт:"+textEdit_sum.Text);
            }catch{;}
            
            ti.Clear();
            listView_order.Items.Clear();
            textEdit_sum.Text = "0";
            simpleButton_save.Enabled = false;
        }
        private void print(string _p_header,string _p_footer)
        {
            p_text = string.Empty;
            p_header = _p_header;
            p_footer = _p_footer;
            int i;
            maxs = new int[listView_order.Columns.Count];
            for (i = 0; i < listView_order.Columns.Count; i++)
            {
                maxs[i] = listView_order.Columns[i].Text.Length;
            }
            for (int j = 0; j < listView_order.Items.Count; j++)
            {
                for (i = 0; i < listView_order.Columns.Count; i++)
                {
                    if (listView_order.Items[j].SubItems[i].Text.ToString().Length > maxs[i])
                    {
                        maxs[i] = listView_order.Items[j].SubItems[i].Text.ToString().Length;
                    }
                }
            }
            for (i = 0; i < listView_order.Columns.Count; i++)
            {
                p_text += " " + space(maxs[i], listView_order.Columns[i].Text, true);
            }
            p_text += "\n";
            
            p_text += seperator + "\n";
            
            for (i = 0; i < listView_order.Items.Count; i++)
            {
                for (int j = 0; j < listView_order.Columns.Count; j++)
                {
                    p_text += " " + space(maxs[j], listView_order.Items[i].SubItems[j].Text.ToString(), true);
                }
                p_text += "\n";
            }
            p_text += seperator + "\n";
            
            PrintDocument pd = new PrintDocument();
            if (printername != null)
            {
                if (printername.Length > 0)
                {
                    pd.PrinterSettings.PrinterName = printername;
                }
            }
            if (pd.PrinterSettings.IsValid)
            {
                pd.PrintPage += new PrintPageEventHandler(this.PrintPageEvent);
                pd.Print();
            }
            else
            {
                MessageBox.Show(printername + " асуудалтай байна.");
            }
        }
        private string space(int max, string text, bool left)
        {
            string space = "";
            for (int i = 0; i < max - text.Length; i++)
            {
                space += " ";
            }
            if (left)
            {
                return (space + text);
            }
            else
            {
                return (text + space);
            }
        }
        private void PrintPageEvent(object sender, PrintPageEventArgs ev)
        {
            Font oFont_header = new Font("Courier New", h_size, h_fontstyle);
            Font oFont_text = new Font("Courier New", 9.25F);
            Font oFont_footer = new Font("Courier New", f_size, f_fontstyle);
            SizeF s_header = ev.Graphics.MeasureString(p_header, oFont_footer);
            SizeF s_text = ev.Graphics.MeasureString(p_text, oFont_text);
            SizeF s_footer = ev.Graphics.MeasureString(p_footer, oFont_footer);

            ev.Graphics.DrawString(p_header, oFont_header, new SolidBrush(System.Drawing.Color.Black), 0, 0);

            ev.Graphics.DrawString(p_text, oFont_text, new SolidBrush(System.Drawing.Color.Black), 0, s_header.Height);

            ev.Graphics.DrawString(p_footer, oFont_footer, new SolidBrush(System.Drawing.Color.Black), 0, s_header.Height + s_text.Height);

        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_order.SelectedItems.Count > 0)
            {
                ti.Remove(int.Parse(listView_order.SelectedItems[0].Name));
                listView_order.SelectedItems[0].Remove();
                recalc();

            }
        }
    }
}
