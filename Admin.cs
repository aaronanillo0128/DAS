using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_Digital_Audit
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Account aaa = new Add_Account();
            aaa.ShowDialog();
            this.Close();
        }

        private void jeButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NG_Maintenance aaa = new NG_Maintenance();
            aaa.ShowDialog();
            this.Close();
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
            aaa.ShowDialog();
            this.Close();
        }

        Label clickedLabel;
        private void lblDashboard_MouseEnter(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.LightBlue;
        }

        private void lblDashboard_MouseLeave(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.FromArgb(0, 188, 212);
        }

        private void Admin_Load(object sender, EventArgs e)
        {
             if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

            //if(LOGIN.loginAutho != "AdminENG" && LOGIN.loginAutho != "AdminSPV" && LOGIN.loginAutho != "AdminMGR")
            //{
            //    jeButton1.Enabled = false;
            //    jeButton2.Enabled = false;
            //    jeButton3.Enabled = false;
            //    jeButton4.Enabled = false;
            //    jeButton5.Enabled = false;
            //}
        }

        private void jeButton3_Click(object sender, EventArgs e)
        {
            AddModel aaa = new AddModel();
            aaa.ShowDialog();
        }

        private void jeButton2_Click(object sender, EventArgs e)
        {
            AddLine aaa = new AddLine();
            aaa.ShowDialog();
        }

        private void jeButton5_Click(object sender, EventArgs e)
        {
            AddFrequency aaa = new AddFrequency();
            aaa.ShowDialog();
        }

        private void jeButton4_Click(object sender, EventArgs e)
        {
            AddProcess aaa = new AddProcess();
            aaa.ShowDialog();
        }
    }
}
