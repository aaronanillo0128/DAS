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
using System.Windows.Forms.DataVisualization.Charting;

namespace PS_Digital_Audit
{
    public partial class ResultSummary : Form
    {
        public static string inline1 = "";
        public static string datefrom = "";
        public static string dateto = "";
        public static string Line1 = "";
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        string cs = "Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd";
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;
        public ResultSummary()
        {
            InitializeComponent();
        }

        public void TypeAudit()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select TypeOfAudit from QA_TypeofAudit where Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "TypeOfAudit");
                cmbAuditName.DisplayMember = "TypeOfAudit";
                cmbAuditName.ValueMember = "TypeOfAudit";
                cmbAuditName.DataSource = dt.Tables["TypeOfAudit"];
                SqlDataReader reader = cmd.ExecuteReader();

            }
        }

        public void Line()
        {
            using (SqlConnection conn = new SqlConnection(AAA))
            {
                conn.Open();
                string sql = "select Line from tbl_Line where Section = '" + LOGIN.LoginSection + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtqq = new DataTable();
                sda.Fill(dtqq);
                cmbLine.Items.Clear();
                cmbLine.Items.Add("");
                cmbLine.SelectedIndex = 0;
                for (int i = 0; i < dtqq.Rows.Count; i++)
                {
                    cmbLine.Items.Add(dtqq.Rows[i]["Line"]);
                }
            }
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select COUNT(*) from tbl_ProblemSummary where TypeofAudit = '" + cmbAuditName.Text + "' AND Section = '" + LOGIN.LoginSection + "'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            txtNG.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();

        }
        private void DisplayData2()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select COUNT(*) from tbl_ProblemSummary where TypeofAudit = '" + cmbAuditName.Text + "' AND Section = '" + LOGIN.LoginSection + "' AND  Status !='Closed'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            txtOpen.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();


        }
        private void DisplayData3()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select COUNT(*) from tbl_ProblemSummary where TypeofAudit = '" + cmbAuditName.Text + "' AND Section = '" + LOGIN.LoginSection + "' AND  Status2 !='Open'", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            txtClosed.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();

        }

        private void Date()
        {

            try
            {

                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(AAA))
                {
                    using (SqlCommand cmd = new SqlCommand("FilterDate", conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            conn.Open();

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@date1", SqlDbType.DateTime).Value = DateFrom.Value.ToString("yyyy/MM/dd");
                            cmd.Parameters.Add("@date2", SqlDbType.DateTime).Value = DateTo.Value.ToString("yyyy/MM/dd"); ;
                            cmd.ExecuteNonQuery();

                            da.Fill(ds, "tbl_ProblemSummary");

                            conn.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Section_Checksheet aaa = new Section_Checksheet();
            aaa.ShowDialog();
            this.Close();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN aaa = new LOGIN();
            aaa.ShowDialog();
            this.Close();
        }
        private void ResultSummary_Load(object sender, EventArgs e)
        {
            //DisplayData();
            //DisplayData2();
            //DisplayData3();
            lblSection.Text = LOGIN.LoginSection;
          
            if (LOGIN.loginuser != null)
            {
                if (WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;
                lblIDNum.Text = LOGIN.loginuser;
                lbl_IDNum.Text = LOGIN.loginuser;
                lbl_Name.Text = LOGIN.loginName;
                lbl_Authority.Text = LOGIN.loginAutho;

                TypeAudit();
                Line();
            }

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            lblManual aaa = new lblManual();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ResultSummary_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void btnProblemSheet_Click(object sender, EventArgs e)
        {
            Line1 = lblLine.Text;
                 inline1 = lblAuditNamee.Text;
                 datefrom = DateFrom.Text;
                 dateto = DateTo.Text;
                this.Hide();
                ProblemSummaryALL asd = new ProblemSummaryALL();
                asd.ShowDialog();
                this.Close();
            
        }



        private void jeButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to PROCEED?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                //dataGridView1.Dispose();
                txtNG.Text = "";
                txtOpen.Text = "";
                txtClosed.Text = "";

                if (cmbAuditName.SelectedIndex == 0) // overALL
                {
                   
                }
                else
                {
                    if (IsnagalawBA == true)
                    {

                        string select_statement = "Select COUNT(TypeofAudit) as [TOTAL NG]  From tbl_ProblemSummary  where TypeofAudit = '" + cmbAuditName.Text + "' AND Line = '" + cmbLine.Text + "' AND Section = '" + LOGIN.LoginSection + "' AND Cast (DateEncountered as datetime) between '" + DateFrom.Value.ToString("MM/dd/yyyy") + " ' and '" + DateTo.Value.ToString("MM/dd/yyyy") + " '";
                        bool Isresult = CRUD.RETRIEVESINGLE(select_statement);
                      if (Isresult == true)
                        {
                            txtNG.Text = CRUD.dt.Rows[0]["TOTAL NG"].ToString();

                            string select_totalOpen= "Select COUNT(TypeofAudit) as [TOTAL OPEN]  From tbl_ProblemSummary  where TypeofAudit = '" + cmbAuditName.Text + "' AND Line = '" + cmbLine.Text + "' AND Section = '" + LOGIN.LoginSection + "' AND Cast (DateEncountered as datetime) between '" + DateFrom.Value.ToString("MM/dd/yyyy") + " ' and '" + DateTo.Value.ToString("MM/dd/yyyy") + "' AND  Status !='Closed'";
                            CRUD.RETRIEVESINGLE(select_totalOpen);
                            txtOpen.Text = CRUD.dt.Rows[0]["TOTAL OPEN"].ToString();

                            string select_totalClose = "Select COUNT(TypeofAudit) as [TOTAL close]  From tbl_ProblemSummary  where TypeofAudit = '" + cmbAuditName.Text + "' AND Line = '" + cmbLine.Text + "' AND Section = '" + LOGIN.LoginSection + "' AND Cast (DateEncountered as datetime) between '" + DateFrom.Value.ToString("MM/dd/yyyy") + " ' and '" + DateTo.Value.ToString("MM/dd/yyyy") + "' AND  Status2 !='Open'";
                            CRUD.RETRIEVESINGLE(select_totalClose);
                            txtClosed.Text = CRUD.dt.Rows[0]["TOTAL close"].ToString();

                            IsnagalawBA = false;
                        }
                        else { MessageBox.Show("No Data available on filtered Date", "PS-AUDIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNG.Text = "0";
                            txtNG.Text = "0";
                            txtNG.Text = "0";

                        }                    
                    }
                    else
                    {
                        DisplayData();
                        DisplayData2();
                        DisplayData3();
                    }
                }
                foreach(Series aaron in chart1.Series)
                {
                    aaron.Points.Clear();
                }

                int x1 = Convert.ToInt32(txtOpen.Text);
                int x2 = Convert.ToInt32(txtClosed.Text);
                int x3 = Convert.ToInt32(txtNG.Text);

                DataPoint point = new DataPoint();
                point.SetValueXY("Total NG", x3);

                point.ToolTip = string.Format("{0} : {1}", "Total NG", x3);
                chart1.Series[0].Points.Add(point);
                chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].Color = Color.Red;

                DataPoint point1 = new DataPoint();
                point1.SetValueXY("Open", x1);
                point1.ToolTip = string.Format("{0} : {1}", "Open", x1);
                chart1.Series[0].Points.Add(point1);
                chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].Color = Color.Green;

                DataPoint point2 = new DataPoint();
                point2.SetValueXY("Closed", x2);
                point2.ToolTip = string.Format("{0} : {1}", "Closed", x2);
                chart1.Series[0].Points.Add(point2);
                chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].Color = Color.Gray;

                var chart = chart1.ChartAreas[0];
           
                chart.AxisX.LabelStyle.Format = "";
                chart.AxisY.LabelStyle.Format = "";
                chart.AxisX.LabelStyle.IsEndLabelVisible = true;

                chart.AxisX.Interval = 1;
                chart.AxisY.Interval = 3;


                chart1.Series["Total NG"].ChartType = SeriesChartType.Column;
                chart1.Series["Total NG"].Color = Color.Red;
                chart1.Series["Total NG"].IsVisibleInLegend = true;

                chart1.Series["Open"].ChartType = SeriesChartType.Column;
                chart1.Series["Open"].Color = Color.Green;
                chart1.Series["Open"].IsVisibleInLegend = true;

                chart1.Series["Closed"].ChartType = SeriesChartType.Column;
                chart1.Series["Closed"].Color = Color.DarkGray;
                chart1.Series["Closed"].IsVisibleInLegend = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do Nothing
            }
           
        }
        private void picRefresh_Click(object sender, EventArgs e)
        {
            this.Close();
            ResultSummary aaa = new ResultSummary();
            aaa.ShowDialog();
        }
        PictureBox clickedPicture;
        private void picRefresh_MouseEnter(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != clickedPicture)
                theLabel.BackColor = Color.LightBlue;
        }

        private void picRefresh_MouseLeave(object sender, EventArgs e)
        {
            PictureBox theLabel = (PictureBox)sender;
            if (theLabel != clickedPicture)
                theLabel.BackColor = Color.White;
        }
        bool IsnagalawBA = false;
        private void DateFrom_ValueChanged(object sender, EventArgs e)
        {
            IsnagalawBA = true;
            dateF.Text = DateFrom.Text; 

        }

        private void jeButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResultSummary aaa = new ResultSummary();
            aaa.ShowDialog();
            this.Close();
        }

        private void DateTo_ValueChanged(object sender, EventArgs e)
        {
            IsnagalawBA = true;
            dateT.Text = DateTo.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbAuditName.SelectedIndex != 0)
            {
                DateFrom.Enabled = true;
                DateTo.Enabled = true;
            }
            else
            {
                DateFrom.Enabled = false;
                DateTo.Enabled = false;
            }
        }

        private void cmbAuditName_TextChanged(object sender, EventArgs e)
        {
            Panel.Text = cmbAuditName.Text;
            lblAuditNamee.Text = cmbAuditName.Text;
        }

        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbLine_TextChanged(object sender, EventArgs e)
        {
            lblLine.Text = cmbLine.Text;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResultSummary eron = new ResultSummary();
            eron.ShowDialog();
        }
    }
    }


