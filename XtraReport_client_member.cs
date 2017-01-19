using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Monitor
{
    public partial class XtraReport_client_member : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_client_member(string text)
        {
            InitializeComponent();
            xrLabel1.Text = text;
        }

    }
}
