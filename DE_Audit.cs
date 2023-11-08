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
    public partial class DE_Audit : Form
    {
        public static string inline = "";
        public DE_Audit()
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
            btnProceedtoAudit1.Text = "Torque Driver Setting Checklist";

            inline = btnProceedtoAudit1.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnProceedtoAudit2_Click(object sender, EventArgs e)
        {
            btnProceedtoAudit2.Text = "Jig Checklist";

            inline = btnProceedtoAudit2.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnStartAudit_Click(object sender, EventArgs e)
        {
            btnStartAudit.Text = "Greasing Checking";

            inline = btnStartAudit.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnProceed3_Click(object sender, EventArgs e)
        {
            btnProceed3.Text = "Machine Checking";

            inline = btnProceed3.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void DE_Audit_Load(object sender, EventArgs e)
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

        private void btnSummary1_Click(object sender, EventArgs e)
        {
            btnSummary1.Text = "Torque Driver Setting Checklist";

            inline = btnSummary1.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnSummary2_Click(object sender, EventArgs e)
        {
            btnSummary2.Text = "Jig Checklist";

            inline = btnSummary2.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnSummary3_Click(object sender, EventArgs e)
        {
            btnSummary3.Text = "Greasing Checking";

            inline = btnSummary3.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnSummary4_Click(object sender, EventArgs e)
        {
            btnSummary4.Text = "Machine Checking";

            inline = btnSummary4.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {

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

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
            aaa.ShowDialog();
            this.Close();
        }
    }
}
