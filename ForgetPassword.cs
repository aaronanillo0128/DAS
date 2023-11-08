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
    public partial class ForgetPassword : Form
    {
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");

        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;

        int ID = 0;
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnGO1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sqlsss = "Select * from tbl_PSUser where ID_Number = '" + txtIDNum.Text + "'";
            SqlCommand cmdsss = new SqlCommand(sqlsss, con);
            SqlDataReader sdrsss = cmdsss.ExecuteReader();
            sdrsss.Read();
            if (sdrsss.HasRows)
            {
                lblName.Text = sdrsss["Name"].ToString();
            }

            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtIDNum.Text != "" && txtPass.Text != "")
            {
                cmd = new SqlCommand("update tbl_PSuser set Password=@pass where ID_Number = '" + txtIDNum.Text + "'", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Application.Exit();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

