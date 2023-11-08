﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_Digital_Audit
{
    public partial class _6thAudit : Form
    {
        static string BBB = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;
        int ID = 0;
        public string audit_num;

        public string Username_temp;
        public string Name_temp;
        public string Authority_temp;
        public string Line_temp;
        public string Shift_temp;
        private string innerString;

        public string temporary;
        public string emailto;

        public static string imagenamenya;
        public static string AuditIDNya;
        public static string itemidnya;
        public static string time_occurnya;
        public static string imagepathnya;
        public static string ADID;
        public static string NG;

        public static string firstIn;
        public static string firstOut;
        public static string secIn;
        public static string secOut;
        public static string AuditID;
        string aaron;
        public bool RR;
        public _6thAudit()
        {
            InitializeComponent();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select ID, ChecksheetNo, AssuranceItem, Classification, CheckItems,  Status1, Remarks1, TypeNG1, NGDetails1, [1stAudit], [2ndAudit], [3rdAudit], [4thAudit], [5thAudit], [6thAudit], [7thAudit] from Temp_MasterAudit where AuditID= '" + lblAuditID.Text + "' AND Process = '" + lblProcess.Text + "' order by ID asc", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["ChecksheetNo"].Visible = false;
            dataGridView1.Columns["Remarks1"].Visible = false;
            dataGridView1.Columns["TypeNG1"].Visible = false;
            dataGridView1.Columns["NGDetails1"].Visible = false;
            dataGridView1.Columns["Status1"].Visible = false;
            dataGridView1.Columns["1stAudit"].Visible = false;
            dataGridView1.Columns["2ndAudit"].Visible = false;
            dataGridView1.Columns["3rdAudit"].Visible = false;
            dataGridView1.Columns["4thAudit"].Visible = false;
            dataGridView1.Columns["5thAudit"].Visible = false;
            dataGridView1.Columns["6thAudit"].Visible = false;
            dataGridView1.Columns["7thAudit"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToOrderColumns = true;

            this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 14);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowTemplate.MinimumHeight = 400;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;

            dataGridView1.Columns[2].HeaderText = "ASSURANCE ITEM";
            dataGridView1.Columns[3].HeaderText = "DESIGN REQUIREMENTS";
            dataGridView1.Columns[4].HeaderText = "INSPECTION METHOD";
        }
        public void TypeNG()
        {
            using (SqlConnection conn = new SqlConnection(BBB))
            {
                conn.Open();
                string sql = "select TypeofNG from tbl_TypeofNG where Section = '" + LOGIN.LoginSection + "' AND ChecksheetName = '" + Monitoring._instance.typeofAudit + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "TypeofNG");
                cmbNG.DisplayMember = "TypeofNG";
                cmbNG.ValueMember = "TypeofNG";
                cmbNG.DataSource = dt.Tables["TypeofNG"];

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NG = cmbNG.Text;
                    conn.Close();
                }
            }
        }
        string ChecksheetNumber_update = string.Empty;
        string Line_update = string.Empty;
        string typeofAudit_update = string.Empty;
        string Model_update = string.Empty;
        string dateAudit_update = string.Empty;
        string firststart_update = string.Empty;
        string firstend_update = string.Empty;
        string status_update = string.Empty;
        string comment_update = string.Empty;
        string remarks_update = string.Empty;
        string process_update = string.Empty;

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Left:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void _6thAudit_Load(object sender, EventArgs e)
        {
            lblTypeAudit.Text = Monitoring._instance.typeofAudit;
            TypeNG();
            InputBy();
            dataGridView1.RowTemplate.MinimumHeight = 500;
            if (lblWhat.Text == "UPDATE") // >>>> to continue
            {
                if (WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;

                lblAuditID.Text = Monitoring._instance.MySelectedAuditID;
                textBox9.Text = Monitoring._instance.ChecksheetNumber;
                lblLine.Text = Monitoring._instance.Line;
                typeofAudit_update = Monitoring._instance.typeofAudit;
                lblShift.Text = Monitoring._instance.shift;
                lblTypeAudit.Text = Monitoring._instance.typeofAudit;
                lblSeries.Text = Monitoring._instance.Model;
                dateAudit_update = Monitoring._instance.dateAudit;
                lblProcess.Text = Monitoring._instance.process;
                lblFirstStart.Text = Monitoring._instance.firststart;
                lblFirstEnd.Text = Monitoring._instance.firstend;
                txtStatus.Text = Monitoring._instance.status;
                txtComment.Text = Monitoring._instance.comment;
                tbRemarks.Text = Monitoring._instance.remarks;

            }
            else
            {
                lblAuditID.Text = PSCategory.AuditID;
                lblSeries.Text = PSCategory.series;
                lblLine.Text = PSCategory.line;
                lblShift.Text = PSCategory.shift;
                lblProcess.Text = PSCategory.process;


            }
            DisplayData();
            num_items();
            lblChecksheetCountTotal.Text = dataGridView1.RowCount.ToString();
            TotalItems.Text = dataGridView1.RowCount.ToString();
            TotalItemsTo.Text = dataGridView1.RowCount.ToString();
            lblStartFinal.Text = dataGridView1.RowCount.ToString();
            lblEndFinal.Text = dataGridView1.RowCount.ToString();
            cmbNG.Text = Engine_Assembly.NG;

            // panel2.Location = new Point(351, 85);
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[2];
        }
        private void num_items()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select [6thAudit] as one_start,[6thEnd] as one_end,status6 from Temp_MasterAudit where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND Process = '" + lblProcess.Text + "' AND ChecksheetNo = '" + lblCount.Text + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string first_audit;
                string second_audit;
                string audit_status;
                first_audit = reader[0].ToString();
                second_audit = reader[1].ToString();
                audit_status = reader[2].ToString();
                lblFirstStart.Text = first_audit;
                lblFirstEnd.Text = second_audit;
                txtStatus.Text = audit_status;
            }
            con.Close();
        }
        private void remarks_comments()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select remarks6,comment6 from Temp_MasterAudit where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND Process = '" + lblProcess.Text + "' AND ChecksheetNo = '" + textBox7.Text + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string comment2;
                string remarks2;
                comment2 = reader["Comment6"].ToString();
                remarks2 = reader["Remarks6"].ToString();
                txtComment.Text = comment2;
                tbRemarks.Text = remarks2;
            }
            con.Close();
        }
        public void audit_email()
        {
            using (SqlConnection conn = new SqlConnection(BBB))
            {
                string sql = "select Email from tbl_PSuser where Authority in ('Auditor','Engineer', 'Supervisor', 'Manager', 'AdminENG', 'AdminSPV', 'AdminMGR')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    emailto = dr["Email"].ToString();
                    EmailBody_Audit();
                    EmailNotif_Audit();
                }
            }
        }
        private void EmailNotif_Audit()
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
        public void EmailBody_Audit()
        {
            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.Append("<h1><font color=red>AN AUDIT HAS BEEN FOUND</h1>");
            builder.Append("<br>");
            builder.Append("<b><h2><font color=black>PLEASE TAKE ACTION IMMEDIATELY!</h2></b><br></font>");
            builder.Append("<b><font color=red>Audit ID:   " + lblAuditID.Text + "</b>");
            builder.Append("<br>");
            builder.Append("<b><font color=blue>Audit Activity:   " + lblTypeAudit.Text + "</b>");
            builder.Append("<br>");
            builder.Append("<b><font color=red>Type of NG:   " + cmbNG.Text + "</b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Line Name:   " + Monitoring._instance.line + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Area/Process:   " + Monitoring._instance.process + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Shift:   " + Monitoring._instance.shift + "</b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Model Series:   " + Monitoring._instance.Model + "</b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Audited By:   " + LOGIN.loginName + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Audited Date:   " + date1 + " </b>");
            builder.Append("</font>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Audit Link Reference:  <a href='\\\\apbiphsh07\\D0_ShareBrotherGroup\\19_BPS\\Installer\\PSAudit\\setup.exe'> DIGITAL AUDIT </a>");
            builder.Append("<br>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>This is a System Generated Mail, Do not reply!</b><br>");
            builder.Append("<h2><br>Thank you!</h2>").AppendLine();
            innerString = builder.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        private void MakeOnlyCurrentRowVisible()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.CurrentRow != dataGridView1.Rows[i])
                    dataGridView1.Rows[i].Visible = false;
            }
        }
        private void Engine_Assembly_VisibleChanged(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
            MakeOnlyCurrentRowVisible();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!dataGridView1.AllowUserToAddRows)
            {
                MakeOnlyCurrentRowVisible();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "OK";
            //btnNA.Enabled = false;
            //btnNG.Enabled = false;
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            try
            {
                if (txtStatus.Text != "" && lblFirstStart.Text != "" && lblFirstEnd.Text != "")
                {
                    if (textBox9.Text == "")
                    {
                        next_data();
                    }
                    else
                    {
                        DateTime aa = DateTime.Now;
                    string date1 = aa.ToString("MM/dd/yyyy");
                    string cnt = Convert.ToString(date1);

                    cmd = new SqlCommand("update Temp_MasterAudit set Status6=@status6, Remarks6=@remarks6, Comment6=@comment6, [6thAudit]=@6thaudit, [6thEnd]=@6thend, Date=@date, Flag6=@flag6 where TypeofAudit = '" + lblTypeAudit.Text + "' AND AuditID= '" + Monitoring._instance.MySelectedAuditID + "' AND ChecksheetNo= '" + lblCount.Text + "' AND Process= '" + lblProcess.Text + "'", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@status6", txtStatus.Text);
                    cmd.Parameters.AddWithValue("@remarks6", tbRemarks.Text);
                    cmd.Parameters.AddWithValue("@comment6", txtComment.Text);
                    cmd.Parameters.AddWithValue("@date", date1);
                    cmd.Parameters.AddWithValue("@6thaudit", lblFirstStart.Text);
                    cmd.Parameters.AddWithValue("@6thend", lblFirstEnd.Text);
                    cmd.Parameters.AddWithValue("@flag6", "Closed");
                    cmd.ExecuteNonQuery();
                    con.Close();

                    next_data();
                    textBox9.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Please Complete the needed details!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("PLEASE TAP THE TABLE BEFORE STARTING THE AUDIT!!" + ex);
            }
        }
        private void next_data()
        {
            int check_count = Int32.Parse(lblCount.Text) + 1;
            textBox7.Text = check_count.ToString();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(ID) FROM Temp_MasterAudit where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND Process = '" + lblProcess.Text + "' AND ChecksheetNo = '" + textBox7.Text + "' AND status6!=''", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows[0][0].ToString() == "1")
            {
                //disregard lang ang next
                btnNA.Enabled = false;
                btnOK.Enabled = false;
                btnNG.Enabled = false;
                int next = this.dataGridView1.CurrentRow.Index + 1;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[next].Cells[this.dataGridView1.CurrentCell.ColumnIndex];
                num_items();
                remarks_comments();
            }
            else
            {
                lblFirstStart.Text = "";
                lblFirstEnd.Text = "";
                btnNA.Enabled = false;
                btnOK.Enabled = false;
                btnNG.Enabled = false;
                txtStatus.Text = "";
                txtComment.Text = "";
                tbRemarks.Text = "";
                int next = this.dataGridView1.CurrentRow.Index + 1;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[next].Cells[this.dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                lblCount.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                this.picPrevious.Enabled = this.dataGridView1.CurrentRow.Index > 0;
                this.picNext.Enabled = this.dataGridView1.CurrentRow.Index < this.dataGridView1.Rows.Count - 1;
            }
        }

        private void picPrevious_Click(object sender, EventArgs e)
        {
            int prev = this.dataGridView1.CurrentRow.Index - 1;
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[prev].Cells[this.dataGridView1.CurrentCell.ColumnIndex];
            textBox7.Text = lblCount.Text;
            if (lblWhat.Text == "UPDATE")

            {

                num_items2(lblAuditID.Text);
            }

            else
            {

                textBox7.Text = lblCount.Text;
                num_items();
            }

            remarks_comments();
        }
        private void num_items2(string id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select [6thAudit] as one_start,[6thEnd] as one_end,status6 from Temp_MasterAudit where AuditID = '" + id + "' AND Process = '" + lblProcess.Text + "' AND ChecksheetNo = '" + lblCount.Text + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string first_audit;
                string second_audit;
                string audit_status;
                first_audit = reader[0].ToString();
                second_audit = reader[1].ToString();
                audit_status = reader[2].ToString();
                lblFirstStart.Text = first_audit;
                lblFirstEnd.Text = second_audit;
                txtStatus.Text = audit_status;
            }
            con.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            picNext.Enabled = true;
            picPrevious.Enabled = true;
            btnNA.Enabled = true;
            btnOK.Enabled = true;
            btnNG.Enabled = true;
            btnStart.Visible = false;
            btnEnd.Visible = true;
            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            lblFirstStart.Text = timeString.ToString();
            textBox9.Text = "start";
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);

            btnEnd.Visible = false;
            btnStart.Visible = true;
            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            lblFirstEnd.Text = timeString.ToString();


            cmd = new SqlCommand("update Temp_MasterAudit set Status6=@status6, Remarks6=@remarks6, Comment6=@comment6, [6thAudit]=@6thaudit, [6thEnd]=@6thend, Date=@date, Flag6=@flag6 where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND ChecksheetNo= '" + lblCount.Text + "' AND Process= '" + lblProcess.Text + "'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@status6", txtStatus.Text);
            cmd.Parameters.AddWithValue("@remarks6", tbRemarks.Text);
            cmd.Parameters.AddWithValue("@comment6", txtComment.Text);
            cmd.Parameters.AddWithValue("@date", date1);
            cmd.Parameters.AddWithValue("@6thaudit", lblFirstStart.Text);
            cmd.Parameters.AddWithValue("@6thend", lblFirstEnd.Text);
            cmd.Parameters.AddWithValue("@flag6", "Closed");

            cmd.ExecuteNonQuery();
            con.Close();

            aaron = "Select top 1 * From Temp_MasterAudit where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND Process='" + lblProcess.Text + "' AND Section = '" + LOGIN.LoginSection + "' order by ChecksheetNo asc";
            RR = CRUD.RETRIEVESINGLE(aaron);
            if (RR == true)
            {
                var withBlock = CRUD.dt.Rows[0];
                lblTStart.Text = CRUD.dt.Rows[0]["6thAudit"].ToString();
                //TotalItems.Text = CRUD.dt.Rows[0]["1stAudit"].ToString();
            }

            aaron = "Select top 1 * From Temp_MasterAudit where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND Process='" + lblProcess.Text + "' AND Section = '" + LOGIN.LoginSection + "' order by ChecksheetNo desc";
            RR = CRUD.RETRIEVESINGLE(aaron);
            if (RR == true)
            {
                var withBlock = CRUD.dt.Rows[0];
                lblTEnd.Text = CRUD.dt.Rows[0]["6thEnd"].ToString();
                //TotalItemsTo.Text = CRUD.dt.Rows[0]["6thEnd"].ToString();
            }

            if (lblCount.Text == lblChecksheetCountTotal.Text)
            {
                txtComment.Enabled = false;
                tbRemarks.Enabled = false;
                Panel1.Visible = true;
                picNext.Enabled = false;
                btnDoneAudit.Enabled = true;

                string select = "Select * from Temp_MasterAudit where Status6 = 'NG' AND TypeofAudit != 'PS Process Audit' AND AuditID = '" + Monitoring._instance.MySelectedAuditID + "'";
                bool result = CRUD.RETRIEVESINGLE(select);
                if (result != false)
                {
                    using (SqlConnection conn = new SqlConnection(BBB))
                    {
                        string sql = "select Email from tbl_PSuser where Authority in ('Auditor','Engineer', 'Supervisor', 'Manager', 'AdminENG', 'AdminSPV', 'AdminMGR') AND Section = '" + LOGIN.LoginSection + "'";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        CompPanel.Visible = true;

                        MessageBox.Show("Please wait. Email notification is processing!", "Digital Audit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (DataRow dr in dt.Rows)
                        {
                            emailto = dr["Email"].ToString();
                            EmailBody_Audit();
                            EmailNotif_Audit();
                        }
                    }
                }
            }
        }

        private void btnNG_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "NG";
            NGPanel.Visible = true;
            //btnOK.Enabled = false;
            //btnNA.Enabled = false;
        }

        public void insertImagePath(string imagename, string imagepath)
        {
        }

        private void btnNA_Click(object sender, EventArgs e)
        {
            //btnOK.Enabled = false;
            //btnNG.Enabled = false;
            txtStatus.Text = "N/A";
        }
        private void btnSaveAudit_Click(object sender, EventArgs e)
        {
            audit_email2();
            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);

            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            cmd = new SqlCommand("update Temp_MasterAudit set FinalRemarks= '" + tbRemarksFinal.Text + "' where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND Process= '" + lblProcess.Text + "'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.ExecuteNonQuery();
            con.Close();

            //APPROVAL
            cmd = new SqlCommand("INSERT INTO tbl_AuditApproval (AuditID, TypeofAudit, Auditor, Line, Series, Model, Process, Frequency, Shift, Assurance, Classification, CheckItems, Section, Date, Status, Status1, Status2, Status3, Status4, Status5, Status6, Status7, Remarks1, Remarks2, Remarks3, Remarks4, Remarks5, Remarks6, Remarks7, Comment1, Comment2, Comment3, Comment4, Comment5, Comment6, Comment7, TypeNG1, TypeNG2, TypeNG3, TypeNG4, TypeNG5, TypeNG6, TypeNG7, NGDetails1, NGDetails2, NGDetails3, NGDetails4, NGDetails5, NGDetails6, NGDetails7, [1stAudit], [1stEnd], [2ndAudit], [2ndEnd], [3rdAudit], [3rdEnd], [4thAudit], [4thEnd], [5thAudit], [5thEnd], [6thAudit], [6thEnd], [7thAudit], [7thEnd], First_Approver) Select AuditID, TypeofAudit, AuditedBy, Line,  Series, Model, Process,  Frequency, Shift, AssuranceItem, Classification, CheckItems, Section, @date, @status, Status1, Status2, Status3, Status4, Status5, Status6, Status7, Remarks1, Remarks2, Remarks3, Remarks4, Remarks5, Remarks6, Remarks7, Comment1, Comment2, Comment3, Comment4, Comment5, Comment6, Comment7, TypeNG1, TypeNG2, TypeNG3, TypeNG4, TypeNG5, TypeNG6, TypeNG7, NGDetails1, NGDetails2, NGDetails3, NGDetails4, NGDetails5, NGDetails6, NGDetails7, [1stAudit], [1stEnd], [2ndAudit], [2ndEnd], [3rdAudit], [3rdEnd], [4thAudit], [4thEnd], [5thAudit], [5thEnd], [6thAudit], [6thEnd], [7thAudit], [7thEnd], @1stapprover from Temp_MasterAudit where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND Process= '" + lblProcess.Text + "'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@1stapprover", cmbChecker.Text);
            cmd.Parameters.AddWithValue("@status", "Ongoing");
            cmd.Parameters.AddWithValue("@date", date1);
            cmd.ExecuteNonQuery();
            con.Close();


            Monitoring._instance.refreshdata();
            btnStart.Enabled = false;
            btnEnd.Enabled = false;
            btnOK.Enabled = false;
            btnNG.Enabled = false;
            btnNA.Enabled = false;
            CompPanel.Visible = false;

            
            this.Close();
        }

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
            builder.Append("<b><font color=Black>Auditor:   " + LOGIN.loginName + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Shift:   " + Monitoring._instance.shift + "</b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Line Name:   " + Monitoring._instance.line + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Date:   " + date1 + " " + timeString + " </b>");
            builder.Append("</font>");
            builder.Append("<br>");
            builder.Append("<b><font color=blue>Concerns:   " + Monitoring._instance.Model + "-" + Monitoring._instance.process + "-" + lblSeries.Text + " </b>");
            builder.Append("<br>");
            builder.Append("<b><font color=red>Remarks:   " + tbRemarksFinal.Text + " </b>");
            builder.Append("<br>");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>This is a System Generated Mail, Do not reply!</b><br>");
            builder.Append("<h2><br>Thank you!</h2>").AppendLine();
            innerString = builder.ToString();
        }
        public void InputBy()
        {
            using (SqlConnection conn = new SqlConnection(BBB))
            {
                conn.Open();
                string sql = "select Name from tbl_PSuser where Authority = 'Engineer' AND Section = '" + LOGIN.LoginSection + "'";
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

        private void btnDoneAudit_Click(object sender, EventArgs e)
        {
            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    cmd = new SqlCommand("update Temp_MasterAudit set  Status7=@status7, Remarks7=@remarks7, Comment7=@comment7, TypeNG7=@typeng7, NGDetails7=@ngdetails7, Date=@date, [7thAudit]=@7audit, [7thEnd]=@7end, Flag7=@flag7 where AuditID = '" + Monitoring._instance.MySelectedAuditID + "'", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@status7", "N/A");
                    cmd.Parameters.AddWithValue("@remarks7", "N/A");
                    cmd.Parameters.AddWithValue("@comment7", "N/A");
                    cmd.Parameters.AddWithValue("@typeng7", "N/A");
                    cmd.Parameters.AddWithValue("@ngdetails7", "N/A");
                    cmd.Parameters.AddWithValue("@date", date1);
                    cmd.Parameters.AddWithValue("@7audit", "N/A");
                    cmd.Parameters.AddWithValue("@7end", "N/A");
                    cmd.Parameters.AddWithValue("@flag7", "Closed");

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Audit ID in all Frequency has been DONE!", "AUDIT DONE!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CompPanel.Visible = Enabled;
                    aaron = "Select top 1 * From Temp_MasterAudit where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND Process='" + lblProcess.Text + "' AND Section = '" + LOGIN.LoginSection + "' order by ChecksheetNo asc";
                    RR = CRUD.RETRIEVESINGLE(aaron);
                    if (RR == true)
                    {
                        var withBlock = CRUD.dt.Rows[0];
                        TotalTime.Text = CRUD.dt.Rows[0]["1stAudit"].ToString();
                    }

                    aaron = "Select top 1 * From Temp_MasterAudit where AuditID = '" + Monitoring._instance.MySelectedAuditID + "' AND Process='" + lblProcess.Text + "' AND Section = '" + LOGIN.LoginSection + "' order by ChecksheetNo desc";
                    RR = CRUD.RETRIEVESINGLE(aaron);
                    if (RR == true)
                    {
                        var withBlock = CRUD.dt.Rows[0];
                        TotalTimeTo.Text = CRUD.dt.Rows[0]["6thEnd"].ToString();

                    }
                }
                catch (Exception ex)
                {
                }
                btnDoneAudit.Enabled = false;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do Nothing
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AuditLookUp lookup = new AuditLookUp();
            lookup.txtAssurance.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lookup.txtClassification.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            lookup.txtCheckItems.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            lookup.ShowDialog();
        }

        private void jeButton6_Click(object sender, EventArgs e)
        {
            if (Monitoring._instance.typeofAudit != "PS Process Audit")
            {
                MessageBox.Show("NG Saved.. Open the CAMERA!", "Notification");
            }
            if (Monitoring._instance.typeofAudit == "PS Process Audit" && LOGIN.LoginSection == "QA" && LOGIN.LoginSection == "QI" && LOGIN.LoginSection == "Printer")
            {
                MessageBox.Show("Saving and Sending Email Notif!... PLEASE WAIT...", "Notification");
                audit_email();
            }
            //NO GOOD
            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);

            cmd = new SqlCommand("update Temp_MasterAudit set TypeNG6= '" + cmbNG.Text + "', NGDetails6=@ngdetails6 where AuditID = '" + Monitoring._instance.MySelectedAuditID + "'  AND ChecksheetNo= '" + lblCount.Text + "' AND Process= '" + lblProcess.Text + "'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@ngdetails6", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            NG = cmbNG.Text;

            textBox6.Text = "";

            //PICTURES
            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            cmd = new SqlCommand("INSERT INTO tbl_UserPicDetails (AuditID, ChecksheetNo, Date, TimeOccur, UserImagename, UserImagePath, IDNo, Name, Section) Select AuditID, ChecksheetNo, @Date, @time, @imagename, @path, IDNo, AuditedBy, Section from Temp_MasterAudit where CheckSheetNo = '" + lblCount.Text + "' AND AuditID = '" + Monitoring._instance.MySelectedAuditID + "'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@Date", date1);
            cmd.Parameters.AddWithValue("@imagename", PSCategory.AuditID.ToString() + ".jpeg");
            cmd.Parameters.AddWithValue("@time", timeString.ToString());
            cmd.Parameters.AddWithValue("@path", @"\\apbiphsh07\D0_ShareBrotherGroup\19_BPS\Installer\PSAudit\CapturedImage\" + LOGIN.LoginSection + "\\" + LOGIN.loginuser + "\\" + Monitoring._instance.MySelectedAuditID + "\\" + Monitoring._instance.MySelectedAuditID + "-" + lblCount.Text + ".jpeg");
            cmd.ExecuteNonQuery();
            con.Close();


            //PROBLEM SUMMARY
            cmd = new SqlCommand("INSERT INTO tbl_ProblemSummary (AuditID, ChecksheetNo, Frequency, Auditor, Line, Series, Model, Process, Section, DateEncountered, TypeOfNG, NGDetails, Picture, Status, Status2, TypeofAudit) Select AuditID, ChecksheetNo, @freq, AuditedBy, Line, Series, Model, Process, Section, @Date, TypeNG6, NGDetails6, @path, @status, @status2, TypeOfAudit from Temp_MasterAudit where CheckSheetNo = '" + lblCount.Text + "' AND AuditID = '" + Monitoring._instance.MySelectedAuditID + "'", con);
            con.Open();
            cmd.Parameters.AddWithValue("@Date", date1);
            cmd.Parameters.AddWithValue("@freq", "6th");
            cmd.Parameters.AddWithValue("@status", "OPEN");
            cmd.Parameters.AddWithValue("@status2", "OPEN");
            cmd.Parameters.AddWithValue("@path", @"\\apbiphsh07\D0_ShareBrotherGroup\19_BPS\Installer\PSAudit\CapturedImage\" + LOGIN.LoginSection + "\\" + LOGIN.loginuser + "\\" + Monitoring._instance.MySelectedAuditID + "\\" + Monitoring._instance.MySelectedAuditID + "-" + lblCount.Text + ".jpeg");
            cmd.ExecuteNonQuery();
            con.Close();

            string dir = @"\\apbiphsh07\D0_ShareBrotherGroup\19_BPS\Installer\PSAudit\CapturedImage\" + LOGIN.LoginSection + "\\" + LOGIN.loginuser + "\\" + Monitoring._instance.MySelectedAuditID;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);

                // jeButton3.Enabled = true;
                //jeButton6.Enabled = false;
                textBox6.Text = "";
                //cmbNG.Enabled = false;
            }
        }

        private void jeButton3_Click(object sender, EventArgs e)
        {

            DateTime nm = DateTime.Now;
            string date = nm.ToString("yyyyMMddHHmmss");
            insertImagePath(date + ".jpeg", @"\\apbiphsh07\D0_ShareBrotherGroup\19_BPS\Installer\PSAudit\CapturedImage\" + LOGIN.LoginSection + "\\" + LOGIN.loginuser + "\\" + Monitoring._instance.MySelectedAuditID + "\\" + Monitoring._instance.MySelectedAuditID + "-" + lblCount.Text + ".jpeg");
            var uri = @"C:\CAMERA-QAPS\Main_Form_Camera.exe";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = uri;
            System.Diagnostics.Process.Start(psi);

            NGPanel.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NGPanel.Visible = false;
        }

        private void jeButton5_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnEnd.Enabled = false;
            btnOK.Enabled = false;
            btnNG.Enabled = false;
            btnNA.Enabled = false;
            Panel1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void jeButton7_Click(object sender, EventArgs e)
        {
            //panel2.Visible = false;
        }
    }
}

