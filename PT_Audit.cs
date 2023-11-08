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
    public partial class PT_Audit : Form
    {
        public static string inline = "";
        public PT_Audit()
        {
            InitializeComponent();
        }

        private void lblSection_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnProceedtoAudit1_Click(object sender, EventArgs e)
        {
            btnProceedtoAudit1.Text = "Assembly Process Patrol";

            inline = btnProceedtoAudit1.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void PT_Audit_Load(object sender, EventArgs e)
        {
            if (LOGIN.loginuser != null)
            {
                if (WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;

                lbl_IDNum.Text = LOGIN.loginuser;
                lbl_Name.Text = LOGIN.loginName;
                lbl_Authority.Text = LOGIN.loginAutho;
                lblSection.Text = LOGIN.LoginSection;
                lblID_Num.Text = LOGIN.loginuser;

            }
        }

        private void btnProceedtoAudit2_Click(object sender, EventArgs e)
        {
            btnProceedtoAudit2.Text = "ESD Checksheet";

            inline = btnProceedtoAudit2.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnStartAudit_Click(object sender, EventArgs e)
        {
            btnStartAudit.Text = "Process Audit Checksheet";

            inline = btnStartAudit.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
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

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN aaa = new LOGIN();
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

        private void lblLogout_MouseEnter(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.LightBlue;
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.FromArgb(0, 188, 212);
        }

        private void btnSummary1_Click(object sender, EventArgs e)
        {
            btnSummary1.Text = "Assembly Process Patrol";

            inline = btnSummary1.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnSummary2_Click(object sender, EventArgs e)
        {
            btnSummary2.Text = "ESD Checksheet";

            inline = btnSummary2.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void jeButton3_Click(object sender, EventArgs e)
        {
            jeButton3.Text = "Process Audit Checksheet";

            inline = jeButton3.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
            aaa.ShowDialog();
            this.Close();
        }
    }
}
