using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Monitor
{
    public partial class XtraReport_client_timecode : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_client_timecode(string text)
        {
            InitializeComponent();
            xrLabel6.Text = text;
        }

    }
}
