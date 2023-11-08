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
    public partial class AuditLookUp : Form
    {
        public static AuditLookUp _instance;
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;
        public AuditLookUp()
        {
            _instance = this;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AuditLookUp_Load(object sender, EventArgs e)
        {
            
            if (LOGIN.loginAutho == "Auditor")
            {
                btnSave.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void AuditLookUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("update tbl_MasterAudit set AssuranceItem=@assuranceitem, Classification=@classification, CheckItems=@checkitems, Version=@version where ID = '" + lblID.Text + "'", con);
                con.Open();
                //cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@assuranceitem", txtAssurance.Text);
                cmd.Parameters.AddWithValue("@classification", txtClassification.Text);
                cmd.Parameters.AddWithValue("@checkitems", txtCheckItems.Text);
                cmd.Parameters.AddWithValue("@version", txtVersion.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                EditMasterData._instance.refreshdata();
                this.Close();
            }
           catch(Exception ex)
            {

            }
        }
    }
}
