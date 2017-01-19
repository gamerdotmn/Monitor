using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Monitor
{
    public partial class XtraReport_clienthours : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_clienthours(string text)
        {
            InitializeComponent();
            xrLabel9.Text = text;
        }

    }
}
