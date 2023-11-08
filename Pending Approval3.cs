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
    public partial class Pending_Approval3 : Form
    {
        public static Pending_Approval3 _instance;
        public static string update = "";
        static string BBB = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;
        string ID;
        public Pending_Approval3()
        {
            _instance = this;
            InitializeComponent();
        }

        private void Pending_Approval3_Load(object sender, EventArgs e)
        {
            InputBy();
           // DisplayData();
            DisplayData2();
            dataGridView1.RowTemplate.MinimumHeight = 50;
            if (LOGIN.loginuser != null)
            {
                if (WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;

                lbl_IDNum.Text = LOGIN.loginuser;
                lblIDNum.Text = LOGIN.loginuser;
                lbl_Name.Text = LOGIN.loginName;
                lbl_Authority.Text = LOGIN.loginAutho;

            }
            if (LOGIN.loginAutho == "AdminENG")
            {

                Admin();
            }
            else if (LOGIN.loginAutho == "AdminSPV")
            {
                Admin();
            }
            else if (LOGIN.loginAutho == "AdminMGR")
            {
                Admin();
            }
            else
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select DISTINCT AuditID,Auditor,Date,Line,Process,Series,TypeofAudit,[View],[delete],[Change],Shift,Model from Approval where Third_Approver = '" + LOGIN.loginName + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc", con);
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
            dataGridView1.Columns["Shift"].Visible = false;
            dataGridView1.Columns["Model"].Visible = false;
            dataGridView1.Columns["TypeofAudit"].Visible = false;

            if (LOGIN.loginAutho != "AdminENG")
            {
                dataGridView1.Columns["Change"].Visible = false;
            }
            else if (LOGIN.loginAutho != "AdminSPV")
            {
                dataGridView1.Columns["Change"].Visible = false;
            }
            else if (LOGIN.loginAutho != "AdminMGR")
            {
                dataGridView1.Columns["Change"].Visible = false;
            }
        }

        private void DisplayData2()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select DISTINCT AuditID,Auditor,Third_DateApproved,Line,Process,Series,TypeofAudit,[delete],Shift,Model from Approval where Third_Approver = '" + LOGIN.loginName + "' AND Third_Status = 'Done'", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView2.AllowUserToResizeColumns = true;
            dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.DefaultCellStyle.Font = new Font("Calibri", 11);
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.Columns["Shift"].Visible = false;
            dataGridView2.Columns["Model"].Visible = false;
        }

        private void Admin()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],[Change],Model,Shift,First_Approver,Second_Approver,Third_Approver from Approval where Section = '" + LOGIN.LoginSection + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc", con);
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
            dataGridView1.Columns["Shift"].Visible = false;
            dataGridView1.Columns["Model"].Visible = false;
            dataGridView1.Columns["First_Approver"].Visible = false;
            dataGridView1.Columns["Second_Approver"].Visible = false;
            dataGridView1.Columns["Third_Approver"].Visible = false;
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
        public void searchACC()
        {
            DataSet ds = new DataSet();
            if (cmbSearchBy.Text == "Audit ID")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],[Change],Model,Shift from Approval where AuditID like @auditid AND Third_Approver = '" + LOGIN.loginName + "' AND Section = '" + LOGIN.LoginSection + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@auditid", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                }
            }
            else if (cmbSearchBy.Text == "Date")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],[Change],Model,Shift from Approval where Date like @date AND Third_Approver = '" + LOGIN.loginName + "' AND Section = '" + LOGIN.LoginSection + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@date", "%" + Date.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                }
            }
            else if (cmbSearchBy.Text == "Line")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],[Change],Model,Shift from Approval where Line like @line AND Third_Approver = '" + LOGIN.loginName + "' AND Section = '" + LOGIN.LoginSection + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@line", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                }
            }
            else if (cmbSearchBy.Text == "Series")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],[Change],Model,Shift from Approval where Series like @series AND Third_Approver = '" + LOGIN.loginName + "' AND Section = '" + LOGIN.LoginSection + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@series", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                }
            }
            else if (cmbSearchBy.Text == "Model")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],[Change],Model,Shift from Approval where Model like @model AND Third_Approver = '" + LOGIN.loginName + "' AND Section = '" + LOGIN.LoginSection + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@model", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                }
            }
        }

        public void searchACC2()
        {
            DataSet ds = new DataSet();
            if (cmbSearchBy.Text == "Audit ID")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],Shift,Model,First_Approver,Second_Approver,Third_Approver from Approval where AuditID like '%" + txtSearch.Text + "%' AND Third_Approver = '" + LOGIN.loginName + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                    dataGridView1.Columns["First_Approver"].Visible = false;
                    dataGridView1.Columns["Second_Approver"].Visible = false;
                    dataGridView1.Columns["Third_Approver"].Visible = false;
                }
            }
            else if (cmbSearchBy.Text == "Date")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],Shift,Model,First_Approver,Second_Approver,Third_Approver from Approval where Date like @date AND Third_Approver = '" + LOGIN.loginName + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@date", "%" + Date.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                    dataGridView1.Columns["First_Approver"].Visible = false;
                    dataGridView1.Columns["Second_Approver"].Visible = false;
                    dataGridView1.Columns["Third_Approver"].Visible = false;

                }
            }
            else if (cmbSearchBy.Text == "Line")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],Shift,Model,First_Approver,Second_Approver,Third_Approver from Approval where Line like @line AND Third_Approver = '" + LOGIN.loginName + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@line", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                    dataGridView1.Columns["First_Approver"].Visible = false;
                    dataGridView1.Columns["Second_Approver"].Visible = false;
                    dataGridView1.Columns["Third_Approver"].Visible = false;
                }
            }
            else if (cmbSearchBy.Text == "Series")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],Shift,Model,First_Approver,Second_Approver,Third_Approver from Approval where Series like @series AND Third_Approver = '" + LOGIN.loginName + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@series", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                    dataGridView1.Columns["First_Approver"].Visible = false;
                    dataGridView1.Columns["Second_Approver"].Visible = false;
                    dataGridView1.Columns["Third_Approver"].Visible = false;

                }
            }
            else if (cmbSearchBy.Text == "Model")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],Shift,Model,First_Approver,Second_Approver,Third_Approver from Approval where Model like @model AND Third_Approver = '" + LOGIN.loginName + "' AND case when Third_Status is NULL then 0 when Third_Status = '' then 0 else 1 end=0 order by Date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@model", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dataGridView1.AllowUserToResizeColumns = true;
                    dataGridView1.AllowUserToOrderColumns = true;

                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.Columns["Shift"].Visible = false;
                    dataGridView1.Columns["Model"].Visible = false;
                    dataGridView1.Columns["First_Approver"].Visible = false;
                    dataGridView1.Columns["Second_Approver"].Visible = false;
                    dataGridView1.Columns["Third_Approver"].Visible = false;

                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.ColumnCount > 11)
            {
                if (e.ColumnIndex == 8 && e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(210, 52, 74);
                    e.CellStyle.ForeColor = Color.White;
                }

                if (e.ColumnIndex == 7 && e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(60, 179, 141);
                    e.CellStyle.ForeColor = Color.White;
                }
                if (e.ColumnIndex == 9 && e.Value != null)
                {
                    e.CellStyle.BackColor = Color.Gray;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
            else
            {
                if (e.ColumnIndex == 7 && e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(210, 52, 74);
                    e.CellStyle.ForeColor = Color.White;
                }

                if (e.ColumnIndex == 6 && e.Value != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(60, 179, 141);
                    e.CellStyle.ForeColor = Color.White;
                }

            }

            dataGridView1.RowTemplate.MinimumHeight = 50;
            dataGridView1.Columns["View"].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dataGridView1.Columns["delete"].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dataGridView1.Columns["Change"].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);

            dataGridView1.Columns["AuditID"].Width = 180;
            dataGridView1.Columns["Auditor"].Width = 150;
            dataGridView1.Columns["Date"].Width = 90;
            dataGridView1.Columns["Line"].Width = 50;
            dataGridView1.Columns["Process"].Width = 150;
            dataGridView1.Columns["Series"].Width = 150;
            dataGridView1.Columns["View"].Width = 80;
            dataGridView1.Columns["delete"].Width = 80;
            dataGridView1.Columns["Change"].Width = 80;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "👁️")
            {

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to VIEW this item for APPROVAL?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    ApprovalLookup3 lookup = new ApprovalLookup3();

                    lookup.lblAuditID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    lookup.lblLine.Text = this.dataGridView1.CurrentRow.Cells["Line"].Value.ToString();
                    lookup.lblProcess.Text = this.dataGridView1.CurrentRow.Cells["Process"].Value.ToString();
                    lookup.lblShift.Text = this.dataGridView1.CurrentRow.Cells["Shift"].Value.ToString();
                    lookup.lblModel.Text = this.dataGridView1.CurrentRow.Cells["Model"].Value.ToString();
                    lookup.lblSeries.Text = this.dataGridView1.CurrentRow.Cells["Series"].Value.ToString();

                    lookup.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do Nothing
                }
            }

            else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "❌")

            {

                DialogResult DialogResult1 = MessageBox.Show("Are you sure you want DELETE this Audit Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult1 == DialogResult.Yes)
                {
                    ID = dataGridView1.Rows[e.RowIndex].Cells["AuditID"].Value.ToString();
                    cmd = new SqlCommand("delete tbl_AuditApproval where AuditID=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
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
            else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "⚙️")

            {

                DialogResult DialogResult2 = MessageBox.Show("Are you sure do you want CHANGE Approver?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult2 == DialogResult.Yes)
                {
                    ApproverPanel.Visible = true;

                    lblAuditID.Text = dataGridView1.Rows[e.RowIndex].Cells["AuditID"].Value.ToString();
                    lblSeries.Text = dataGridView1.Rows[e.RowIndex].Cells["Series"].Value.ToString();
                    lblShift.Text = dataGridView1.Rows[e.RowIndex].Cells["Shift"].Value.ToString();
                    lblLine.Text = dataGridView1.Rows[e.RowIndex].Cells["Line"].Value.ToString();
                    lblModel.Text = dataGridView1.Rows[e.RowIndex].Cells["Model"].Value.ToString();
                    lblProcess.Text = dataGridView1.Rows[e.RowIndex].Cells["Process"].Value.ToString();

                    if (LOGIN.loginAutho == "AdminENG")
                    {
                        lblCurrent.Text = dataGridView1.Rows[e.RowIndex].Cells["First_Approver"].Value.ToString();
                    }
                    else if (LOGIN.loginAutho == "AdminSPV")
                    {
                        lblCurrent.Text = dataGridView1.Rows[e.RowIndex].Cells["Second_Approver"].Value.ToString();
                    }
                    else if (LOGIN.loginAutho == "AdminMGR")
                    {
                        lblCurrent.Text = dataGridView1.Rows[e.RowIndex].Cells["Third_Approver"].Value.ToString();
                    }

                    Admin();
                }
                else if (DialogResult2 == DialogResult.No)
                {
                    //do Nothing
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

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.Value != null)
            {
                e.CellStyle.BackColor = Color.FromArgb(210, 52, 74);
                e.CellStyle.ForeColor = Color.White;
            }

            dataGridView2.RowTemplate.MinimumHeight = 50;
            dataGridView2.Columns["delete"].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);

            dataGridView2.Columns["AuditID"].Width = 180;
            dataGridView2.Columns["Auditor"].Width = 150;
            dataGridView2.Columns["Third_DateApproved"].Width = 90;
            dataGridView2.Columns["Line"].Width = 50;
            dataGridView2.Columns["Process"].Width = 150;
            dataGridView2.Columns["Series"].Width = 150;
            dataGridView2.Columns["delete"].Width = 160;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
            DisplayData2();
        }
        public void refreshdata()
        {
            DisplayData();
            DisplayData2();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "❌")
            {
                DialogResult DialogResult1 = MessageBox.Show("Are you sure you want DELETE this Audit Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult1 == DialogResult.Yes)
                {
                    ID = dataGridView2.Rows[e.RowIndex].Cells["AuditID"].Value.ToString();
                    cmd = new SqlCommand("delete tbl_AuditApproval where AuditID=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DisplayData2();
                }
                else if (DialogResult1 == DialogResult.No)
                {
                    //do Nothing
                }
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            searchACC();
            if (LOGIN.loginAutho == "AdminENG")
            {
                searchACC2();
            }
            else if (LOGIN.loginAutho == "AdminSPV")
            {
                searchACC2();
            }
            else if (LOGIN.loginAutho == "AdminMGR")
            {
                searchACC2();
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
            builder.Append("<b><font color=Black>Please be informed that you have been assigned as the new approver. kindly view issued <a href='\\\\apbiphsh07\\D0_ShareBrotherGroup\\19_BPS\\Installer\\PSAudit\\setup.exe'> DIGITAL AUDIT </a> today");
            builder.Append("<br>");
            builder.Append("<b><font color=Black>Auditor:   " + LOGIN.loginName + " </b>");
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
            builder.Append("<br>");
            builder.Append("<b><font color=Black>This is a System Generated Mail, Do not reply!</b><br>");
            builder.Append("<h2><br>Thank you!</h2>").AppendLine();
            innerString = builder.ToString();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            audit_email2();
            if (cmbChecker.Text != "")
            {
                cmd = new SqlCommand("update tbl_AuditApproval set Third_Approver=@thirdapprover where AuditID=@auditid", con);
                con.Open();
                cmd.Parameters.AddWithValue("@auditid", lblAuditID.Text);
                cmd.Parameters.AddWithValue("@thirdapprover", cmbChecker.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ApproverPanel.Visible = false;
                Admin();
            }
        }

        private void cmbSearchBy_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.Text == "Date")
            {
                Date.Visible = true;
                txtSearch.Text = "";
            }
            else
            {
                Date.Visible = false;
                Date.Text = "";
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

