using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_Digital_Audit
{
    public partial class ApprovalLookup2 : Form
    {
        public static Monitoring _instance;
        public static string update = "";
        static string BBB = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;
        int ID = 0;
        public ApprovalLookup2()
        {
            InitializeComponent();
        }

        private void ApprovalLookup2_Load(object sender, EventArgs e)
        {
            if (LOGIN.LoginSection != "QA")
            {
                cmbChecker.Enabled = false;
                cmbChecker.Text = "";
            }
            dataEron.RowTemplate.MinimumHeight = 200;
            DisplayData();
            InputBy();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select TypeofAudit, Auditor, Series, Model, Process, Assurance, Classification, CheckItems, Date, TimeStamp1, Status1,[1stAudit], [1stEnd], Comment1, Remarks1, TypeNG1, NGDetails1, Status2, [2ndAudit], [2ndEnd], Comment2, Remarks2, TypeNG2, NGDetails2, Status3, [3rdAudit], [3rdEnd], Comment3, Remarks3, TypeNG3, NGDetails3,  Status4,  [4thAudit], [4thEnd], Comment4, Remarks4, TypeNG4, NGDetails4, Status5, [5thAudit], [5thEnd], Comment5,  Remarks5, TypeNG5, NGDetails5, Status6, [6thAudit], [6thEnd], Comment6, Remarks6, TypeNG6, NGDetails6, Status7, [7thAudit], [7thEnd], Comment7, Remarks7, TypeNG7, NGDetails7 from tbl_AuditApproval where AuditID = '" + lblAuditID.Text + "'", con);
            adapt.Fill(dt);
            dataEron.DataSource = dt;
            con.Close();

            dataEron.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataEron.AllowUserToResizeColumns = true;
            dataEron.AllowUserToOrderColumns = true;

            this.dataEron.DefaultCellStyle.Font = new Font("Calibri", 11);
            dataEron.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataEron.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataEron.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
            dataEron.EnableHeadersVisualStyles = false;
        }

        public void InputBy()
        {
            using (SqlConnection conn = new SqlConnection(BBB))
            {
                conn.Open();
                string sql = "select Name from tbl_PSuser where Authority = 'Manager' AND Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "Name");
                cmbChecker.DisplayMember = "Name";
                cmbChecker.ValueMember = "Name";
                cmbChecker.DataSource = dt.Tables["Name"];
                conn.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to EXPORT to EXCEL?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                app.Visible = true;

                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                worksheet.Name = "Export to EXCEL";
                for (int i = 1; i < dataEron.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataEron.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataEron.Rows.Count; i++)
                {
                    for (int j = 0; j < dataEron.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataEron.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            else if (dialogResult == DialogResult.No)
            {
                //do Nothing
            }
        }

        public string emailto;
        private string innerString;
        public void audit_email2()
        {
            using (SqlConnection conn = new SqlConnection(BBB))
            {
                string sql = "select Email from tbl_PSuser where Name=@name";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", cmbChecker.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    emailto = dr["Email"].ToString();
                    EmailBody_Audit2();
                    EmailNotif_Audit2();
                }
            }
        }
        private void EmailNotif_Audit2()
        {
            MailMessage mail = new MailMessage("digitalauditadmin@brother-biph.com.ph", emailto);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.UseDefaultCredentials = false;
            client.Host = "10.113.10.1";
            mail.Subject = "DIGITAL AUDIT ADMIN NOTIFICATION";
            mail.Body = innerString;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
        public void EmailBody_Audit2()
        {
            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.Append("<h1><font color=Green>AUDIT REVIEW FOR APPROVAL</h1>");
            builder.Append("<br>");
            builder.Append("<b><h2><font color=black>Good Day!</h2></b><br></font>");
            builder.Append("<b><font color=Black>Please view issued <a href='\\\\apbiphsh07\\D0_ShareBrotherGroup\\19_BPS\\Installer\\PSAudit\\setup.exe'> DIGITAL AUDIT </a> today");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Supervisor:   " + LOGIN.loginName + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Shift:   " + lblShift.Text + "</b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Line Name:   " + lblLine.Text + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Date:   " + date1 + " " + timeString + " </b>");
            builder.Append("</font>");
            builder.Append("<br>");
            builder.Append("<b><font color=blue>Concerns:   " + lblModel.Text + "-" + lblProcess.Text + "-" + lblSeries.Text + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=red>Remarks:   " + tbRemarksFinal.Text + " </b>");
            builder.Append("<br>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>This is a System Generated Mail, Do not reply!</b><br>");
            builder.Append("<h2><br>Thank you!</h2>").AppendLine();
            innerString = builder.ToString();
        }
    


            private void btnSave_Click(object sender, EventArgs e)
                                                 {
            CompPanel.Visible = true;
            panel2.Visible = false;
        }

        private void btnSaveAudit_Click(object sender, EventArgs e)
        {

            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);

            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            if (LOGIN.LoginSection == "QA")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    cmd = new SqlCommand("update tbl_AuditApproval set Second_DateApproved = @date, Second_Status = @Secondstat, RemarksApproval2 = @remapp2, Third_Approver = @thirdapprover, TimeStamp2 = @timestamp2 where AuditID = '" + lblAuditID.Text + "'", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@date", date1);
                    cmd.Parameters.AddWithValue("@Secondstat", "Done");
                    cmd.Parameters.AddWithValue("@remapp2", tbRemarksFinal.Text);
                    cmd.Parameters.AddWithValue("@thirdapprover", cmbChecker.Text);
                    cmd.Parameters.AddWithValue("@timestamp2", timeString);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    audit_email2();

                    Pending_Approval2._instance.refreshdata();
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do Nothing
                }
            }
            else
            {
                DialogResult dialogResult1 = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult1 == DialogResult.Yes)
                {
                    cmd = new SqlCommand("update tbl_AuditApproval set Second_DateApproved = @date1, Third_DateApproved = @date2, Second_Status = @Secondstat, Third_Status = @thirdstat, Status = @stat, RemarksApproval2 = @remapp2, RemarksApproval3 = @remapp3, Third_Approver = @thirdapprover, TimeStamp2 = @timestamp2, TimeStamp3 = @timestamp3 where AuditID = '" + lblAuditID.Text + "'", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@date2", "N/A");
                    cmd.Parameters.AddWithValue("@date1", date1);
                    cmd.Parameters.AddWithValue("@secondstat", "Done");
                    cmd.Parameters.AddWithValue("@thirdstat", "Done");
                    cmd.Parameters.AddWithValue("@stat", "Done");
                    cmd.Parameters.AddWithValue("@remapp3", "N/A");
                    cmd.Parameters.AddWithValue("@remapp2", tbRemarksFinal.Text);
                    cmd.Parameters.AddWithValue("@thirdapprover", "N/A");
                    cmd.Parameters.AddWithValue("@timestamp2", timeString);
                    cmd.Parameters.AddWithValue("@timestamp3", "N/A");
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Pending_Approval2._instance.refreshdata();
                    this.Close();

                }
                else if (dialogResult1 == DialogResult.No)
                {
                    //do Nothing
                }
            }
            }
           
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CompPanel.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.Location = new Point(281, 155);
            CompPanel.Visible = false;
        }
        public void audit_email3()
        {
            using (SqlConnection conn = new SqlConnection(BBB))
            {
                string sql = "select Email from tbl_PSuser where Authority in ('Auditor','Engineer', 'Supervisor', 'Manager') AND Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    emailto = dr["Email"].ToString();
                    EmailBody_Audit3();
                    EmailNotif_Audit3();
                }
            }
        }
        private void EmailNotif_Audit3()
        {
            MailMessage mail = new MailMessage("digitalauditadmin@brother-biph.com.ph", emailto);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.UseDefaultCredentials = false;
            client.Host = "10.113.10.1";
            mail.Subject = "DIGITAL AUDIT ADMIN NOTIFICATION";
            mail.Body = innerString;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
        public void EmailBody_Audit3()
        {
            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.Append("<h1><font color=Red>AUDIT HAS BEEN DISAPPROVED</h1>");
            builder.Append("<br>");
            builder.Append("<b><h2><font color=black>Good Day!</h2></b><br></font>");
            builder.Append("<b><font color=Black>Please view issued <a href='\\\\apbiphsh07\\D0_ShareBrotherGroup\\19_BPS\\Installer\\PSAudit\\setup.exe'> DIGITAL AUDIT </a> today");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Supervisor:   " + LOGIN.loginName + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Auditor:   " + lblAuditor.Text + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Shift:   " + lblShift.Text + "</b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Line Name:   " + lblLine.Text + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Date:   " + date1 + " " + timeString + " </b>");
            builder.Append("</font>");
            builder.Append("<br>");
            builder.Append("<b><font color=blue>Concerns:   " + lblModel.Text + "-" + lblProcess.Text + "-" + lblSeries.Text + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=red>Remarks:   " + txtDisRem.Text + " </b>");
            builder.Append("<br>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>This is a System Generated Mail, Do not reply!</b><br>");
            builder.Append("<h2><br>Thank you!</h2>").AppendLine();
            innerString = builder.ToString();
        }
        private void jeButton1_Click(object sender, EventArgs e)
        {
            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);

            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("update tbl_AuditApproval set Second_DateApproved = @date, Second_Status = @secondstat, Second_Approver = @secapp, DisapprovedRemarks=@remapp,TimeStamp2 = @timestamp2, Status=@stat, RejectedBy = @rejby where AuditID = '" + lblAuditID.Text + "'", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@date", date1);
                cmd.Parameters.AddWithValue("@secondstat", "Rejected");
                cmd.Parameters.AddWithValue("@remapp", txtDisRem.Text);
                cmd.Parameters.AddWithValue("@timestamp2", timeString);
                cmd.Parameters.AddWithValue("@stat", "Rejected");
                cmd.Parameters.AddWithValue("@secapp", LOGIN.loginName);
                cmd.Parameters.AddWithValue("@rejby", LOGIN.loginName);
                cmd.ExecuteNonQuery();
                con.Close();
                audit_email3();

                Pending_Approval2._instance.refreshdata();

                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

