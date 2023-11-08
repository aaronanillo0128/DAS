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
    public partial class EditMasterData : Form
    {
        public static EditMasterData _instance;
        public static string update = "";
        static string BBB = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlDataAdapter adapt;
        SqlCommand cmd;
        int ID;
        public EditMasterData()
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
            adapt = new SqlDataAdapter("Select * from Master_Data where Section = '" + LOGIN.LoginSection + "'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
            dataGridView1.Columns["Section"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
        }
        private void EditMasterData_Load(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            DisplayData();
            lblIDNum.Text = LOGIN.loginuser;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
            aaa.ShowDialog();
            this.Close();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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
            dataGridView1.RowTemplate.MinimumHeight = 250;
            dataGridView1.Columns["Edit"].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dataGridView1.Columns["delete"].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);

            dataGridView1.Columns["AssuranceItem"].Width = 180;
            dataGridView1.Columns["Classification"].Width = 180;
            dataGridView1.Columns["CheckItems"].Width = 180;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "✏️")
            {
                DialogResult DR = MessageBox.Show("Are you sure you want to EDIT this CheckItem?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(DR == DialogResult.Yes)
                {
                    AuditLookUp lookup = new AuditLookUp();

                    lookup.lblID.Text = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    lookup.txtAssurance.Text = this.dataGridView1.CurrentRow.Cells["AssuranceItem"].Value.ToString();
                    lookup.txtClassification.Text = this.dataGridView1.CurrentRow.Cells["Classification"].Value.ToString();
                    lookup.txtCheckItems.Text = this.dataGridView1.CurrentRow.Cells["CheckItems"].Value.ToString();
                    lookup.txtVersion.Text = this.dataGridView1.CurrentRow.Cells["Version"].Value.ToString();

                    lookup.ShowDialog();

                }
                else if(DR == DialogResult.No)
                {
                    //Do Nothing
                }
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "❌")

            {

                DialogResult DialogResult1 = MessageBox.Show("Are you sure do you want DELETE this Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult1 == DialogResult.Yes)
                {
                    //ID = dataGridView1.Rows[e.RowIndex].Cells["AuditID"].Value.ToString();
                    cmd = new SqlCommand("delete tbl_MasterAudit where ID=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", lblID.Text);
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

        public void searchACC()
        {
            DataSet ds = new DataSet();
            if (cmbSearchBy.Text == "Checksheet Name")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select * from Master_Data where TypeOfAudit like @typeaudit";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@typeaudit", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.Columns["Section"].Visible = false;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }

          
            else if (cmbSearchBy.Text == "Series")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select * from Master_Data where Series like @typeaudit";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@typeaudit", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.Columns["Section"].Visible = false;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }

            else if (cmbSearchBy.Text == "Model")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select * from Master_Data where Model like @typeaudit";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@typeaudit", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.Columns["Section"].Visible = false;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (cmbSearchBy.Text == "Process")
            {
                using (SqlConnection conn = new SqlConnection(BBB))
                {
                    string sql = "select * from Master_Data where Process like @typeaudit";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@typeaudit", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
                    dataGridView1.Columns["Section"].Visible = false;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.DataSource = ds.Tables[0];
                }
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

        private void btnGO_Click(object sender, EventArgs e)
        {
            searchACC();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
    }
}
