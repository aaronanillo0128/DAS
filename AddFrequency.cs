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
    public partial class AddFrequency : Form
    {
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;
        public AddFrequency()
        {
            InitializeComponent();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select Frequency from tbl_Frequency where Section = '" + LOGIN.LoginSection + "'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.Columns[0].HeaderText = "FREQUENCY";

        }

        private void AddSeries_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Columns["Frequency"].Width = 349;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtFrequency.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtModel2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void jebtnAdd_Click(object sender, EventArgs e)
        {
            if (txtFrequency.Text != "")
            {
                cmd = new SqlCommand("insert into tbl_Frequency (Frequency,Section) Values (@frequency,@section)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@frequency", txtFrequency.Text);
                cmd.Parameters.AddWithValue("@section", LOGIN.LoginSection);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DisplayData();
                //string SElectDouble_SQL = string.Empty;
                //SElectDouble_SQL = "SELECT Frequency from tbl_Frequency where Frequency = '" + txtFrequency.Text + "'";
                //bool DoubleData = false;
                //DoubleData = CRUD.RETRIEVESINGLE(SElectDouble_SQL);
                //if (DoubleData == true)
                //{
                //    MessageBox.Show("DUPLICATE ENTRY DETECTED!", "Digital Audit System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                { 

                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFrequency.Text != "")
            {
                cmd = new SqlCommand("update tbl_Frequency set Frequency=@frequency where Frequency = '" + txtModel2.Text + "'", con);
                con.Open();
                cmd.Parameters.AddWithValue("@frequency", txtFrequency.Text);
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("delete tbl_Frequency where Frequency=@frequency", con);
                con.Open();
                cmd.Parameters.AddWithValue("@frequency", txtFrequency.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DisplayData();
                txtFrequency.Text = "";

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
