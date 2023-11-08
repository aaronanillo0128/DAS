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
using System.Reflection;

namespace PS_Digital_Audit
{
    public partial class PSCategory : Form
    {
        public static PSCategory _instance;
        public static string line = "";
        public static string series = "";
        public static string shift = "";
        public static string process = "";
        public static string freq = "";
        public static string model = "";
        public static string inline = "";
        public static string AuditID = "";
        public static string typeaudit = "";
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        string cs = "Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd";
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;
        public string Model;
        public string Shift;


        int ID = 0;
        public PSCategory()
        {
            InitializeComponent();
            _instance = this;
        }

        private void jeButton5_Click(object sender, EventArgs e)
        {

            series = txtSeries.Text;
            shift = cmbShift1.Text;
            line = cmbLine.Text;
            process = cmbProcess.Text;
            freq = cmbFreq.Text;
            model = cmbModel.Text;
            typeaudit = lblTypeofAudit.Text;


            if (cmbLine.Text != "" && cmbModel.Text != "" && cmbProcess.Text != "" && cmbShift1.Text != "" && cmbFreq.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //Do Something
                    DateTime nm = DateTime.Now;
                    string date = nm.ToString("yyyyMMddHHmmss");
                    string date2 = nm.ToString("MM/dd/yyyy");
                    string cnt = Convert.ToString(date);
                    lblAuditID.Text = (txtSeries.Text + "-" + cmbShift1.Text + "-" + cnt).Replace(" ", "");
                    AuditID = lblAuditID.Text;
                    cmd = new SqlCommand("update tbl_MasterAudit set AuditID=@auditid, Line=@line, AuditedBy=@auditby, IDNo=@idno, Frequency=@freq, Shift=@shift, Flag1=@flag1, Flag2=@flag2, Flag3=@flag3, Flag4=@flag4, Flag5=@flag5, Flag6=@flag6, Flag7=@flag7 where Series = '" + txtSeries.Text + "' AND Model = '" + cmbModel.Text + "' AND Process= '" + cmbProcess.Text + "' AND TypeofAudit = '" + lblTypeofAudit.Text + "' AND Section = '" + LOGIN.LoginSection + "'", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@line", cmbLine.Text);
                    cmd.Parameters.AddWithValue("@auditid", lblAuditID.Text);
                    cmd.Parameters.AddWithValue("@auditby", lbl_Name.Text);
                    cmd.Parameters.AddWithValue("@freq", cmbFreq.Text);
                    cmd.Parameters.AddWithValue("@shift", cmbShift1.Text);
                    cmd.Parameters.AddWithValue("@idno", lbl_IDNum.Text);
                    cmd.Parameters.AddWithValue("@flag1", "Open");
                    cmd.Parameters.AddWithValue("@flag2", "Open");
                    cmd.Parameters.AddWithValue("@flag3", "Open");
                    cmd.Parameters.AddWithValue("@flag4", "Open");
                    cmd.Parameters.AddWithValue("@flag5", "Open");
                    cmd.Parameters.AddWithValue("@flag6", "Open");
                    cmd.Parameters.AddWithValue("@flag7", "Open");
                    cmd.ExecuteNonQuery();
                    con.Close();

                    cmd = new SqlCommand("INSERT INTO Temp_MasterAudit (CheckSheetNo, AuditID, Line,AuditedBy,IDNo,Version,TypeofAudit,Model,Series,Process,Frequency,Shift,AssuranceItem,Classification,CheckItems,Section,Status1,Status2,Status3,Status4,Status5,Status6,Status7,Remarks1,Remarks2,Remarks3,Remarks4,Remarks5,Remarks6,Remarks7,Comment1,Comment2,Comment3,Comment4,Comment5,Comment6,Comment7,TypeNG1,TypeNG2,TypeNG3,TypeNG4,TypeNG5,TypeNG6,TypeNG7,NGDetails1,NGDetails2,NGDetails3,NGDetails4,NGDetails5,NGDetails6,NGDetails7,Date,[1stAudit],[1stEnd],[2ndAudit],[2ndEnd],[3rdAudit],[3rdEnd],[4thAudit],[4thEnd],[5thAudit],[5thEnd],[6thAudit],[6thEnd],[7thAudit],[7thEnd],FinalRemarks,Flag1,Flag2,Flag3,Flag4,Flag5,Flag6,Flag7) Select CheckSheetNo,AuditID,Line,AuditedBy,IDNo,Version,TypeofAudit,Model,Series,Process,Frequency,Shift,AssuranceItem,Classification,CheckItems,Section,Status1,Status2,Status3,Status4,Status5,Status6,Status7,Remarks1,Remarks2,Remarks3,Remarks4,Remarks5,Remarks6,Remarks7,Comment1,Comment2,Comment3,Comment4,Comment5,Comment6,Comment7,TypeNG1,TypeNG2,TypeNG3,TypeNG4,TypeNG5,TypeNG6,TypeNG7,NGDetails1,NGDetails2,NGDetails3,NGDetails4,NGDetails5,NGDetails6,NGDetails7,@date,[1stAudit],[1stEnd],[2ndAudit],[2ndEnd],[3rdAudit],[3rdEnd],[4thAudit],[4thEnd],[5thAudit],[5thEnd],[6thAudit],[6thEnd],[7thAudit],[7thEnd],FinalRemarks,Flag1,Flag2,Flag3,Flag4,Flag5,Flag6,Flag7 from tbl_MasterAudit where AuditID= '" + lblAuditID.Text + "'", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@date", date2);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    cmd = new SqlCommand("update tbl_MasterAudit set AuditID=@auditid, Line=@line, AuditedBy=@auditby, IDNo=@idno, Frequency=@freq, Shift=@shift, Flag1=@flag1 where Model = '" + cmbModel.Text + "' AND Process= '" + cmbProcess.Text + "' AND Section = '" + LOGIN.LoginSection + "'", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@line", "");
                    cmd.Parameters.AddWithValue("@auditid", "");
                    cmd.Parameters.AddWithValue("@auditby", "");
                    cmd.Parameters.AddWithValue("@freq", "");
                    cmd.Parameters.AddWithValue("@shift", "");
                    cmd.Parameters.AddWithValue("@idno", "");
                    cmd.Parameters.AddWithValue("@flag1", "");
                    cmd.Parameters.AddWithValue("@flag2", "");
                    cmd.Parameters.AddWithValue("@flag3", "");
                    cmd.Parameters.AddWithValue("@flag4", "");
                    cmd.Parameters.AddWithValue("@flag5", "");
                    cmd.Parameters.AddWithValue("@flag6", "");
                    cmd.Parameters.AddWithValue("@flag7", "");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Audit_Checksheet aaa = new Audit_Checksheet();
                    aaa.Show();
                    this.Hide();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do Nothing
                }

            }
            else
                MessageBox.Show("Please Complete the Details needed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Line()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select Line from tbl_Line where Section = '"+ LOGIN.LoginSection +"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtqq = new DataTable();
                sda.Fill(dtqq);
                cmbLine.Items.Clear();
                cmbLine.Items.Add("");
                cmbLine.SelectedIndex = 0;
                for (int i = 0; i < dtqq.Rows.Count; i++)
                {
                    cmbLine.Items.Add(dtqq.Rows[i]["Line"]);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    line = cmbLine.Text;
                    conn.Close();
                }
            }
        }

        public void Shift1()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select ShiftCode from tbl_Shift";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "ShiftCode");
                cmbShift1.DisplayMember = "ShiftCode";
                cmbShift1.ValueMember = "ShiftCode";
                cmbShift1.DataSource = dt.Tables["ShiftCode"];

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    shift = cmbShift1.Text;
                    conn.Close();
                }
            }
        }

        public void Process()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select Distinct Process from tbl_MasterAudit where TypeofAudit = '" + lblTypeofAudit.Text + "' AND Series = '" + txtSeries.Text + "' AND Section = '" + lblSection.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                DataTable dtqq = new DataTable();
                sda.Fill(dtqq);
                cmbProcess.Items.Clear();
                cmbProcess.Items.Add("");
                cmbProcess.SelectedIndex = 0;
                for (int i = 0; i < dtqq.Rows.Count; i++)
                {
                    cmbProcess.Items.Add(dtqq.Rows[i]["Process"]);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    process = cmbProcess.Text;
                    conn.Close();
                }
            }
        }
        public void Frequency()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select Frequency from tbl_Frequency where Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "Frequency");
                cmbFreq.DisplayMember = "Frequency";
                cmbFreq.ValueMember = "Frequency";
                cmbFreq.DataSource = dt.Tables["Frequency"];

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    freq = cmbFreq.Text;
                    conn.Close();
                }
            }
        }
        public void Model1()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select Distinct Model from tbl_MasterAudit where TypeofAudit = '" + lblTypeofAudit.Text + "' AND Series = '" + txtSeries.Text + "' AND Process = '" + cmbProcess.Text + "' AND Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "Model");
                cmbModel.DisplayMember = "Model";
                cmbModel.ValueMember = "Model";
                cmbModel.DataSource = dt.Tables["Model"];


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    model = cmbModel.Text;
                    conn.Close();
                }
            }
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

        private void jeButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN aaa = new LOGIN();
            aaa.ShowDialog();
            this.Close();
        }

        private void jeButton6_Click(object sender, EventArgs e)
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
            else if (lblSection.Text == "QA INK")
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
        }

    
        static string PSAudit = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        private void PSCategory_Load(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

            if (LOGIN.LoginSection == "QA")
            {
                lblTypeofAudit.Text = Section_Checksheet.inline;
            }
          else if(LOGIN.LoginSection == "P-TOUCH")
            {
                lblTypeofAudit.Text = PT_Audit.inline;
            }
            else if (LOGIN.LoginSection == "DE")
            {
                lblTypeofAudit.Text = DE_Audit.inline;
            }
            else if (LOGIN.LoginSection == "Printer")
            {
                lblTypeofAudit.Text = PRT_Audit.inline;
            }
            else if (LOGIN.LoginSection == "INK HEAD")
            {
                lblTypeofAudit.Text = IH_Audit.inline;
            }
            else if (LOGIN.LoginSection == "PCBA")
            {
                lblTypeofAudit.Text = PCBA_Audit.inline;
            }
            else if (LOGIN.LoginSection == "INK CARTRIDGE")
            {
                lblTypeofAudit.Text = IC_Audit.inline;
            }
            else if (LOGIN.LoginSection == "TAPE CASSETTE")
            {
                lblTypeofAudit.Text = TC_Audit.inline;
            }
            else if (LOGIN.LoginSection == "TOOLING ENGINEERING")
            {
                lblTypeofAudit.Text = Mold_Audit.inline;
            }
            else if (LOGIN.LoginSection == "SQC")
            {
                lblTypeofAudit.Text = SQC_Audit.inline;
            }

            else if (LOGIN.LoginSection == "QA PRINTER")
            {
                lblTypeofAudit.Text = Section_Checksheet.inline;
            }
            else if (LOGIN.LoginSection == "QA TAPE")
            {
                lblTypeofAudit.Text = Section_Checksheet.inline;
            }
            else if (LOGIN.LoginSection == "QA INK")
            {
                lblTypeofAudit.Text = Section_Checksheet.inline;
            }
            else if (LOGIN.LoginSection == "QA PTOUCH")
            {
                lblTypeofAudit.Text = Section_Checksheet.inline;
            }

            database.Text = PSAudit.Replace("Persist Security Info=True;User ID=saa;Password=P@ssw0rd", "");
            database.Text = database.Text.Replace("Data Source=", "  Server Name: ");
            database.Text = database.Text.Replace(";Initial Catalog=", "    Database: ");
            version.Text = "AA." + Assembly.GetExecutingAssembly().GetName().Version.ToString();
       
            Shift1();
            Line();
            Process();
            Frequency();
            //Model1();

            if (LOGIN.loginuser != null)
            {
                lblIDNum.Text = LOGIN.loginuser;
                lbl_IDNum.Text = LOGIN.loginuser;
                lbl_Name.Text = LOGIN.loginName;
                lbl_Autho.Text = LOGIN.loginAutho;
                lblSection.Text = LOGIN.LoginSection;
            }
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

        private void PSCategory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
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

        private void Go_Click(object sender, EventArgs e)
        {
            con.Open();
            string sqlsss = "Select * from tbl_Line where Line = '" + cmbLine.Text + "'";
            SqlCommand cmdsss = new SqlCommand(sqlsss, con);
            SqlDataReader sdrsss = cmdsss.ExecuteReader();
            sdrsss.Read();
            if (sdrsss.HasRows)
            {
                txtSeries.Text = sdrsss["Series"].ToString();
            }

            con.Close();
        }

        private void cmbLine_TextChanged(object sender, EventArgs e)
        {
            
            con.Open();
            string sqlsss = "Select * from tbl_Line where Line = '" + cmbLine.Text + "' AND Section = '" + LOGIN.LoginSection + "'";
            SqlCommand cmdsss = new SqlCommand(sqlsss, con);
            SqlDataReader sdrsss = cmdsss.ExecuteReader();
            sdrsss.Read();
            if (sdrsss.HasRows)
            {
                txtSeries.Text = sdrsss["Series"].ToString();
            }
        
            con.Close();
        }

        private void cmbProcess_TextChanged(object sender, EventArgs e)
        {
            Model1();
        }

        private void txtSeries_TextChanged(object sender, EventArgs e)
        {
            Model1();
            Process();
        }
    }
}
