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
    public partial class OtherPendingApproval : Form
    {
        static string BBB = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;
        string ID;
        public OtherPendingApproval()
        {
            InitializeComponent();
        }

        private void OtherPendingApproval_Load(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            lblIDNum.Text = LOGIN.loginuser;
            if (LOGIN.loginAutho == "Manager")
            {
                Manager();
            }
            if (LOGIN.loginAutho == "Supervisor")
            {
                Supervisor();
            }
        }
        private void Supervisor()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],[Change],Model,Shift,First_Approver,Second_Approver,Third_Approver from Approval where Status = 'Ongoing' AND Section = '" + LOGIN.LoginSection + "'", con);
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


            if (LOGIN.loginAutho == "Supervisor")
            {
                //Manager();
                dataGridView1.Columns["View"].Visible = false;
                dataGridView1.Columns["delete"].Visible = false;
                dataGridView1.Columns["Change"].Visible = false;
                dataGridView1.Columns["First_Approver"].HeaderText = "1stApprover";
                dataGridView1.Columns["Second_Approver"].HeaderText = "2ndApprover";
                dataGridView1.Columns["Third_Approver"].HeaderText = "3rdApprover";
            }
            //dataGridView1.Columns["First_Approver"].Visible = false;
            //dataGridView1.Columns["Second_Approver"].Visible = false;
            //dataGridView1.Columns["Third_Approver"].Visible = false;
        }
        private void Manager()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select DISTINCT AuditID,Auditor,Date,Line,Process,Series,[View],[delete],[Change],Model,Shift,First_Approver,Second_Approver,Third_Approver from Approval where Status = 'Ongoing' AND Section = '" + LOGIN.LoginSection + "'", con);
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
         

            if (LOGIN.loginAutho == "Manager")
            {
                //Manager();
                dataGridView1.Columns["View"].Visible = false;
                dataGridView1.Columns["delete"].Visible = false;
                dataGridView1.Columns["Change"].Visible = false;
                dataGridView1.Columns["First_Approver"].HeaderText = "1stApprover";
                dataGridView1.Columns["Second_Approver"].HeaderText = "2ndApprover";
                dataGridView1.Columns["Third_Approver"].HeaderText = "3rdApprover";
            }
            //dataGridView1.Columns["First_Approver"].Visible = false;
            //dataGridView1.Columns["Second_Approver"].Visible = false;
            //dataGridView1.Columns["Third_Approver"].Visible = false;
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
            this.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.RowTemplate.MinimumHeight = 50;

            dataGridView1.Columns["AuditID"].Width = 180;
            dataGridView1.Columns["Auditor"].Width = 150;
            dataGridView1.Columns["Line"].Width = 75;
            dataGridView1.Columns["Process"].Width = 150;
            dataGridView1.Columns["Series"].Width = 150;
            dataGridView1.Columns["First_Approver"].Width = 120;
            dataGridView1.Columns["Second_Approver"].Width = 120;
            dataGridView1.Columns["Third_Approver"].Width = 120;

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
    }
}
