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
    public partial class ApprovalLookup3 : Form
    {
        public static Monitoring _instance;
        public static string update = "";
        static string BBB = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;
        int ID = 0;
        public ApprovalLookup3()
        {
            InitializeComponent();
        }

        private void ApprovalLookup3_Load(object sender, EventArgs e)
        {
            dataEron.RowTemplate.MinimumHeight = 200;
            DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select TypeofAudit, Auditor, Series, Model, Process, Assurance, Classification, CheckItems, Date, TimeStamp2, Status1,[1stAudit], [1stEnd], Comment1, Remarks1, TypeNG1, NGDetails1, Status2, [2ndAudit], [2ndEnd], Comment2, Remarks2, TypeNG2, NGDetails2, Status3, [3rdAudit], [3rdEnd], Comment3, Remarks3, TypeNG3, NGDetails3,  Status4,  [4thAudit], [4thEnd], Comment4, Remarks4, TypeNG4, NGDetails4, Status5, [5thAudit], [5thEnd], Comment5,  Remarks5, TypeNG5, NGDetails5, Status6, [6thAudit], [6thEnd], Comment6, Remarks6, TypeNG6, NGDetails6, Status7, [7thAudit], [7thEnd], Comment7, Remarks7, TypeNG7, NGDetails7 from tbl_AuditApproval where AuditID = '" + lblAuditID.Text + "'", con);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            CompPanel.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveAudit_Click(object sender, EventArgs e)
        {
            DateTime aa = DateTime.Now;
            string date1 = aa.ToString("MM/dd/yyyy");
            string cnt = Convert.ToString(date1);

            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("update tbl_AuditApproval set Date_Completed = @datecomplete, Status=@status, Third_DateApproved = @date, RemarksApproval3=@remapp3, Third_Status = @Thirdstat, TimeStamp3 = @timestamp3 where AuditID = '" + lblAuditID.Text + "'", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@date", date1);
                cmd.Parameters.AddWithValue("@remapp3", tbRemarksFinal.Text);
                cmd.Parameters.AddWithValue("@datecomplete", date1);
                cmd.Parameters.AddWithValue("@Thirdstat", "Done");
                cmd.Parameters.AddWithValue("@status", "Done");
                cmd.Parameters.AddWithValue("@timestamp3", timeString);
                cmd.ExecuteNonQuery();
                con.Close();

               Pending_Approval3._instance.refreshdata();
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do Nothing
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CompPanel.Visible = false;
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

        private void jeButton1_Click(object sender, EventArgs e)
        {

        }
    }
    }

