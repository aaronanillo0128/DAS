using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_Digital_Audit
{
   
    public partial class ProbSumLookup : Form
    {
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;

        int ID = 0;
        public ProbSumLookup()
        {
            InitializeComponent();
        }

        private void ProbSumLookup_Load(object sender, EventArgs e)
        {
                lblLink.Text = @"\\apbiphsh07\D0_ShareBrotherGroup\19_BPS\Installer\PSAudit\CapturedImage\" + LOGIN.LoginSection + "\\" + LOGIN.loginuser + "\\" + txt_AuditID.Text + "\\";

            if(cmbStatus.Text == "CLOSED")
            {
                txt_Counter.Enabled = false;
                cmbStatus.Enabled = false;
                txt_Cause.Enabled = false;
                date.Enabled = false;
                date2.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_Cause.Text != "" && txt_Counter.Text != "" && cmbStatus.Text != "")
            {
                cmd = new SqlCommand("update tbl_ProblemSummary set Cause=@cause, Countermeasure=@cm, Status=@status, Status2=@status2, ActualDateClosure=@adc, TargetDateClosure=@tdc where AuditID= '"+txt_AuditID.Text+"' AND ChecksheetNo = '" + txtChecksheetNo.Text + "' AND Frequency = '" + txtFreq.Text + "'", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@cause", txt_Cause.Text);
                cmd.Parameters.AddWithValue("@cm", txt_Counter.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@status2", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@adc", date.Text);
                cmd.Parameters.AddWithValue("@tdc", date2.Text);

                cmd.ExecuteNonQuery(); 
                con.Close();
                MessageBox.Show("Record Updated Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


               //ProblemSummary._instance.refreshdata();
               //ProblemSummaryALL._instance.refreshdata();

                this.Close();
            }
            else
            {
                MessageBox.Show("Please input details to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        Label clickedLabel;
        private void lblLink_MouseEnter(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.LightBlue;
        }

        private void lblLink_MouseLeave(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.FromArgb(235, 255, 225);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //ProblemSummary aaa = new ProblemSummary();
            //aaa.ShowDialog();
            this.Close();
        }

        private void lblLink_Click(object sender, EventArgs e)
        {
          
        }

        private void jeButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(lblLink.Text);
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void ProbSumLookup_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }
    }
    }

