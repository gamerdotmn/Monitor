using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Monitor
{
    public partial class XtraReport_topmember : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_topmember(string text)
        {
            InitializeComponent();
            xrLabel5.Text = text;
        }

    }
}
