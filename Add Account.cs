using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_Digital_Audit
{
    public partial class Add_Account : Form
    {
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;
        int ID;
        public Add_Account()
        {
            InitializeComponent();
        }

        private void jebtnAdd_Click(object sender, EventArgs e)
        {
            if (txtIDNum.Text != "" && txtName.Text != "" && txtPass.Text != "" && txtName.Text != "" && txtDept.Text != "" && cmbSection.Text != "" && cmbAutho.Text != "" && txtEmail.Text != "")
            {
                string SElectDouble_SQL = string.Empty;
                SElectDouble_SQL = "SELECT ID_Number from tbl_PSuser where ID_Number = '" + txtIDNum.Text + "'";
                bool DoubleData = false;
                DoubleData = CRUD.RETRIEVESINGLE(SElectDouble_SQL);
                if (DoubleData == true)
                {
                    MessageBox.Show("DUPLICATE ENTRY DETECTED!", "Digital Audit System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    cmd = new SqlCommand("insert into tbl_PSuser(ID_Number,Password,Name,Department,Section,Authority,Email) Values (@idnum,@pass,@name,@dept,@section,@autho,@email)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@idnum", txtIDNum.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@dept", txtDept.Text);
                    cmd.Parameters.AddWithValue("@section", cmbSection.Text);
                    cmd.Parameters.AddWithValue("@autho", cmbAutho.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DisplayData();

                }

            }
            else
            {
                MessageBox.Show("Please Provide Details!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select ID, ID_Number, Password, Name, Department, Section, Authority, Email from tbl_PSuser", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
            dataGridView1.Columns["Password"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.Columns[1].HeaderText = "ID NO.";
            dataGridView1.Columns[3].HeaderText = "FULL NAME";
            dataGridView1.Columns[2].HeaderText = "PASSWORD";
            dataGridView1.Columns[4].HeaderText = "DEPARTMENT";
            dataGridView1.Columns[5].HeaderText = "SECTION";
            dataGridView1.Columns[6].HeaderText = "AUTHORITY";
            dataGridView1.Columns[7].HeaderText = "EMAIL";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtIDNum.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPass.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDept.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbSection.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbAutho.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }


        private void Add_Account_Load(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            dataGridView1.RowTemplate.MinimumHeight = 35;
            lblID_Num.Text = LOGIN.loginuser;
            DisplayData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtIDNum.Text != "" && txtName.Text != "" && txtPass.Text != "" && txtName.Text != "" && txtDept.Text != "" && cmbSection.Text != "" && cmbAutho.Text != "" && txtEmail.Text != "")
            {
                cmd = new SqlCommand("update tbl_PSuser set ID_Number=@idnum,Password=@pass,Name=@name,Department=@dept,Section=@section,Authority=@autho,Email=@email where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@idnum", txtIDNum.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@dept", txtDept.Text);
                cmd.Parameters.AddWithValue("@section", cmbSection.Text);
                cmd.Parameters.AddWithValue("@autho", cmbAutho.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DisplayData();

            }
            else
            {
                MessageBox.Show("Please Select Record to Update!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    cmd = new SqlCommand("delete tbl_PSuser where ID=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DisplayData();

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do Nothing
                }
                else
                {
                    MessageBox.Show("Please Select Record to Delete", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void searchACC()
        {
            DataSet ds = new DataSet();
            if (cmbSearchBy.Text == "ID Number")
            {
                using (SqlConnection conn = new SqlConnection(AAA))
                {
                    string sql = "select ID, ID_Number,Password, Name, Department, Section, Authority, Email from tbl_PSuser where ID_Number like @idnum";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@idnum", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns[1].HeaderText = "ID NO.";
                    dataGridView1.Columns[2].HeaderText = "PASSWORD";
                    dataGridView1.Columns[3].HeaderText = "FULL NAME";
                    dataGridView1.Columns[4].HeaderText = "DEPARTMENT";
                    dataGridView1.Columns[5].HeaderText = "SECTION";
                    dataGridView1.Columns[6].HeaderText = "AUTHORITY";
                    dataGridView1.Columns[7].HeaderText = "EMAIL";

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (cmbSearchBy.Text == "Name")
            {
                using (SqlConnection conn = new SqlConnection(AAA))
                {
                    string sql = "select ID, ID_Number,Password, Name, Department, Section, Authority, Email from tbl_PSuser where Name like @name";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@name", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns[1].HeaderText = "ID NO.";
                    dataGridView1.Columns[2].HeaderText = "PASSWORD";
                    dataGridView1.Columns[3].HeaderText = "FULL NAME";
                    dataGridView1.Columns[4].HeaderText = "DEPARTMENT";
                    dataGridView1.Columns[5].HeaderText = "SECTION";
                    dataGridView1.Columns[6].HeaderText = "AUTHORITY";
                    dataGridView1.Columns[7].HeaderText = "EMAIL";

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (cmbSearchBy.Text == "Department")
            {
                using (SqlConnection conn = new SqlConnection(AAA))
                {
                    string sql = "select ID, ID_Number,Password, Name, Department, Section, Authority, Email from tbl_PSuser where Department like @dept";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@dept", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd); 
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns[1].HeaderText = "ID NO.";
                    dataGridView1.Columns[2].HeaderText = "PASSWORD";
                    dataGridView1.Columns[3].HeaderText = "FULL NAME";
                    dataGridView1.Columns[4].HeaderText = "DEPARTMENT";
                    dataGridView1.Columns[5].HeaderText = "SECTION";
                    dataGridView1.Columns[6].HeaderText = "AUTHORITY";
                    dataGridView1.Columns[7].HeaderText = "EMAIL";

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (cmbSearchBy.Text == "Section")
            {
                using (SqlConnection conn = new SqlConnection(AAA))
                {
                    string sql = "select ID, ID_Number, Password, Name, Department, Section, Authority, Email from tbl_PSuser where Section like @section";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@section", "%" + txtSearch.Text + "%"));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns[1].HeaderText = "ID NO.";
                    dataGridView1.Columns[2].HeaderText = "PASSWORD";
                    dataGridView1.Columns[3].HeaderText = "FULL NAME";
                    dataGridView1.Columns[4].HeaderText = "DEPARTMENT";
                    dataGridView1.Columns[5].HeaderText = "SECTION";
                    dataGridView1.Columns[6].HeaderText = "AUTHORITY";
                    dataGridView1.Columns[7].HeaderText = "EMAIL";

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            searchACC();
        }
        Label clickedLabel;
        PictureBox clickedPic;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aaa = new Admin();
            aaa.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aaa = new Admin();
            aaa.ShowDialog();
            this.Close();
        }

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

        private void btnGO1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sqlsss = "Select * from EMS_Viewing where EmpNo = '" + txtIDNum.Text + "' ";
            SqlCommand cmdsss = new SqlCommand(sqlsss, con);
            SqlDataReader sdrsss = cmdsss.ExecuteReader();
            sdrsss.Read();
            if (sdrsss.HasRows)
            {
                txtName.Text = sdrsss["Full_Name"].ToString();
                cmbSection.Text = sdrsss["Section"].ToString();
                txtDept.Text = sdrsss["Department"].ToString();
                txtEmail.Text = sdrsss["Email"].ToString();
            }

            con.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIDNum.Text = "";
            txtPass.Text = "";
            txtName.Text = "";
            txtDept.Text = "";
            cmbSection.Text = "";
            cmbAutho.Text = "";
            txtEmail.Text = "";
        }

        private void Add_Account_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Columns["ID_Number"].Width = 120;
            dataGridView1.Columns["Name"].Width = 180;
            dataGridView1.Columns["Email"].Width = 325;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aaa = new Admin();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //(e.KeyChar != '.'))
            //    {
            //        e.Handled = true;
            //    }

            //    // only allow one decimal point
            //    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //    {
            //        e.Handled = true;
            //    }
            //}
        }

        private void txtIDNum_KeyDown(object sender, KeyEventArgs e)
        {
            con.Open();
            string sqlsss = "Select * from EMS_Viewing where EmpNo = '" + txtIDNum.Text + "' ";
            SqlCommand cmdsss = new SqlCommand(sqlsss, con);
            SqlDataReader sdrsss = cmdsss.ExecuteReader();
            sdrsss.Read();
            if (sdrsss.HasRows)
            {
                txtName.Text = sdrsss["Full_Name"].ToString();
                cmbSection.Text = sdrsss["Section"].ToString();
                txtDept.Text = sdrsss["Department"].ToString();
                txtEmail.Text = sdrsss["Email"].ToString();
            }

            con.Close();
        }
    }
}

    
    

