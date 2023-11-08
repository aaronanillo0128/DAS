using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_Digital_Audit
{
    public partial class lblManual : Form
    {
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlDataAdapter adapt;
        public lblManual()
        {
            InitializeComponent();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select DISTINCT [AUDIT ID],Expr4, Expr8,Expr10,Expr11, [delete], Edit from Monitoring where Expr5 = '" + LOGIN.loginName + "' AND Section = '" + LOGIN.LoginSection + "' AND Flag6 != 'Closed'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void DisplayData1()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select DISTINCT AuditID,Auditor,Line,Process,Series,[View],[delete],Model,Shift from Approval where First_Approver = '" + LOGIN.loginName + "' AND Section = '" + LOGIN.LoginSection + "' AND case when First_Status is NULL then 0 when First_Status = '' then 0 else 1 end=0", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

        }
        private void DisplayData2()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select DISTINCT AuditID,Auditor,Line,Process,Series,[View],[delete],Shift,Model from Approval where Second_Approver = '" + LOGIN.loginName + "' AND case when Second_Status is NULL then 0 when Second_Status = '' then 0 else 1 end=0", con);
            adapt.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void DisplayData3()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select DISTINCT AuditID,Auditor,Line,Process,Series,[View],[delete],Shift,Model from Approval where Third_Approver = '" + LOGIN.loginName + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0", con);
            adapt.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();
        }
            Label clickedLabel;


        private void Dashboard_Load(object sender, EventArgs e)
        {
           

            DisplayData();
            DisplayData1();
            DisplayData2();
            DisplayData3();
            lblCountNotif1.Text = dataGridView1.Rows.Count.ToString();

            if(LOGIN.loginAutho == "Engineer")
            {
                lblNotifEngr.Visible = true;
                lblNotifEngr.Text = dataGridView2.Rows.Count.ToString();
            }
            else if(LOGIN.loginAutho == "Supervisor")
            {
                lblNotifSPV.Visible = true;
                lblNotifSPV.Text = dataGridView3.Rows.Count.ToString();
                lblPendingApproval.Visible = true;
                picPendingApproval.Visible = true;
            }
            else if(LOGIN.loginAutho == "Manager")
            {
                lblNotifMNGR.Visible = true;
                lblNotifMNGR.Text = dataGridView4.Rows.Count.ToString();
                lblPendingApproval.Visible = true;
                picPendingApproval.Visible = true;
            }
           

            if (LOGIN.loginuser != null)
            {
                lbl_IDNum.Text = LOGIN.loginuser;
                lbl_Name.Text = LOGIN.loginName;
                lblAutho.Text = LOGIN.loginAutho;
                lblSection.Text = LOGIN.LoginSection;

                if (WindowState == FormWindowState.Normal)
                {

                    this.WindowState = FormWindowState.Maximized;
                }

                else
                {

                    this.WindowState = FormWindowState.Normal;
                }

                double sizewidth1 = lbl_Name.Width / 2;
                double sizeform1 = this.Width / 2;
                double minus1 = sizeform1 - sizewidth1;
                int x1 = Int32.Parse(minus1.ToString());
                lbl_Name.Location = new Point(x1, 450);

                double sizewidth = pictureBox2.Width / 2;
                double sizeform = this.Width / 2;
                double minus = sizeform - sizewidth;
                int x = Int32.Parse(minus.ToString());
                pictureBox2.Location = new Point(x, 120);

                sizewidth = label26.Width / 2;
                sizeform = this.Width / 2;
                minus = sizeform - sizewidth;
                x = Int32.Parse(minus.ToString());
                label26.Location = new Point(x, 370);

                sizewidth = label1.Width / 2;
                sizeform = this.Width / 2;
                minus = sizeform - sizewidth;
                x = Int32.Parse(minus.ToString());
                label1.Location = new Point(x, 590);

            }
            if (lblAutho.Text !="Engineer" && lblAutho.Text != "Supervisor" && lblAutho.Text != "Manager" && lblAutho.Text != "AdminENG" && lblAutho.Text != "AdminSPV" && lblAutho.Text != "AdminMGR")
            {
                picMasterData.Enabled = false;
                picApproval.Enabled = false;
            }
           
        }

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

        private void lblDashboard_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
            aaa.ShowDialog();
            this.Close();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Import_Master_Data aaa = new Import_Master_Data();
            aaa.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Monitoring aaa = new Monitoring();
            aaa.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResultSummary aaa = new ResultSummary();
            aaa.ShowDialog();
            this.Close();
        }
        PictureBox ClickedPic;
        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.FromArgb(235, 255, 225);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (lblSection.Text == "BPS")
            {
                this.Hide();
                Section_Checksheet aaa = new Section_Checksheet();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "QA")
            {
                this.Hide();
                Section_Checksheet aaa = new Section_Checksheet();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "QI")
            {
                this.Hide();
                Section_Checksheet aaa = new Section_Checksheet();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "PCBA")
            {
                this.Hide();
                PCBA_Audit aaa = new PCBA_Audit();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "Printer")
            {
                this.Hide();
                PRT_Audit aaa = new PRT_Audit();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "INK CARTRIDGE")
            {
                this.Hide();
                IC_Audit aaa = new IC_Audit();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "INK HEAD")
            {
                this.Hide();
                IH_Audit aaa = new IH_Audit();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "TAPE CASSETTE")
            {
                this.Hide();
                TC_Audit aaa = new TC_Audit();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "P-TOUCH")
            {
                this.Hide();
                PT_Audit aaa = new PT_Audit();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "DE")
            {
                this.Hide();
                DE_Audit aaa = new DE_Audit();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "TOOLING ENGINEERING")
            {
                this.Hide();
                Mold_Audit aaa = new Mold_Audit();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "SQC")
            {
                this.Hide();
                SQC_Audit aaa = new SQC_Audit();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "QA PRINTER")
            {
                this.Hide();
                Section_Checksheet aaa = new Section_Checksheet();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "QA PTOUCH")
            {
                this.Hide();
                Section_Checksheet aaa = new Section_Checksheet();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "QA TAPE")
            {
                this.Hide();
                Section_Checksheet aaa = new Section_Checksheet();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblSection.Text == "QA INK")
            {
                this.Hide();
                Section_Checksheet aaa = new Section_Checksheet();
                aaa.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.FromArgb(235, 255, 225);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.FromArgb(235, 255, 225);
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.FromArgb(235, 255, 225);
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.FromArgb(235, 255, 225);
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.FromArgb(235, 255, 225);
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            if (lblAutho.Text == "Engineer")
            {
                this.Hide();
                Pending_Approval aaa = new Pending_Approval();
                aaa.ShowDialog();
                this.Close();
            }
            else if(lblAutho.Text == "Supervisor")
            {
                this.Hide();
                Pending_Approval2 aaa = new Pending_Approval2();
                aaa.ShowDialog();
                this.Close();
            }
            else if(lblAutho.Text == "Manager")
            {
                this.Hide();
                Pending_Approval3 aaa = new Pending_Approval3();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblAutho.Text == "AdminENG")
            {
                this.Hide();
                Pending_Approval aaa = new Pending_Approval();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblAutho.Text == "AdminSPV")
            {
                this.Hide();
                Pending_Approval2 aaa = new Pending_Approval2();
                aaa.ShowDialog();
                this.Close();
            }
            else if (lblAutho.Text == "AdminMGR")
            {
                this.Hide();
                Pending_Approval3 aaa = new Pending_Approval3();
                aaa.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aaa = new Admin();
            aaa.ShowDialog();
            this.Close();
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != ClickedPic)
                theLabel.BackColor = Color.FromArgb(235, 255, 225);
        }

        private void Dashboard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaxi_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {

                this.WindowState = FormWindowState.Maximized;
            }

            else
            {

                this.WindowState = FormWindowState.Normal;
            }
            double sizewidth1 = lbl_Name.Width / 2;
            double sizeform1 = this.Width / 2;
            double minus1 = sizeform1 - sizewidth1;
            int x1 = Int32.Parse(minus1.ToString());
            lbl_Name.Location = new Point(x1, 450);

            double sizewidth = pictureBox2.Width / 2;
            double sizeform = this.Width / 2;
            double minus = sizeform - sizewidth;
            int x = Int32.Parse(minus.ToString());
            pictureBox2.Location = new Point(x, 120);

            sizewidth = label26.Width / 2;
            sizeform = this.Width / 2;
            minus = sizeform - sizewidth;
            x = Int32.Parse(minus.ToString());
            label26.Location = new Point(x, 370);

            sizewidth = label1.Width / 2;
            sizeform = this.Width / 2;
            minus = sizeform - sizewidth;
            x = Int32.Parse(minus.ToString());
            label1.Location = new Point(x, 550);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExportExcel aaa = new ExportExcel();
            aaa.ShowDialog();
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void lbl_IDNum_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void lblPendingApproval_Click(object sender, EventArgs e)
        {
            this.Hide();
            OtherPendingApproval aaa = new OtherPendingApproval();
            aaa.ShowDialog();
            this.Close();
        }

        private void picPendingApproval_Click(object sender, EventArgs e)
        {

        }

        private void lblPendingApproval_MouseEnter(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.LightBlue;
        }

        private void lblPendingApproval_MouseLeave(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.FromArgb(0, 188, 212);
        }

        string outputPath = "http://apbiphsh07/portal/99_Common/ISO/Operational%20Manual/BPS/OM0802-005-00%20Operation%20Manual.docx_DAS_.pdf";
        private void label9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(outputPath);
        } 
    }   
}
