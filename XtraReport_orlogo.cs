using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Monitor
{
    public partial class XtraReport_orlogo : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_orlogo(string text)
        {
            InitializeComponent();
            xrLabel11.Text = text;
        }

    }
}
