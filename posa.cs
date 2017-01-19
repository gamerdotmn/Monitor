using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
namespace Monitor
{
    public partial class posa : UserControl
    {
        Hashtable ht = new Hashtable();
        private int editid = 0;
        public posa()
        {
            InitializeComponent();
            reset();
        }
        private void reset()
        {

            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            gridControl_category.DataSource = (from t in ms.categories
                                       select new
                                       {
                                           Дугаар = t.id,
                                           Нэр = t.name
                                       }).ToList();
        }

        private void simpleButton_catadd_Click(object sender, EventArgs e)
        {
            if (textBox_catname.Text.Length > 0)
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                category c = new category();
                c.name = textBox_catname.Text;
                ms.categories.InsertOnSubmit(c);
                ms.SubmitChanges();
                textBox_catname.Text = "";
                reset();
            }
        }

        private void simpleButton_catdel_Click(object sender, EventArgs e)
        {
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            if (MessageBox.Show("Та " + gridView1.GetFocusedRowCellValue("Нэр").ToString() + " нэртэй ангилалыг устгахдаа итгэлтэй байна уу?", "Баталгаажуулалт", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                category _c = ms.categories.Single(p => p.id == Guid.Parse(gridView1.GetFocusedRowCellValue("Дугаар").ToString()));
                ms.categories.DeleteOnSubmit(_c);
                ms.SubmitChanges();
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }

        }

        private void xtraTabControl_item_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl_item.SelectedTabPageIndex == 1)
            {
                ritems();
            }
        }
        private void ritems()
        {
            treeList1.ClearNodes();
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            var _cats=(from r in ms.categories select r).ToList();
            var i=0;
            ht.Clear();
            comboBoxEdit_itemcat.Properties.Items.Clear();
            foreach(var cats in _cats)
            {
                comboBoxEdit_itemcat.Properties.Items.Add(cats.name);
                ht.Add(i,cats.id);
                i++;
            }
            comboBoxEdit_itemcat.SelectedIndex = 0;
            CreateColumns(treeList1);
            CreateNodes(treeList1);
        }
        private void CreateColumns(TreeList tl)
        {
            // Create three columns.
            tl.BeginUpdate();
            tl.Columns.Add();
            tl.Columns[0].Caption = "#";
            tl.Columns[0].VisibleIndex = 0;
            tl.Columns.Add();
            tl.Columns[1].Caption = "Нэр";
            tl.Columns[1].VisibleIndex = 1;
            tl.Columns.Add();
            tl.Columns[2].Caption = "Үнэ";
            tl.Columns[2].VisibleIndex = 2;
            tl.Columns.Add();
            tl.Columns[3].Caption = "Ангилал";
            tl.Columns[3].VisibleIndex = 3;
            tl.EndUpdate();
        }
        private void CreateNodes(TreeList tl)
        {
            DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
            var _cats = (from r in ms.categories select r).ToList();
            tl.BeginUnboundLoad();
            // Create a root node .
            TreeListNode parentForRootNodes = null;
            foreach (var _c in _cats)
            {
                TreeListNode rootNode = tl.AppendNode(
                                new object[] { _c.name, "", "","" },
                                parentForRootNodes);
                var _items = (from i in ms.items where i.category_id ==_c.id select i).ToList();
                foreach (var _i in _items)
                {
                    tl.AppendNode(new object[] { _i.id, _i.name, _i.price,_i.category.name }, rootNode);
                }
            }
            tl.ExpandAll();
            tl.EndUnboundLoad();
        }

        private void simpleButton_additem_Click(object sender, EventArgs e)
        {
            if (textEdit_itemname.Text.Length > 0 && textEdit_itemprice.Text.Length > 0)
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                item c = new item();
                c.name = textEdit_itemname.Text;
                c.price = int.Parse(textEdit_itemprice.Text);
                c.category_id=Guid.Parse(ht[comboBoxEdit_itemcat.SelectedIndex].ToString());
                ms.items.InsertOnSubmit(c);
                ms.SubmitChanges();
                textEdit_itemname.Text = "";
                textEdit_itemprice.Text = "";
                ritems();
            }

        }

        private void simpleButton_delitem_Click(object sender, EventArgs e)
        {
           int id= int.Parse(treeList1.FocusedNode.GetValue(0).ToString());
           DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
           if (MessageBox.Show("Та " + treeList1.FocusedNode.GetValue(1).ToString() + " нэртэй барааг устгахдаа итгэлтэй байна уу?", "Баталгаажуулалт", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
           {
               item _c = ms.items.Single(p => p.id == Guid.Parse(treeList1.FocusedNode.GetValue(0).ToString()));
               ms.items.DeleteOnSubmit(_c);
               ms.SubmitChanges();
               treeList1.DeleteNode(treeList1.FocusedNode);
           }
           
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

            try
            {
                int id=int.Parse(treeList1.FocusedNode.GetValue(0).ToString());
                simpleButton_additem.Visible = false;
                simpleButton_edit.Visible = true;
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                var _item = (from r in ms.items where r.id==Guid.Parse(id.ToString()) select r).Single();
                textEdit_itemname.Text = _item.name;
                textEdit_itemprice.Text = _item.price.ToString();
                comboBoxEdit_itemcat.Text = _item.category.name;
                editid = id;
            }catch{
                simpleButton_additem.Visible = true;
                simpleButton_edit.Visible = false;
                textEdit_itemname.Text = "";
                textEdit_itemprice.Text = "";
                editid = 0;
            }
        }

        private void panelControl2_MouseDown(object sender, MouseEventArgs e)
        {
            simpleButton_additem.Visible = true;
            simpleButton_edit.Visible = false;
            textEdit_itemname.Text ="";
            textEdit_itemprice.Text = "";
            editid = 0;
        }

        private void simpleButton_edit_Click(object sender, EventArgs e)
        {
            if (editid > 0)
            {
                DataContext_mastercafe ms = new DataContext_mastercafe(Program.constr);
                var _item = (from r in ms.items where r.id == Guid.Parse(editid.ToString()) select r).Single();
                _item.name = textEdit_itemname.Text;
                _item.price = int.Parse(textEdit_itemprice.Text);
                _item.category_id = Guid.Parse(ht[comboBoxEdit_itemcat.SelectedIndex].ToString());
                ms.SubmitChanges();
                ritems();
            }
        }
    }
}
