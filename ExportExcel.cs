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
using Excel = Microsoft.Office.Interop.Excel;

namespace PS_Digital_Audit
{
    public partial class ExportExcel : Form
    {
        public static Monitoring _instance;
        public static string update = "";
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;
        string ID;
        public ExportExcel()
        {
            InitializeComponent();
        }


        public void Line()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select Line from tbl_Line where Section = '" + LOGIN.LoginSection + "'";
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
                cmbShift.DisplayMember = "ShiftCode";
                cmbShift.ValueMember = "ShiftCode";
                cmbShift.DataSource = dt.Tables["ShiftCode"];

                conn.Close();

            }
        }

        public void Checksheet()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select TypeOfAudit from QA_TypeofAudit where Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "TypeOfAudit");
                cmbChecksheet.DisplayMember = "TypeOfAudit";
                cmbChecksheet.ValueMember = "TypeOfAudit";
                cmbChecksheet.DataSource = dt.Tables["TypeOfAudit"];

                conn.Close();

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

                conn.Close();

            }
        }

        public void Process()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select Distinct Process from tbl_AuditApproval where TypeofAudit = '" + cmbChecksheet.Text + "' AND Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                DataTable dtqq = new DataTable();
                sda.Fill(dtqq);
                cmbProcess.Items.Clear();
                cmbProcess.Items.Add("ALL");
                cmbProcess.SelectedIndex = 0;
                for (int i = 0; i < dtqq.Rows.Count; i++)
                {
                    cmbProcess.Items.Add(dtqq.Rows[i]["Process"]);
                }

            }
        }
        public void Model1()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select Distinct Model from tbl_AuditApproval where TypeofAudit = '" + cmbChecksheet.Text + "' AND Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "Model");
                cmbModel.DisplayMember = "Model";
                cmbModel.ValueMember = "Model";
                cmbModel.DataSource = dt.Tables["Model"];
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

        private void ExportExcel_Load(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            dataGridView1.RowTemplate.MinimumHeight = 200;
           // DisplayData();
            Line();
            Shift1();
           // Model1();
            Frequency();
           // Process();
            Checksheet();
            lblID_Num.Text = LOGIN.loginuser;
        }

        private void copyAlltoClipboardsss()
        {
            //dgvComponentList.SelectAll();
            //DataObject dataObj = dgvComponentList.GetClipboardContent();
            //if (dataObj != null)
            //    Clipboard.SetDataObject(dataObj);
            dataGridView1.SelectAll();
            //Copy to clipboard
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
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
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            
            else if (dialogResult == DialogResult.No)
            {
                //do Nothing
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

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (cmbProcess.Text == "ALL")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();

                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("select AuditID, TypeofAudit, Auditor, Line, Series, Model, Process, Assurance, Classification, CheckItems, Section, Date, First_Approver, TimeStamp1, First_DateApproved, First_Status, Second_Approver, TimeStamp2, Second_DateApproved, Second_Status, Third_Approver, TimeStamp3, Third_DateApproved, Third_Status, Status1, [1stAudit], [1stEnd], Remarks1, Comment1, TypeNG1, NGDetails1, Status2, [2ndAudit], [2ndEnd],  Remarks2, Comment2, TypeNG2, NGDetails2, Status3, [3rdAudit], [3rdEnd], Remarks3, Comment3, TypeNG3, NGDetails3, Status4, [4thAudit], [4thEnd], Remarks4, Comment4, TypeNG4, NGDetails4, Status5, [5thAudit], [5thEnd],  Remarks5, Comment5, TypeNG5, NGDetails5, Status6, [6thAudit], [6thEnd], Remarks6, Comment6, TypeNG6, NGDetails6, Status7, [7thAudit], [7thEnd], Remarks7, Comment7, TypeNG7, NGDetails7 from tbl_AuditApproval where Section = '" + LOGIN.LoginSection + "' AND Line = '" + cmbLine.Text + "' AND TypeofAudit = '" + cmbChecksheet.Text + "' AND Series = '" + txtSeries.Text + "' AND Frequency = '" + cmbFreq.Text + "' AND Model = '" + cmbModel.Text + "' AND Shift = '" + cmbShift.Text + "' AND Cast (Date as datetime) between '" + dtInputDateFrom.Value.ToString("MM/dd/yyyy") + " ' and '" + dtInputDateTo.Value.ToString("MM/dd/yyyy") + " '", con);
                    adapt.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;
                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
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
                    con.Open();

                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("select AuditID, TypeofAudit, Auditor, Line, Series, Model, Process, Assurance, Classification, CheckItems, Section, Date, First_Approver, TimeStamp1, First_DateApproved, First_Status, Second_Approver, TimeStamp2, Second_DateApproved, Second_Status, Third_Approver, TimeStamp3, Third_DateApproved, Third_Status, Status1, [1stAudit], [1stEnd], Remarks1, Comment1, TypeNG1, NGDetails1, Status2, [2ndAudit], [2ndEnd],  Remarks2, Comment2, TypeNG2, NGDetails2, Status3, [3rdAudit], [3rdEnd], Remarks3, Comment3, TypeNG3, NGDetails3, Status4, [4thAudit], [4thEnd], Remarks4, Comment4, TypeNG4, NGDetails4, Status5, [5thAudit], [5thEnd],  Remarks5, Comment5, TypeNG5, NGDetails5, Status6, [6thAudit], [6thEnd], Remarks6, Comment6, TypeNG6, NGDetails6, Status7, [7thAudit], [7thEnd], Remarks7, Comment7, TypeNG7, NGDetails7 from tbl_AuditApproval where Section = '" + LOGIN.LoginSection + "' AND Process = '" + cmbProcess.Text + "' AND Line = '" + cmbLine.Text + "' AND TypeofAudit = '" + cmbChecksheet.Text + "' AND Series = '" + txtSeries.Text + "' AND Frequency = '" + cmbFreq.Text + "' AND Model = '" + cmbModel.Text + "' AND Shift = '" + cmbShift.Text + "' AND Cast (Date as datetime) between '" + dtInputDateFrom.Value.ToString("MM/dd/yyyy") + " ' and '" + dtInputDateTo.Value.ToString("MM/dd/yyyy") + " '", con);
                    adapt.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;
                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;


                }
                else if (dialogResult1 == DialogResult.No)
                {
                    //do Nothing
                }
            }

            }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Columns["AuditID"].Width = 200;
            dataGridView1.Columns["Series"].Width = 200;
            dataGridView1.Columns["Assurance"].Width = 250;
            dataGridView1.Columns["Classification"].Width = 250;
            dataGridView1.Columns["CheckItems"].Width = 250;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
            aaa.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dataGridView1.Columns[0].Frozen = true;
            //dataGridView1.Columns[1].Frozen = true;
            //dataGridView1.Columns[2].Frozen = true;
            //dataGridView1.Columns[3].Frozen = true;
            //dataGridView1.Columns[4].Frozen = true;
            //dataGridView1.Columns[5].Frozen = true;
            //dataGridView1.Columns[6].Frozen = true;
            //dataGridView1.Columns[7].Frozen = true;
            //dataGridView1.Columns[8].Frozen = true;
            //dataGridView1.Columns[9].Frozen = true;
            //dataGridView1.Columns[10].Frozen = true;
        }

        private void cmbChecksheet_TextChanged(object sender, EventArgs e)
        {
            Process();
        }

        private void cmbProcess_TextChanged(object sender, EventArgs e)
        {
            Model1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
