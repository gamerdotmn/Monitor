namespace Monitor
{
    partial class posa
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(posa));
            this.xtraTabControl_item = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_category = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textBox_catname = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_catdel = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection_img = new DevExpress.Utils.ImageCollection(this.components);
            this.simpleButton_catadd = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_edit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_itemname = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_itemprice = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit_itemcat = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton_delitem = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_additem = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_item)).BeginInit();
            this.xtraTabControl_item.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_catname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection_img)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_itemname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_itemprice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_itemcat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl_item
            // 
            this.xtraTabControl_item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_item.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_item.Name = "xtraTabControl_item";
            this.xtraTabControl_item.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl_item.Size = new System.Drawing.Size(640, 480);
            this.xtraTabControl_item.TabIndex = 0;
            this.xtraTabControl_item.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl_item.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl_item_SelectedPageChanged);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl_category);
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(634, 452);
            this.xtraTabPage1.Text = "Ангилал";
            // 
            // gridControl_category
            // 
            this.gridControl_category.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_category.Location = new System.Drawing.Point(0, 47);
            this.gridControl_category.MainView = this.gridView1;
            this.gridControl_category.Name = "gridControl_category";
            this.gridControl_category.Size = new System.Drawing.Size(634, 405);
            this.gridControl_category.TabIndex = 1;
            this.gridControl_category.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl_category;
            this.gridView1.GroupPanelText = "Барааны ангилал оруулна. Жишээ нь : Ундаа,Хоол г.м";
            this.gridView1.Name = "gridView1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textBox_catname);
            this.panelControl1.Controls.Add(this.simpleButton_catdel);
            this.panelControl1.Controls.Add(this.simpleButton_catadd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(634, 47);
            this.panelControl1.TabIndex = 0;
            // 
            // textBox_catname
            // 
            this.textBox_catname.Location = new System.Drawing.Point(14, 17);
            this.textBox_catname.Name = "textBox_catname";
            this.textBox_catname.Size = new System.Drawing.Size(130, 20);
            this.textBox_catname.TabIndex = 6;
            // 
            // simpleButton_catdel
            // 
            this.simpleButton_catdel.ImageIndex = 1;
            this.simpleButton_catdel.ImageList = this.imageCollection_img;
            this.simpleButton_catdel.Location = new System.Drawing.Point(237, 14);
            this.simpleButton_catdel.Name = "simpleButton_catdel";
            this.simpleButton_catdel.Size = new System.Drawing.Size(71, 26);
            this.simpleButton_catdel.TabIndex = 2;
            this.simpleButton_catdel.Text = "Устгах";
            this.simpleButton_catdel.Click += new System.EventHandler(this.simpleButton_catdel_Click);
            // 
            // imageCollection_img
            // 
            this.imageCollection_img.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection_img.ImageStream")));
            this.imageCollection_img.Images.SetKeyName(0, "Add.png");
            this.imageCollection_img.Images.SetKeyName(1, "delete-2.png");
            this.imageCollection_img.Images.SetKeyName(2, "edit.png");
            // 
            // simpleButton_catadd
            // 
            this.simpleButton_catadd.ImageIndex = 0;
            this.simpleButton_catadd.ImageList = this.imageCollection_img;
            this.simpleButton_catadd.Location = new System.Drawing.Point(150, 14);
            this.simpleButton_catadd.Name = "simpleButton_catadd";
            this.simpleButton_catadd.Size = new System.Drawing.Size(81, 26);
            this.simpleButton_catadd.TabIndex = 1;
            this.simpleButton_catadd.Text = "Нэмэх";
            this.simpleButton_catadd.Click += new System.EventHandler(this.simpleButton_catadd_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.treeList1);
            this.xtraTabPage2.Controls.Add(this.panelControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(634, 452);
            this.xtraTabPage2.Text = "Цэс";
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 102);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.Size = new System.Drawing.Size(634, 350);
            this.treeList1.TabIndex = 2;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton_edit);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.textEdit_itemname);
            this.panelControl2.Controls.Add(this.textEdit_itemprice);
            this.panelControl2.Controls.Add(this.comboBoxEdit_itemcat);
            this.panelControl2.Controls.Add(this.simpleButton_delitem);
            this.panelControl2.Controls.Add(this.simpleButton_additem);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(634, 102);
            this.panelControl2.TabIndex = 1;
            this.panelControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl2_MouseDown);
            // 
            // simpleButton_edit
            // 
            this.simpleButton_edit.ImageIndex = 2;
            this.simpleButton_edit.ImageList = this.imageCollection_img;
            this.simpleButton_edit.Location = new System.Drawing.Point(237, 67);
            this.simpleButton_edit.Name = "simpleButton_edit";
            this.simpleButton_edit.Size = new System.Drawing.Size(81, 26);
            this.simpleButton_edit.TabIndex = 9;
            this.simpleButton_edit.Text = "Засах";
            this.simpleButton_edit.Click += new System.EventHandler(this.simpleButton_edit_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Ангилал :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Үнэ :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Барааны нэр :";
            // 
            // textEdit_itemname
            // 
            this.textEdit_itemname.Location = new System.Drawing.Point(87, 17);
            this.textEdit_itemname.Name = "textEdit_itemname";
            this.textEdit_itemname.Size = new System.Drawing.Size(133, 20);
            this.textEdit_itemname.TabIndex = 1;
            // 
            // textEdit_itemprice
            // 
            this.textEdit_itemprice.Location = new System.Drawing.Point(87, 43);
            this.textEdit_itemprice.Name = "textEdit_itemprice";
            this.textEdit_itemprice.Properties.Mask.EditMask = "n0";
            this.textEdit_itemprice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_itemprice.Size = new System.Drawing.Size(133, 20);
            this.textEdit_itemprice.TabIndex = 2;
            // 
            // comboBoxEdit_itemcat
            // 
            this.comboBoxEdit_itemcat.Location = new System.Drawing.Point(87, 70);
            this.comboBoxEdit_itemcat.Name = "comboBoxEdit_itemcat";
            this.comboBoxEdit_itemcat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_itemcat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_itemcat.Size = new System.Drawing.Size(133, 20);
            this.comboBoxEdit_itemcat.TabIndex = 3;
            // 
            // simpleButton_delitem
            // 
            this.simpleButton_delitem.ImageIndex = 1;
            this.simpleButton_delitem.ImageList = this.imageCollection_img;
            this.simpleButton_delitem.Location = new System.Drawing.Point(333, 66);
            this.simpleButton_delitem.Name = "simpleButton_delitem";
            this.simpleButton_delitem.Size = new System.Drawing.Size(71, 26);
            this.simpleButton_delitem.TabIndex = 8;
            this.simpleButton_delitem.Text = "Устгах";
            this.simpleButton_delitem.Click += new System.EventHandler(this.simpleButton_delitem_Click);
            // 
            // simpleButton_additem
            // 
            this.simpleButton_additem.ImageIndex = 0;
            this.simpleButton_additem.ImageList = this.imageCollection_img;
            this.simpleButton_additem.Location = new System.Drawing.Point(237, 66);
            this.simpleButton_additem.Name = "simpleButton_additem";
            this.simpleButton_additem.Size = new System.Drawing.Size(81, 26);
            this.simpleButton_additem.TabIndex = 4;
            this.simpleButton_additem.Text = "Нэмэх";
            this.simpleButton_additem.Click += new System.EventHandler(this.simpleButton_additem_Click);
            // 
            // posa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl_item);
            this.Name = "posa";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_item)).EndInit();
            this.xtraTabControl_item.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBox_catname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection_img)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_itemname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_itemprice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_itemcat.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl_item;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl_category;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_catdel;
        private DevExpress.XtraEditors.SimpleButton simpleButton_catadd;
        private DevExpress.Utils.ImageCollection imageCollection_img;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_delitem;
        private DevExpress.XtraEditors.SimpleButton simpleButton_additem;
        private DevExpress.XtraEditors.TextEdit textBox_catname;
        private DevExpress.XtraEditors.TextEdit textEdit_itemname;
        private DevExpress.XtraEditors.TextEdit textEdit_itemprice;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_itemcat;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_edit;


    }
}
