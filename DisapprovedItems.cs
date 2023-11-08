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
    public partial class DisapprovedItems : Form
    {
        public static string update = "";
        static string BBB = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;
        public DisapprovedItems()
        {
            InitializeComponent();
        }
        private void DisplayData()
        {
            if (LOGIN.loginAutho == "Engineer")
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select DISTINCT AuditID,Auditor,Date,Line,Process,Series,TypeofAudit,Status,RejectedBy from tbl_AuditApproval where Section = '" + LOGIN.LoginSection + "' AND Status = 'Rejected'", con);
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
            else if (LOGIN.loginAutho == "Supervisor")
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select DISTINCT AuditID,Auditor,Date,Line,Process,Series,TypeofAudit,Status,RejectedBy from tbl_AuditApproval where Section = '" + LOGIN.LoginSection + "' AND Status = 'Rejected'", con);
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
            else if(LOGIN.loginAutho == "Manager")
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select DISTINCT AuditID,Auditor,Date,Line,Process,Series,TypeofAudit,Status,RejectedBy from tbl_AuditApproval where Section = '" + LOGIN.LoginSection + "' AND Status = 'Rejected'", con);
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
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisapprovedItems_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
                dataGridView1.Columns["AuditID"].Width = 180;
                dataGridView1.Columns["Auditor"].Width = 150;
                dataGridView1.Columns["Date"].Width = 90;
                dataGridView1.Columns["Line"].Width = 100;
                dataGridView1.Columns["Process"].Width = 180;
                dataGridView1.Columns["Series"].Width = 90;
                dataGridView1.Columns["TypeofAudit"].Width = 150;


            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Rejected")
            {
                dataGridView1.Columns["Status"].DefaultCellStyle.BackColor = Color.DarkRed;
                dataGridView1.Columns["Status"].DefaultCellStyle.ForeColor = Color.White;
                dataGridView1.Columns["Status"].DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                dataGridView1.Columns["RejectedBy"].DefaultCellStyle.BackColor = Color.DarkRed;
                dataGridView1.Columns["RejectedBy"].DefaultCellStyle.ForeColor = Color.White;
                dataGridView1.Columns["RejectedBy"].DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
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

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }
    }
    }

