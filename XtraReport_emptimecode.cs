using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Monitor
{
    public partial class XtraReport_emptimecode : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_emptimecode(string text)
        {
            InitializeComponent();
            xrLabel9.Text = text;
        }

    }
}
