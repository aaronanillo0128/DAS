using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.IO;


namespace PS_Digital_Audit
{
    public partial class Section_Checksheet : Form
    {

        public static string inline = "";


        public Section_Checksheet()
        {
            InitializeComponent();
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

            double sizewidth = pictureBox2.Width / 2;
            double sizeform = this.Width / 2;
            double minus = sizeform - sizewidth;
            int x = Int32.Parse(minus.ToString());
            pictureBox2.Location = new Point(x, 77);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
            aaa.ShowDialog();
            this.Close();
        }

        private void jeButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN aaa = new LOGIN();
            aaa.ShowDialog();
            this.Close();
        }

        private void Section_Checksheet_Load(object sender, EventArgs e)
        {
            if (LOGIN.loginuser != null)
            {

                if (WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;

                double sizewidth = pictureBox2.Width / 2;
                double sizeform = this.Width / 2;
                double minus = sizeform - sizewidth;
                int x = Int32.Parse(minus.ToString());
                pictureBox2.Location = new Point(x, 77);

                lbl_IDNum.Text = LOGIN.loginuser;
                lbl_Name.Text = LOGIN.loginName;
                lbl_Authority.Text = LOGIN.loginAutho;
                lblSection.Text = LOGIN.LoginSection;
                lblID_Num.Text = LOGIN.loginuser;

            }
            if(lbl_Authority.Text != "Engineer" && lbl_Authority.Text != "Supervisor" && lbl_Authority.Text != "Manager")
            {
                btnCreateAcct.Enabled = false;
            }
            
        }

        private void btnProceedtoAudit1_Click(object sender, EventArgs e)
        {

            btnProceedtoAudit1.Text = "Inline Audit";

            inline = btnProceedtoAudit1.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnProceedtoAudit2_Click(object sender, EventArgs e)
        {

            btnProceedtoAudit2.Text = "PS Process Audit";

            inline = btnProceedtoAudit2.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnProceedtoAudit3_Click(object sender, EventArgs e)
        {
            btnProceedtoAudit3.Text = "PACKING AUDIT";

            inline = btnProceedtoAudit3.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnSummary1_Click(object sender, EventArgs e)
        {
            btnSummary1.Text = "Inline Audit";

            inline = btnSummary1.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnSummary2_Click(object sender, EventArgs e)
        {
            btnSummary2.Text = "PS Process Audit";

            inline = btnSummary2.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnSummary3_Click(object sender, EventArgs e)
        {

            btnSummary3.Text = "PACKING AUDIT";

            inline = btnSummary3.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
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

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN aaa = new LOGIN();
            aaa.ShowDialog();
            this.Close();

        }

        private void btnCreateAcct_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Account aaa = new Add_Account();
            aaa.ShowDialog();
            this.Close();
        }

        private void Section_Checksheet_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void btnProceedtoAudit4_Click(object sender, EventArgs e)
        {
            btnProceedtoAudit4.Text = "QOI AUDIT";

            inline = btnProceedtoAudit4.Text;

            this.Hide();
            PSCategory aaa = new PSCategory();
            aaa.ShowDialog();
            this.Close();
        }

        private void btnSummary4_Click(object sender, EventArgs e)
        {
            btnSummary4.Text = "ROI AUDIT";

            inline = btnSummary4.Text;

            this.Hide();
            ProblemSummary aaa = new ProblemSummary();
            aaa.ShowDialog();
            this.Close();
        }
    }
}
