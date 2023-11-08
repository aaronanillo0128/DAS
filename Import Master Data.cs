using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;

namespace PS_Digital_Audit
{
    public partial class Import_Master_Data : Form
    {

        static string BBB = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=SystemTest;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");

        int ID = 0;
        SqlDataAdapter adapt;
        SqlCommand cmd;
      //  DataTable dt;
        public Import_Master_Data()
        {
            InitializeComponent();
        }
        public void Checksheet()
        {
            using (SqlConnection conn = new SqlConnection(BBB))
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

        private void jeButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN aaa = new LOGIN();
            aaa.ShowDialog();
            this.Close();
        }


        // this method will read the excel file and copy its data into a datatable
        //private DataTable ReadExcel(string fileName)
        //{
        //    WorkBook workbook = WorkBook.Load(fileName);
        //    WorkSheet sheet = workbook.DefaultWorkSheet;
        //    return sheet.ToDataTable(true);
        //}
        string fileExt;
        string filePath;
        // this method will choose and read the excel file
        //SqlConnection conn = new SqlConnection("Data Source=apbiph1131;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        private void button6_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();//open dialog to choose file
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)//if there is a file choosen by the user
            {
               filePath = file.FileName;//get the path of the file
               fileExt = Path.GetExtension(filePath);//get the file extension
                lblFileName.Text = filePath;
                lblFileName.Text = lblFileName.Text.Replace(".xlsx.xlsx", ".xlsx").Replace(".xls.xls", ".xls");



                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                      LoadExcel();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);//custom messageBox to show error
                }
            }
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;

            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xlsx") == 0)//compare the extension of the file
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + lblFileName.Text + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + lblFileName.Text + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007
            using (OleDbConnection con = new OleDbConnection(conn))
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    string Sheet1 = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();

                    Sheet1 = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [" + Sheet1 + "]  WHERE Version is NOT NULL ", con);//here we read data from sheet1
                    oleAdpt.Fill(dtexcel);//fill excel data into dataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            return dtexcel;
        }// end ReadExcel
        DataTable dtExcel;

        private void LoadExcel()
        {
            dtExcel = ReadExcel(filePath, fileExt);//read excel file
            dataGridView1.Invoke(new Action(() => dataGridView1.Visible = true));
            dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = dtExcel));
        }
        string checker;
        private void btnUploadMaster_Click(object sender, EventArgs e)

        {
           
                string constring = @"Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd";
                SqlConnection con = new SqlConnection(constring);

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();
                string deleteold = "Delete tbl_MasterAudit where Section = '" + LOGIN.LoginSection + "' AND TypeofAudit = '" + cmbChecksheet.Text + "'";
                CRUD.CUD(deleteold);


                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[tbl_MasterAudit] (ChecksheetNo,Version,Series,Model,Process,AssuranceItem,Classification,CheckItems,TypeofAudit,Section) Values (@checksheetno, @version, @series, @model, @Process, @AssuranceItem, @Classification, @Checkitems, @typeaudit, @section)", con))

                        {
                            //dataGridView2.Location = new Point(100, 100);
                            //dataGridView1.Visible = true;
                            //int CkNum = (int.Parse(row.Cells["Checksheet No."].Value.ToString()));
                            //checker = CkNum + row.Cells[7].Value.ToString() + row.Cells[5].Value.ToString() + row.Cells[6].Value.ToString() + row.Cells[7].Value.ToString();
                            //cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@checksheetno", row.Cells["ChecksheetNo"].Value.ToString());

                            cmd.Parameters.AddWithValue("@version", row.Cells["Version"].Value.ToString());
                            cmd.Parameters.AddWithValue("@series", row.Cells["Series"].Value.ToString());
                            cmd.Parameters.AddWithValue("@model", row.Cells["Model"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Process", row.Cells["Area/Process"].Value.ToString());
                            cmd.Parameters.AddWithValue("@AssuranceItem", row.Cells["Safety important assurance item"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Classification", row.Cells["Classification"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Checkitems", row.Cells["Checkitems"].Value.ToString());
                            cmd.Parameters.AddWithValue("@typeaudit", row.Cells["Audit Name"].Value.ToString());
                            cmd.Parameters.AddWithValue("@section", row.Cells["Section"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }

                    }

                
            
           
                    using (SqlCommand cmd2 = new SqlCommand("INSERT INTO tbl_Version (ChecksheetName,Version,[Revision Date],UploadedTime,UploadedBy) Values(@checksheetname, @version, @revdate, @uploadedtime, @uploadedby)", con))
                    {
                        DateTime currentTime = DateTime.Now;
                        string timeString = currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                        cmd2.Parameters.AddWithValue("@ID", ID);
                        cmd2.Parameters.AddWithValue("@checksheetname", cmbChecksheet.Text);
                        cmd2.Parameters.AddWithValue("@version", tbVersion.Text);
                        cmd2.Parameters.AddWithValue("@revdate", dtRevDate.Text);
                        cmd2.Parameters.AddWithValue("@uploadedtime", timeString.ToString());
                        cmd2.Parameters.AddWithValue("@uploadedby", lbl_Name.Text);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        DisplayData();
                    }


                    MessageBox.Show("Uploaded Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        
                else if (dialogResult == DialogResult.No)
                {
                    //do Nothing
                }
           
                con.Close();
           
        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
            con.Open();
            DataTable dt1 = new DataTable();
            adapt = new SqlDataAdapter("select ChecksheetName, Version, Model, [Revision Date], UploadedTime, UploadedBy from tbl_Version order by ID desc", con);
            adapt.Fill(dt1);
            dataGridView2.DataSource = dt1;
            con.Close();

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView2.AllowUserToResizeColumns = true;
            dataGridView2.AllowUserToOrderColumns = true;

            this.dataGridView2.DefaultCellStyle.Font = new Font("Calibri", 9);
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
            dataGridView2.EnableHeadersVisualStyles = false;

        }
        private void Import_Master_Data_Load(object sender, EventArgs e)
        {
            DisplayData();
            Checksheet();
            dtRevDate.Text = "";
            this.dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 11);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
           
            if (LOGIN.loginuser != null)
            {
                if (WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;
                lblIDNum.Text = LOGIN.loginuser;
                lbl_IDNum.Text = LOGIN.loginuser;
                lbl_Name.Text = LOGIN.loginName;
                lbl_Position.Text = LOGIN.loginAutho;
            }
            if (lbl_Position.Text != "Engineer" && lbl_Position.Text != "Supervisor" && lbl_Position.Text != "Manager" && lbl_Position.Text != "AdminENG" && lbl_Position.Text != "AdminSPV" && lbl_Position.Text != "AdminMGR")
            {
                button6.Enabled = false;
            }
        }

        private void button6_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        private void Import_Master_Data_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void jeButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("delete from tbl_MasterAudit where AuditID = ''");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DisplayData();

            }
            else if (dialogResult == DialogResult.No)
            {
                //do Nothing
            }
        }

        private void btnEditMaster_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditMasterData aaa = new EditMasterData();
            aaa.ShowDialog();
            this.Close();
        }
    }
    }





