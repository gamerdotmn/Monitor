using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Monitor
{
    public partial class XtraReport_employee_member : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_employee_member(string text)
        {
            InitializeComponent();
            xrLabel9.Text = text;
        }

    }
}
