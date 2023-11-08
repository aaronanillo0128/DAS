using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Reflection;
using System.IO;
using Microsoft.Win32;

namespace PS_Digital_Audit
{
    public partial class LOGIN : Form
    {
        public static string loginuser = "";
        public static string loginName = "";
        public static string loginAutho = "";
        public static string LoginSection = "";
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");


        public void UserVerification()
        {

            if (txtIDNum.Text == "" && txtPass.Text == "")
            {
                Application.ExitThread();
            }
            else if (txtIDNum.Text == "")
            {
                MessageBox.Show("ID Number Required!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDNum.Focus();
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("Password Required!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
            }
            else
            {              
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tbl_PSuser WHERE ID_Number='" + txtIDNum.Text + "' AND Password = '" + txtPass.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("select * from tbl_PSuser where ID_Number ='" + txtIDNum.Text + "' AND Password = '" + txtPass.Text + "'", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                       

                        string login_user;
                        string login_name;
                        string autho;
                        string Section;

                        login_user = reader[1].ToString();
                        login_name = reader[3].ToString();
                        autho = reader[6].ToString();
                        Section = reader[5].ToString();

                        loginuser = login_user;
                        loginName = login_name;
                        loginAutho = autho;
                        LoginSection = Section;
                       
                    }
                    this.Hide();
                    new lblManual().Show();
                }             
                else
                {

                    MessageBox.Show("Invalid Password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Text = "";
                    txtPass.Focus();
                    con.Close();
                }
            }      
            }
                   
        public LOGIN()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true); key.SetValue("sShortDate", "MM/dd/yyyy");
            InitializeComponent();
        }

        private void jeButton1_Click(object sender, EventArgs e)
        {
            txtIDNum.Text = "";
            txtPass.Text = "";
        }
        static string PSAudit = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        private void LOGIN_Load(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

            database.Text = PSAudit.Replace("Persist Security Info=True;User ID=saa;Password=P@ssw0rd", "");
            database.Text = database.Text.Replace("Data Source=", "  Server Name: ");
            database.Text = database.Text.Replace(";Initial Catalog=", "    Database: ");
            version.Text = "AA." + Assembly.GetExecutingAssembly().GetName().Version.ToString();


            
        }

        private void jebtnOK_Click_2(object sender, EventArgs e)
        {
            //string sourcePath = "\\apbiphsh04\\B1_BIPHCommon\\14_QA\\QA\\DigitalAuditUpdatedCamera\\CAMERA-QAPS";
            //string targetPath = "C:\\CAMERA-QAPS";
            //string fileName = string.Empty;
            //string destFile = string.Empty;

            //// To copy all the files in one directory to another directory. 
            //// Get the files in the source folder. (To recursively iterate through 
            //// all subfolders under the current directory, see 
            //// "How to: Iterate Through a Directory Tree.")
            //// Note: Check for target path was performed previously 
            ////       in this code example. 
            //if (System.IO.Directory.Exists(sourcePath))
            //{
            //    string[] files = System.IO.Directory.GetFiles(sourcePath);

            //    // Copy the files and overwrite destination files if they already exist. 
            //    foreach (string s in files)
            //    {
            //        // Use static Path methods to extract only the file name from the path.
            //        fileName = System.IO.Path.GetFileName(s);
            //        destFile = System.IO.Path.Combine(targetPath, fileName);
            //        System.IO.File.Copy(s, destFile, true);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Source path does not exist!");
            //}
            //string sourceLoc = @"\\apbiphsh04\B1_BIPHCommon\14_QA\QA\DigitalAuditUpdatedCamera\CAMERA-QAPS";
            //string destLoc = @"C:\CAMERA-QAPS";

            //foreach (string dirPath in Directory.GetDirectories(sourceLoc, "*", SearchOption.AllDirectories))
            //{
            //    Directory.CreateDirectory(dirPath.Replace(sourceLoc, destLoc));
            //    try
            //    {
            //        if (Directory.Exists(sourceLoc))
            //        {
            //            //eto copy all files
            //            foreach (string newPath in Directory.GetFiles(sourceLoc, "*.*", SearchOption.AllDirectories))
            //                File.Copy(newPath, newPath.Replace(sourceLoc, destLoc), true);
            //        }
            //    }catch
            //    {

            //    }
                
            

            UserVerification();
        }

        private void ShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '•')
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '•';
            }

            ShowPassword.SendToBack();
            HidePassword.BringToFront();
        }

        private void HidePassword_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '•')
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '•';
            }

            ShowPassword.BringToFront();
            HidePassword.SendToBack();
        }

        private void LOGIN_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtIDNum_Enter(object sender, EventArgs e)
        {
            //if (txtIDNum.Text == "BIPH2021-00000")
            //{
            //    txtIDNum.Text = "";
            //    txtIDNum.ForeColor = Color.FromArgb(26, 44, 47);
            //}
        }

        private void txtIDNum_Leave(object sender, EventArgs e)
        {
            //if (txtIDNum.Text == "")
            //{
            //    txtIDNum.Text = "BIPH2021-00000";
            //    txtIDNum.ForeColor = Color.DarkGray;
            //}
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            //if (txtPass.Text == "")
            //{
            //    txtPass.Text = "Password";
            //    txtPass.ForeColor = Color.DarkGray;
            //    txtPass.PasswordChar = '\0';
            //}
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            //if (txtPass.Text == "Password")
            //{
            //    txtPass.Text = "";
            //    txtPass.ForeColor = Color.FromArgb(26, 44, 47);
            //}
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPass.PasswordChar = '•';
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblForgetPass_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgetPassword aaa = new ForgetPassword();
            aaa.ShowDialog();
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtIDNum.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }
        PictureBox clickedLabel;
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.White;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.LightBlue;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.White;
        }

        private void txtIDNum_TextChanged(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }
    }
}
