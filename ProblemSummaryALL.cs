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
    public partial class ProblemSummaryALL : Form
    {
        public static string link = "";
        public static ProblemSummaryALL _instance;
        static string BBB = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;
        int ID = 0;
        string ID2;
        string checksheet;
        string freq;
        public ProblemSummaryALL()
        {
            _instance = this;
            InitializeComponent();
        }

        public void refreshdata()
        {
            DisplayData();
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from ProblemSummary where TypeofAudit = '" +lblTypeofAudit2.Text+ "' AND Line = '" + lblLine.Text + "' AND Section = '" + LOGIN.LoginSection + "' AND Cast (DateEncountered as datetime) between '" + label5.Text + " ' and '" + label4.Text + "'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10);
            dataGridView1.Columns["TypeofAudit"].Visible = false;
            //dataGridView1.Columns["Status"].Visible = false;
            dataGridView1.Columns["Cause"].Visible = false;
            dataGridView1.Columns["Countermeasure"].Visible = false;
            dataGridView1.Columns["Picture"].Visible = false;
            dataGridView1.Columns["ActualDateClosure"].Visible = false;
            dataGridView1.Columns["TargetDateClosure"].Visible = false;
            dataGridView1.Columns["Section"].Visible = false;
            dataGridView1.Columns["NGDetails"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;


            dataGridView1.Columns[2].HeaderText = "ChecksheetNo";
            dataGridView1.Columns[3].HeaderText = "Audit ID";
            dataGridView1.Columns[4].HeaderText = "Freq";
            dataGridView1.Columns[5].HeaderText = "Auditor";
            dataGridView1.Columns[6].HeaderText = "Line";
            dataGridView1.Columns[7].HeaderText = "Series";
            dataGridView1.Columns[8].HeaderText = "Model";
            dataGridView1.Columns[9].HeaderText = "Process";
            dataGridView1.Columns[10].HeaderText = "Date Ecountered";
            dataGridView1.Columns[11].HeaderText = "Type of NG";
            dataGridView1.Columns[12].HeaderText = "NG Details";
            dataGridView1.Columns[13].HeaderText = "Checksheet Name";
            dataGridView1.Columns[0].HeaderText = "View";
            dataGridView1.Columns[1].HeaderText = "Delete";
        }
         

        private void DisplayData2()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from ProblemSummary where TypeofAudit = '" + lblTypeofAudit2.Text + "'  AND Line = '" + lblLine.Text + "' AND Section = '" + LOGIN.LoginSection + "' AND Status != 'OPEN' AND Cast (DateEncountered as datetime) between '" + label5.Text + " ' and '" + label4.Text + "'", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

            this.dataGridView2.DefaultCellStyle.Font = new Font("Calibri", 10);
            dataGridView2.Columns["TypeofAudit"].Visible = false;
            //dataGridView1.Columns["Status"].Visible = false;
            dataGridView2.Columns["Cause"].Visible = false;
            dataGridView2.Columns["Countermeasure"].Visible = false;

            dataGridView2.Columns["ActualDateClosure"].Visible = false;
            dataGridView2.Columns["TargetDateClosure"].Visible = false;
            dataGridView2.Columns["Section"].Visible = false;
            dataGridView2.Columns["NGDetails"].Visible = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
            dataGridView2.EnableHeadersVisualStyles = false;
        }

        private void DisplayData3()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from ProblemSummary where TypeofAudit = '" + lblTypeofAudit2.Text + "'  AND Line = '" + lblLine.Text + "' AND Section = '" + LOGIN.LoginSection + "' AND Status != 'CLOSED' AND Cast (DateEncountered as datetime) between '" + label5.Text + " ' and '" + label4.Text + "'", con);
            adapt.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();

            this.dataGridView3.DefaultCellStyle.Font = new Font("Calibri", 10);
            dataGridView3.Columns["TypeofAudit"].Visible = false;
            //dataGridView1.Columns["Status"].Visible = false;
            dataGridView3.Columns["Cause"].Visible = false;
            dataGridView3.Columns["Countermeasure"].Visible = false;

            dataGridView3.Columns["ActualDateClosure"].Visible = false;
            dataGridView3.Columns["TargetDateClosure"].Visible = false;
            dataGridView3.Columns["Section"].Visible = false;
            dataGridView3.Columns["NGDetails"].Visible = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
            dataGridView3.EnableHeadersVisualStyles = false;

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

        private void ProblemSummaryALL_Load(object sender, EventArgs e)
        {
            lblLine.Text = ResultSummary.Line1;
            lblTypeofAudit2.Text = ResultSummary.inline1;
            label5.Text = ResultSummary.datefrom;
            label4.Text = ResultSummary.dateto;
            dataGridView1.RowTemplate.MinimumHeight = 40;
            DisplayData();
            DisplayData2();
            DisplayData3();

            txtOpenNotif.Text = dataGridView3.Rows.Count.ToString();
            txtCloseNotif.Text = dataGridView2.Rows.Count.ToString();
            lblID_Num.Text = LOGIN.loginuser;
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
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


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Hide();
            ProbSumLookup lookup = new ProbSumLookup();
            lookup.txtChecksheetNo.Text = this.dataGridView1.CurrentRow.Cells["ChecksheetNo"].Value.ToString();
            lookup.txt_AuditID.Text = this.dataGridView1.CurrentRow.Cells["AuditID"].Value.ToString();
            lookup.txt_Cause.Text = this.dataGridView1.CurrentRow.Cells["Cause"].Value.ToString();
            lookup.txt_Counter.Text = this.dataGridView1.CurrentRow.Cells["Countermeasure"].Value.ToString();
            lookup.txt_DateEncount.Text = this.dataGridView1.CurrentRow.Cells["DateEncountered"].Value.ToString();
            lookup.txt_NGDetails.Text = this.dataGridView1.CurrentRow.Cells["NGDetails"].Value.ToString();
            lookup.txt_TypeofNG.Text = this.dataGridView1.CurrentRow.Cells["TypeOfNG"].Value.ToString();
            lookup.cmbStatus.Text = this.dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
            lookup.date.Text = this.dataGridView1.CurrentRow.Cells["ActualDateClosure"].Value.ToString();
            lookup.date2.Text = this.dataGridView1.CurrentRow.Cells["TargetDateClosure"].Value.ToString();
            lookup.picSource.ImageLocation = this.dataGridView1.CurrentRow.Cells["Picture"].Value.ToString();
            lookup.txtFreq.Text = this.dataGridView1.CurrentRow.Cells["Frequency"].Value.ToString();
            lookup.ShowDialog();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResultSummary aaa = new ResultSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void jeButton1_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Columns["AuditID"].Width = 180;
            dataGridView1.Columns["Model"].Width = 134;
            dataGridView1.Columns["Frequency"].Width = 60;
            dataGridView1.Columns["Status"].Width = 75;
            if (e.ColumnIndex == 1 && e.Value != null)
            {
                e.CellStyle.BackColor = Color.FromArgb(210, 52, 74);
                e.CellStyle.ForeColor = Color.White;
            }
            else if (e.ColumnIndex == 0 && e.Value != null)
            {
                e.CellStyle.BackColor = Color.FromArgb(60, 179, 141);
                e.CellStyle.ForeColor = Color.White;
            }

            dataGridView1.RowTemplate.MinimumHeight = 50;
            dataGridView1.Columns["View"].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dataGridView1.Columns["delete"].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "👁️")
                {

                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to CONTINUE/EDIT?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        ProbSumLookup lookup = new ProbSumLookup();

                        lookup.txtChecksheetNo.Text = this.dataGridView1.CurrentRow.Cells["ChecksheetNo"].Value.ToString();
                        lookup.txt_AuditID.Text = this.dataGridView1.CurrentRow.Cells["AuditID"].Value.ToString();
                        lookup.txt_Cause.Text = this.dataGridView1.CurrentRow.Cells["Cause"].Value.ToString();
                        lookup.txt_Counter.Text = this.dataGridView1.CurrentRow.Cells["Countermeasure"].Value.ToString();
                        lookup.txt_DateEncount.Text = this.dataGridView1.CurrentRow.Cells["DateEncountered"].Value.ToString();
                        lookup.txt_NGDetails.Text = this.dataGridView1.CurrentRow.Cells["NGDetails"].Value.ToString();
                        lookup.txt_TypeofNG.Text = this.dataGridView1.CurrentRow.Cells["TypeOfNG"].Value.ToString();
                        lookup.cmbStatus.Text = this.dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
                        lookup.date.Text = this.dataGridView1.CurrentRow.Cells["ActualDateClosure"].Value.ToString();
                        lookup.date2.Text = this.dataGridView1.CurrentRow.Cells["TargetDateClosure"].Value.ToString();
                        lookup.picSource.ImageLocation = this.dataGridView1.CurrentRow.Cells["Picture"].Value.ToString();
                        lookup.txtFreq.Text = this.dataGridView1.CurrentRow.Cells["Frequency"].Value.ToString();


                        lookup.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do Nothing
                    }

                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "❌")

                {

                    DialogResult DialogResult1 = MessageBox.Show("Are you sure do you want DELETE this Audit ID?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult1 == DialogResult.Yes)
                    {
                        ID2 = dataGridView1.Rows[e.RowIndex].Cells["AuditID"].Value.ToString();
                        checksheet = dataGridView1.Rows[e.RowIndex].Cells["ChecksheetNo"].Value.ToString();
                        freq = dataGridView1.Rows[e.RowIndex].Cells["Frequency"].Value.ToString();
                        cmd = new SqlCommand("delete tbl_ProblemSummary where AuditID=@id AND ChecksheetNo=@checksheet AND Frequency=@freq", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", ID2);
                        cmd.Parameters.AddWithValue("@checksheet", checksheet);
                        cmd.Parameters.AddWithValue("@freq", freq);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Record Deleted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        DisplayData();
                    }
                    else if (DialogResult1 == DialogResult.No)
                    {
                        //do Nothing
                    }
                }
            }
            catch
            {

            }
          
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {

        }
    }
    }

