using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Monitor
{
    public partial class connecting : SplashScreen
    {
        public connecting()
        {
            InitializeComponent();
            labelControl_copyright.Text = labelControl_copyright.Text + DateTime.Now.Year;
        }

        private void labelControl_link_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http:\\www.gamer.mn");
        }

        private void simpleButton_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}