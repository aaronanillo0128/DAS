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
    public partial class NG_Maintenance : Form
    {
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;

        int ID = 0;
        public NG_Maintenance()
        {
            InitializeComponent();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select * from tbl_TypeofNG where Section = '" + LOGIN.LoginSection + "'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
            //dataGridView1.Columns["Password"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.Columns[1].HeaderText = "TYPE OF NG";
            dataGridView1.Columns[2].HeaderText = "CHECKSHEET NAME";
            dataGridView1.Columns[3].HeaderText = "SECTION";
            dataGridView1.Columns[4].HeaderText = "INPUT NAME";
            dataGridView1.Columns[5].HeaderText = "INPUT DATE";
        }

        private void NG_Maintenance_Load(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

            dataGridView1.RowTemplate.MinimumHeight = 35;
            lblID_Num.Text = LOGIN.loginuser;
            DisplayData();
            Checksheet();
            InputBy();
            Section();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtNG.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbChecksheet.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbSection.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbInputBy.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtInputDate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void jebtnAdd_Click(object sender, EventArgs e)
        {
            if (txtNG.Text != "" && cmbSection.Text != "" && cmbChecksheet.Text != "" && cmbInputBy.Text != "" && dtInputDate.Text != "")
            {
                cmd = new SqlCommand("insert into tbl_TypeofNG(TypeofNG,ChecksheetName,Section,InputName,InputDate) values (@typeofng,@checksheetname,@section,@inputname,@inputdate)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@typeofng", txtNG.Text);
                cmd.Parameters.AddWithValue("@checksheetname", cmbChecksheet.Text);
                cmd.Parameters.AddWithValue("@section", cmbSection.Text);
                cmd.Parameters.AddWithValue("@inputname", cmbInputBy.Text);
                cmd.Parameters.AddWithValue("@inputdate", dtInputDate.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DisplayData();

            }
            else
            {
                MessageBox.Show("Please Provide Details!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNG.Text != "" && cmbSection.Text != "" && cmbChecksheet.Text != "" && cmbInputBy.Text != "" && dtInputDate.Text != "")
            {
                cmd = new SqlCommand("update tbl_TypeofNG set TypeofNG=@typeofng,ChecksheetName=@checksheetname,Section=@section,InputName=@inputname,InputDate=@inputdate where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@typeofng", txtNG.Text);
                cmd.Parameters.AddWithValue("@checksheetname", cmbChecksheet.Text);
                cmd.Parameters.AddWithValue("@section", cmbSection.Text);
                cmd.Parameters.AddWithValue("@inputname", cmbInputBy.Text);
                cmd.Parameters.AddWithValue("@inputdate", dtInputDate.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Successfully Update!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DisplayData();
            }
            else
            {
                MessageBox.Show("Choose record to Update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete tbl_TypeofNG where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DisplayData();

            }
            else
            {
                MessageBox.Show("Please Select Record to Delete", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Checksheet()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select CheckSheetName from tbl_CheckSheet where Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "CheckSheetName");
                cmbChecksheet.DisplayMember = "CheckSheetName";
                cmbChecksheet.ValueMember = "CheckSheetName";
                cmbChecksheet.DataSource = dt.Tables["CheckSheetName"];
                conn.Close();
            }
        }


        public void Section()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select ListOfSection from tbl_SectionList";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "ListOfSection");
                cmbSection.DisplayMember = "ListOfSection";
                cmbSection.ValueMember = "ListOfSection";
                cmbSection.DataSource = dt.Tables["ListOfSection"];
                conn.Close();
                }
            }

        public void InputBy()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select Name from tbl_PSuser where Section = '" + LOGIN.LoginSection + "' Order by ID desc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "Name");
                cmbInputBy.DisplayMember = "Name";
                cmbInputBy.ValueMember = "Name";
                cmbInputBy.DataSource = dt.Tables["Name"];
                conn.Close();
            }
        }

        public void searchACC()
        {
            DataSet ds = new DataSet();
            if (cmbSearchBy.Text == "Section")
            {
                using (SqlConnection conn = new SqlConnection(AAA))
                {
                    string sql = "select * from tbl_TypeofNG where Section like @section";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@section", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns[1].HeaderText = "TYPE OF NG";
                    dataGridView1.Columns[2].HeaderText = "CHECKSHEET NAME";
                    dataGridView1.Columns[3].HeaderText = "SECTION";
                    dataGridView1.Columns[4].HeaderText = "INPUT NAME";
                    dataGridView1.Columns[5].HeaderText = "INPUT DATE";

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }

            else if (cmbSearchBy.Text == "Checksheet Name")
            {
                using (SqlConnection conn = new SqlConnection(AAA))
                {
                    string sql = "select * from tbl_TypeofNG where ChecksheetName like @checksheetname";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@checksheetname", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns[1].HeaderText = "TYPE OF NG";
                    dataGridView1.Columns[2].HeaderText = "CHECKSHEET NAME";
                    dataGridView1.Columns[3].HeaderText = "SECTION";
                    dataGridView1.Columns[4].HeaderText = "INPUT NAME";
                    dataGridView1.Columns[5].HeaderText = "INPUT DATE";

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (cmbSearchBy.Text == "Input By")
            {
                using (SqlConnection conn = new SqlConnection(AAA))
                {
                    string sql = "select * from tbl_TypeofNG where InputName like @inputname";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@inputname", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns[1].HeaderText = "TYPE OF NG";
                    dataGridView1.Columns[2].HeaderText = "CHECKSHEET NAME";
                    dataGridView1.Columns[3].HeaderText = "SECTION";
                    dataGridView1.Columns[4].HeaderText = "INPUT NAME";
                    dataGridView1.Columns[5].HeaderText = "INPUT DATE";

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

        private void btnGO_Click(object sender, EventArgs e)
        {
            searchACC();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aaa = new Admin();
            aaa.ShowDialog();
            this.Close();
        }

        Label clickedLabel;
        PictureBox clickedPic;
        private void label10_MouseEnter(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.LightBlue;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.FromArgb(0, 188, 212);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aaa = new Admin();
            aaa.ShowDialog();
            this.Close();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != clickedPic)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != clickedPic)
                theLabel.BackColor = Color.FromArgb(0, 188, 212);
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

        private void NG_Maintenance_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void txtCName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
            aaa.ShowDialog();
            this.Close();
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
    }
    }
    
 
        
 
