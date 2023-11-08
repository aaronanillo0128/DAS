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
using System.Net.Mail;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.IO;
using System.Data.Odbc;

namespace PS_Digital_Audit
{
    public partial class Audit_Checksheet : Form
    {
        public static string version = "";
        public static string update = "";
      
        static string AAA = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;
        private Button currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;


        int ID = 0;
        public Audit_Checksheet()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select TOP (1) ID, Version, Model, [Revision Date] from tbl_Version order by ID desc", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            lblVer.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            lblRevDate.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
        }

        private void ClearData()
        {
          
            ID = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

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
            Application.Exit();
        }

        private void jeButton5_Click(object sender, EventArgs e)
        {
           
        }    
        private void Audit_Checksheet_Load(object sender, EventArgs e)
        {
            DisplayData();
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

            if (LOGIN.loginuser != null)
            {
             
                lbl_IDNum.Text = LOGIN.loginuser;
                lbl_Name.Text = LOGIN.loginName;
                lbl_Position.Text = LOGIN.loginAutho;
                //lblIDNum.Text = LOGIN.loginuser;

            }

            lblLine.Text = PSCategory.line;
            lblShift.Text = PSCategory.shift;
            lblSeries.Text = PSCategory.series;
            lblDetails.Text = PSCategory.process;
            lblDetails2.Text = PSCategory.model;
            lblDetails3.Text = PSCategory.freq;
            lblAuditID.Text = PSCategory.AuditID;
           

            //if (lblDetails.Text == "Engine Assemble")
            //{
            //    btnSelectProcess.Text = "Engine Assemble".ToString();
            //}
            //else if (lblDetails.Text == "Engine Checker")
            //{
            //    btnSelectProcess.Text = "Engine Checker".ToString();
            //}
            //else if (lblDetails.Text == "Final Inspection")
            //{
            //    btnSelectProcess.Text = "Final Inspection".ToString();
            //}
            //else if (lblDetails.Text == "Ink Head")
            //{
            //    btnSelectProcess.Text = "Ink Head".ToString();
            //}
            //else if (lblDetails.Text == "Ink Refill")
            //{
            //    btnSelectProcess.Text = "Ink Refill".ToString();  
            //}
            //else if (lblDetails.Text == "Safety Checker")
            //{
            //    btnSelectProcess.Text = "Safety Checker".ToString();
            //}
            //else if (lblDetails.Text == "Single AC")
            //{
            //    btnSelectProcess.Text = "Single AC".ToString();
            //}
            //else if (lblDetails.Text == "Sub-Unit")
            //{
            //    btnSelectProcess.Text = "Sub-Unit".ToString();
            //}
            //else if (lblDetails.Text == "Power Supply")
            //{
            //    btnSelectProcess.Text = "Power Supply".ToString();
            //}
            //else if (lblDetails.Text == "Main Assy")
            //{
            //    btnSelectProcess.Text = "Main Assy".ToString();
            //}
            //else if (lblDetails.Text == "Thermal Head")
            //{
            //    btnSelectProcess.Text = "Thermal Head".ToString();
            //}
            //else if (lblDetails.Text == "Cutter/Motor")
            //{
            //    btnSelectProcess.Text = "Cutter/Motor".ToString();
            //}
            //else if (lblDetails.Text == "Label Preparation")
            //{
            //    btnSelectProcess.Text = "Label Preparation".ToString();
            //}
            //else if (lblDetails.Text == "Hi pot Checking")
            //{
            //    btnSelectProcess.Text = "Hi pot Checking".ToString();
            //}
            //else if (lblDetails.Text == "VP Preparation")
            //{
            //    btnSelectProcess.Text = "VP Preparation".ToString();
            //}
            //else if (lblDetails.Text == "Kitting")
            //{
            //    btnSelectProcess.Text = "Kitting".ToString();
            //}
            //else if (lblDetails.Text == "Inspection 2")
            //{
            //    btnSelectProcess.Text = "Inspection 2".ToString();
            //}
            //else if (lblDetails.Text == "Maintenance")
            //{
            //    btnSelectProcess.Text = "Maintenance".ToString();
            //}
            //else if (lblDetails.Text == "Engine assemble")
            //{
            //    btnSelectProcess.Text = "Engine assemble".ToString();
            //}
            //else if (lblDetails.Text == "Scanner")
            //{
            //    btnSelectProcess.Text = "Scanner".ToString();
            //}
            //else if (lblDetails.Text == "Engine checker")
            //{
            //    btnSelectProcess.Text = "Engine checker".ToString();
            //}
            //else if (lblDetails.Text == "Mainbody")
            //{
            //    btnSelectProcess.Text = "Mainbody".ToString();
            //}
            //else if (lblDetails.Text == "Sub-unit")
            //{
            //    btnSelectProcess.Text = "Sub-unit".ToString();
            //}
            //else if (lblDetails.Text == "Ptouch")
            //{
            //    btnSelectProcess.Text = "Ptouch".ToString();
            //}
            //else if (lblDetails.Text == "EN")
            //{
            //    btnSelectProcess.Text = "EN".ToString();
            //}
            //else if (lblDetails.Text == "ME")
            //{
            //    btnSelectProcess.Text = "ME".ToString();
            //}
            //else if (lblDetails.Text == "PA")
            //{
            //    btnSelectProcess.Text = "PA".ToString();
            //}
            //else if (lblDetails.Text == "SC")
            //{
            //    btnSelectProcess.Text = "SC".ToString();
            //}
            //else if (lblDetails.Text == "SU")
            //{
            //    btnSelectProcess.Text = "SU".ToString();
            //}
            //else if (lblDetails.Text == "HO")
            //{
            //    btnSelectProcess.Text = "HO".ToString();
            //}
            //else if (lblDetails.Text == "EC")
            //{
            //    btnSelectProcess.Text = "EC".ToString();
            //}
            //else if (lblDetails.Text == "FG")
            //{
            //    btnSelectProcess.Text = "FG".ToString();
            //}
            //else if (lblDetails.Text == "FI")
            //{
            //    btnSelectProcess.Text = "FI".ToString();
            //}
            //else if (lblDetails.Text == "KO")
            //{
            //    btnSelectProcess.Text = "KO".ToString();
            //}
            //else if (lblDetails.Text == "Refill")
            //{
            //    btnSelectProcess.Text = "Refill".ToString();
            //}
            //else if (lblDetails.Text == "Kitting")
            //{
            //    btnSelectProcess.Text = "Kitting".ToString();
            //}
            //else if (lblDetails.Text == "Tool Cartridge / Washing")
            //{
            //    btnSelectProcess.Text = "Tool Cartridge / Washing".ToString();
            //}
            //else if (lblDetails.Text == "Parts Labelling")
            //{
            //    btnSelectProcess.Text = "Parts Labelling".ToString();
            //}
            //else if (lblDetails.Text == "Parts Storing")
            //{
            //    btnSelectProcess.Text = "Parts Storing".ToString();
            //}
            //else if (lblDetails.Text == "Parts Issuance")
            //{
            //    btnSelectProcess.Text = "Parts Issuance".ToString();
            //}
            //else if (lblDetails.Text == "Parts Splicing")
            //{
            //    btnSelectProcess.Text = "Parts Splicing".ToString();
            //}
            //else if (lblDetails.Text == "SPD Setup")
            //{
            //    btnSelectProcess.Text = "SPD Setup".ToString();
            //}
            //else if (lblDetails.Text == "VCA Verification")
            //{
            //    btnSelectProcess.Text = "VCA Verification".ToString();
            //}
            //else if (lblDetails.Text == "Repair Process")
            //{
            //    btnSelectProcess.Text = "Repair Process".ToString();
            //}
            //else if (lblDetails.Text == "Repair Verification")
            //{
            //    btnSelectProcess.Text = "Repair Verification".ToString();
            //}
            //else if (lblDetails.Text == "Laser Marking")
            //{
            //    btnSelectProcess.Text = "Laser Marking".ToString();
            //}
            //else if (lblDetails.Text == "Cutting and Forming")
            //{
            //    btnSelectProcess.Text = "Cutting and Forming".ToString();
            //}
            //else if (lblDetails.Text == "Auto ROM Writing")
            //{
            //    btnSelectProcess.Text = "Auto ROM Writing".ToString();
            //}
            //else if (lblDetails.Text == "Attachment")
            //{
            //    btnSelectProcess.Text = "Attachment".ToString();
            //}
            //else if (lblDetails.Text == "Removal and Visual Inspection")
            //{
            //    btnSelectProcess.Text = "Removal and Visual Inspection".ToString();
            //}
            //else if (lblDetails.Text == "Cutting")
            //{
            //    btnSelectProcess.Text = "Cutting".ToString();
            //}
            //else if (lblDetails.Text == "Manual Insertion")
            //{
            //    btnSelectProcess.Text = "Manual Insertion".ToString();
            //}
            //else if (lblDetails.Text == "Visual Inspection 1 (Before Wave)")
            //{
            //    btnSelectProcess.Text = "Visual Inspection 1 (Before Wave)".ToString();
            //}
            //else if (lblDetails.Text == "Unloader")
            //{
            //    btnSelectProcess.Text = "Unloader".ToString();
            //}
            //else if (lblDetails.Text == "PI Soldering with Visual Inspection")
            //{
            //    btnSelectProcess.Text = "PI Soldering with Visual Inspection".ToString();
            //}
            //else if (lblDetails.Text == "PI Soldering")
            //{
            //    btnSelectProcess.Text = "PI Soldering".ToString();
            //}
            //else if (lblDetails.Text == "Visual Inspection 2 (After Wave)")
            //{
            //    btnSelectProcess.Text = "Visual Inspection 2 (After Wave)".ToString();
            //}
            //else if (lblDetails.Text == "Manual Soldering")
            //{
            //    btnSelectProcess.Text = "Manual Soldering".ToString();
            //}
            //else if (lblDetails.Text == "Heatsink Attachment")
            //{
            //    btnSelectProcess.Text = "Heatsink Attachment".ToString();
            //}
            //else if (lblDetails.Text == "Easy Inspection")
            //{
            //    btnSelectProcess.Text = "Easy Inspection".ToString();
            //}
            //else if (lblDetails.Text == "Label Attachment")
            //{
            //    btnSelectProcess.Text = "Label Attachment".ToString();
            //}
            //else if (lblDetails.Text == "ICT")
            //{
            //    btnSelectProcess.Text = "ICT".ToString();
            //}
            //else if (lblDetails.Text == "FCT")
            //{
            //    btnSelectProcess.Text = "FCT".ToString();
            //}
            //else if (lblDetails.Text == "Final Visual Inspection")
            //{
            //    btnSelectProcess.Text = "Final Visual Inspection".ToString();
            //}
            //else if (lblDetails.Text == "PCB Separator and Manual Insertion")
            //{
            //    btnSelectProcess.Text = "PCB Separator and Manual Insertion".ToString();
            //}
            //else if (lblDetails.Text == "Point Solder")
            //{
            //    btnSelectProcess.Text = "Point Solder".ToString();
            //}
            //else if (lblDetails.Text == "VIsual Inspection and FCT")
            //{
            //    btnSelectProcess.Text = "VIsual Inspection and FCT".ToString();
            //}
            //else if (lblDetails.Text == "PCB Status and Storage")
            //{
            //    btnSelectProcess.Text = "PCB Status and Storage".ToString();
            //}
            //else if (lblDetails.Text == "Manual Soldering Repair Process")
            //{
            //    btnSelectProcess.Text = "Manual Soldering Repair Process".ToString();
            //}
            //else if (lblDetails.Text == "BGA Machine Repair Process")
            //{
            //    btnSelectProcess.Text = "BGA Machine Repair Process".ToString();
            //}
            //else if (lblDetails.Text == "SD Machine Repair Process")
            //{
            //    btnSelectProcess.Text = "SD Machine Repair Process".ToString();
            //}
            //else if (lblDetails.Text == "Delivery")
            //{
            //    btnSelectProcess.Text = "Delivery".ToString();
            //}
            //else if (lblDetails.Text == "DC MINI13/15LOW")
            //{
            //    btnSelectProcess.Text = "DC MINI13/15LOW".ToString();
            //}
            //else if (lblDetails.Text == "DC MINI15STEP")
            //{
            //    btnSelectProcess.Text = "DC MINI15STEP".ToString();
            //}
            //else if (lblDetails.Text == "SUB HOLDER MINI15LOW")
            //{
            //    btnSelectProcess.Text = "SUB HOLDER MINI15LOW".ToString();
            //}
            //else if (lblDetails.Text == "SUB HOLDER MINI15/19STEP")
            //{
            //    btnSelectProcess.Text = "SUB HOLDER MINI15/19STEP".ToString();
            //}
            //else if (lblDetails.Text == "SUB HOLDER BHM17/BHM17HT/MB19")
            //{
            //    btnSelectProcess.Text = "SUB HOLDER BHM17/BHM17HT/MB19".ToString();
            //}
            //else if (lblDetails.Text == "BE_A_MINI15LOW")
            //{
            //    btnSelectProcess.Text = "BE_A_MINI15LOW".ToString();
            //}
            //else if (lblDetails.Text == "BE_B_MINI13/15LOW")
            //{
            //    btnSelectProcess.Text = "BE_B_MINI13/15LOW".ToString();
            //}
            //else if (lblDetails.Text == "BE_C_MINI15LOW")
            //{
            //    btnSelectProcess.Text = "BE_C_MINI15LOW".ToString();
            //}
            //else if (lblDetails.Text == "BE_D1_MINI15/19STEP")
            //{
            //    btnSelectProcess.Text = "BE_D1_MINI15/19STEP".ToString();
            //}
            //else if (lblDetails.Text == "BE_D2_MINI15/19STEP")
            //{
            //    btnSelectProcess.Text = "BE_D2_MINI15/19STEP".ToString();
            //}
            //else if (lblDetails.Text == "BE_E_BHM17/BHM17HT/MB19")
            //{
            //    btnSelectProcess.Text = "BE_E_BHM17/BHM17HT/MB19".ToString();
            //}
            //else if (lblDetails.Text == "DC BHM17/BHM17HT/MB19")
            //{
            //    btnSelectProcess.Text = "DC BHM17/BHM17HT/MB19".ToString();
            //}
            //else if (lblDetails.Text == "All Operators")
            //{
            //    btnSelectProcess.Text = "All Operators".ToString();
            //}
            //else if (lblDetails.Text == "Joint Rubber Assembly")
            //{
            //    btnSelectProcess.Text = "Joint Rubber Assembly".ToString();
            //}
            //else if (lblDetails.Text == "Reverse pallet inspection")
            //{
            //    btnSelectProcess.Text = "Reverse pallet inspection".ToString();
            //}
            //else if (lblDetails.Text == "Offline Airblowing")
            //{
            //    btnSelectProcess.Text = "Offline Airblowing".ToString();
            //}
            //else if (lblDetails.Text == "Joint Cap Pressing (Cell 1)")
            //{
            //    btnSelectProcess.Text = "Joint Cap Pressing (Cell 1)".ToString();
            //}
            //else if (lblDetails.Text == "Joint Cap Pressing (Cell 2)")
            //{
            //    btnSelectProcess.Text = "Joint Cap Pressing (Cell 2)".ToString();
            //}
            //else if (lblDetails.Text == "Joint Cap Pressing (Cell 3)")
            //{
            //    btnSelectProcess.Text = "Joint Cap Pressing (Cell 3)".ToString();
            //}
            //else if (lblDetails.Text == "Joint Cap Pressing (Cell 4)")
            //{
            //    btnSelectProcess.Text = "Joint Cap Pressing (Cell 4)".ToString();
            //}
            //else if (lblDetails.Text == "Film Welding Area Floor")
            //{
            //    btnSelectProcess.Text = "Film Welding Area Floor".ToString();
            //}
            //else if (lblDetails.Text == "Film Welding Machine")
            //{
            //    btnSelectProcess.Text = "Film Welding Machine".ToString();
            //}
            //else if (lblDetails.Text == "All Workbench/Conveyor")
            //{
            //    btnSelectProcess.Text = "All Workbench/Conveyor".ToString();
            //}
            //else if (lblDetails.Text == "Before sensor arm attachment/Before Cap Pressing(Sequence Change)")
            //{
            //    btnSelectProcess.Text = "Before sensor arm attachment/Before Cap Pressing(Sequence Change)".ToString();
            //}
            //else if (lblDetails.Text == "Arm cover attachment")
            //{
            //    btnSelectProcess.Text = "Arm cover attachment".ToString();
            //}
            //else if (lblDetails.Text == "After arm cover attachment")
            //{
            //    btnSelectProcess.Text = "After arm cover attachment".ToString();
            //}
            //else if (lblDetails.Text == "Unloading of FW pallet jig")
            //{
            //    btnSelectProcess.Text = "Unloading of FW pallet jig".ToString();
            //}
            //else if (lblDetails.Text == "Inspection")
            //{
            //    btnSelectProcess.Text = "Inspection".ToString();
            //}
            //else if (lblDetails.Text == "Finished Goods")
            //{
            //    btnSelectProcess.Text = "Finished Goods".ToString();
            //}
            //else if (lblDetails.Text == "Winder")
            //{
            //    btnSelectProcess.Text = "Winder".ToString();
            //}
            //else if (lblDetails.Text == "Packing")
            //{
            //    btnSelectProcess.Text = "Packing".ToString();
            //}
            //else if (lblDetails.Text == "Assembly")
            //{
            //    btnSelectProcess.Text = "Assembly".ToString();
            //}
            //else if (lblDetails.Text == "A10")
            //{
            //    btnSelectProcess.Text = "A10".ToString();
            //}
            //else if (lblDetails.Text == "A11")
            //{
            //    btnSelectProcess.Text = "A11".ToString();
            //}
            //else if (lblDetails.Text == "A12")
            //{
            //    btnSelectProcess.Text = "A12".ToString();
            //}
            //else if (lblDetails.Text == "A13")
            //{
            //    btnSelectProcess.Text = "A13".ToString();
            //}
            //else if (lblDetails.Text == "A14")
            //{
            //    btnSelectProcess.Text = "A14".ToString();
            //}
            //else if (lblDetails.Text == "A15")
            //{
            //    btnSelectProcess.Text = "A15".ToString();
            //}
            //else if (lblDetails.Text == "A16")
            //{
            //    btnSelectProcess.Text = "A16".ToString();
            //}
            //else if (lblDetails.Text == "A17")
            //{
            //    btnSelectProcess.Text = "A17".ToString();
            //}
            //else if (lblDetails.Text == "A18")
            //{
            //    btnSelectProcess.Text = "A18".ToString();
            //}
            //else if (lblDetails.Text == "A19")
            //{
            //    btnSelectProcess.Text = "A19".ToString();
            //}
            //else if (lblDetails.Text == "A20")
            //{
            //    btnSelectProcess.Text = "A20".ToString();
            //}
            //else if (lblDetails.Text == "A21")
            //{
            //    btnSelectProcess.Text = "A21".ToString();
            //}
            //else if (lblDetails.Text == "A22")
            //{
            //    btnSelectProcess.Text = "A22".ToString();
            //}
            //else if (lblDetails.Text == "B08")
            //{
            //    btnSelectProcess.Text = "B08".ToString();
            //}
            //else if (lblDetails.Text == "B10")
            //{
            //    btnSelectProcess.Text = "B10".ToString();
            //}
            //else if (lblDetails.Text == "B11")
            //{
            //    btnSelectProcess.Text = "B11".ToString();
            //}
            //else if (lblDetails.Text == "B12")
            //{
            //    btnSelectProcess.Text = "B12".ToString();
            //}
            //else if (lblDetails.Text == "B13")
            //{
            //    btnSelectProcess.Text = "B13".ToString();
            //}
            //else if (lblDetails.Text == "B15")
            //{
            //    btnSelectProcess.Text = "B15".ToString();
            //}
            //else if (lblDetails.Text == "B14")
            //{
            //    btnSelectProcess.Text = "B14".ToString();
            //}
            //else if (lblDetails.Text == "B16")
            //{
            //    btnSelectProcess.Text = "B16".ToString();
            //}
            //else if (lblDetails.Text == "B17")
            //{
            //    btnSelectProcess.Text = "B17".ToString();
            //}
            //else if (lblDetails.Text == "B18")
            //{
            //    btnSelectProcess.Text = "B18".ToString();
            //}
            //else if (lblDetails.Text == "B19")
            //{
            //    btnSelectProcess.Text = "B19".ToString();
            //}
            //else if (lblDetails.Text == "B20")
            //{
            //    btnSelectProcess.Text = "B20".ToString();
            //}
            //else if (lblDetails.Text == "B21")
            //{
            //    btnSelectProcess.Text = "B21".ToString();
            //}
            //else if (lblDetails.Text == "B22")
            //{
            //    btnSelectProcess.Text = "B22".ToString();
            //}
            //else if (lblDetails.Text == "B23")
            //{
            //    btnSelectProcess.Text = "B23".ToString();
            //}
            //else if (lblDetails.Text == "C08")
            //{
            //    btnSelectProcess.Text = "C08".ToString();
            //}
            //else if (lblDetails.Text == "C09")
            //{
            //    btnSelectProcess.Text = "C09".ToString();
            //}
            //else if (lblDetails.Text == "C10")
            //{
            //    btnSelectProcess.Text = "C10".ToString();
            //}
            //else if (lblDetails.Text == "C11")
            //{
            //    btnSelectProcess.Text = "C11".ToString();
            //}
            //else if (lblDetails.Text == "C12")
            //{
            //    btnSelectProcess.Text = "C12".ToString();
            //}
            //else if (lblDetails.Text == "C13")
            //{
            //    btnSelectProcess.Text = "C13".ToString();
            //}
            //else if (lblDetails.Text == "C14")
            //{
            //    btnSelectProcess.Text = "C14".ToString();
            //}
            //else if (lblDetails.Text == "C15")
            //{
            //    btnSelectProcess.Text = "C15".ToString();
            //}
            //else if (lblDetails.Text == "C16")
            //{
            //    btnSelectProcess.Text = "C16".ToString();
            //}
            //else if (lblDetails.Text == "C17")
            //{
            //    btnSelectProcess.Text = "C17".ToString();
            //}
            //else if (lblDetails.Text == "C18")
            //{
            //    btnSelectProcess.Text = "C18".ToString();
            //}
            //else if (lblDetails.Text == "C19")
            //{
            //    btnSelectProcess.Text = "C19".ToString();
            //}
            //else if (lblDetails.Text == "C20")
            //{
            //    btnSelectProcess.Text = "C20".ToString();
            //}
            //else if (lblDetails.Text == "C21")
            //{
            //    btnSelectProcess.Text = "C21".ToString();
            //}
            //else if (lblDetails.Text == "D16")
            //{
            //    btnSelectProcess.Text = "D16".ToString();
            //}
            //else if (lblDetails.Text == "Form Control")
            //{
            //    btnSelectProcess.Text = "Form Control".ToString();
            //}
            //else if (lblDetails.Text == "Warehouse")
            //{
            //    btnSelectProcess.Text = "Warehouse".ToString();
            //}
            //else if (lblDetails.Text == "Manufacturing Site")
            //{
            //    btnSelectProcess.Text = "Manufacturing Site".ToString();
            //}
            //else if (lblDetails.Text == "Quality Control")
            //{
            //    btnSelectProcess.Text = "Quality Control".ToString();
            //}
            //else if (lblDetails.Text == "Maintenance Unit")
            //{
            //    btnSelectProcess.Text = "Maintenance Unit".ToString();
            //}
            //else if (lblDetails.Text == "Panel")
            //{
            //    btnSelectProcess.Text = "Panel".ToString();
            //}
            //else if (lblDetails.Text == "Scanner")
            //{
            //    btnSelectProcess.Text = "Scanner".ToString();
            //}
            //else if (lblDetails.Text == "Scanner (Special)")
            //{
            //    btnSelectProcess.Text = "Scanner (Special)".ToString();
            //}
            //else if (lblDetails.Text == "Sub-unit (PS)")
            //{
            //    btnSelectProcess.Text = "Sub-unit (PS)".ToString();
            //}
            //else if (lblDetails.Text == "Packing")
            //{
            //    btnSelectProcess.Text = "Packing".ToString();
            //}
            //else if (lblDetails.Text == "Packing Repair")
            //{
            //    btnSelectProcess.Text = "Packing Repair".ToString();
            //}
            //else if (lblDetails.Text == "Main Assembly")
            //{
            //    btnSelectProcess.Text = "Main Assembly".ToString();
            //}
            //else if (lblDetails.Text == "Sub Assembly")
            //{
            //    btnSelectProcess.Text = "Sub Assembly".ToString();
            //}
            //else if (lblDetails.Text == "Pre-Soldering")
            //{
            //    btnSelectProcess.Text = "Pre-Soldering".ToString();
            //}
            //else if (lblDetails.Text == "FFC Soldering")
            //{
            //    btnSelectProcess.Text = "FFC Soldering".ToString();
            //}
            //else if (lblDetails.Text == "Front Coat and Lot Stamping")
            //{
            //    btnSelectProcess.Text = "Front Coat and Lot Stamping".ToString();
            //}
            //else if (lblDetails.Text == "Attachment of Head")
            //{
            //    btnSelectProcess.Text = "Attachment of Head".ToString();
            //}
            //else if (lblDetails.Text == "Resistance Checker")
            //{
            //    btnSelectProcess.Text = "Resistance Checker".ToString();
            //}
            //else if (lblDetails.Text == "Visual Checking")
            //{
            //    btnSelectProcess.Text = "Visual Checking".ToString();
            //}
            //else if (lblDetails.Text == "Protect Seal")
            //{
            //    btnSelectProcess.Text = "Protect Seal".ToString();
            //}
            //else if (lblDetails.Text == "Chassis 1")
            //{
            //    btnSelectProcess.Text = "Chassis 1".ToString();
            //}
            //else if (lblDetails.Text == "Chassis 2")
            //{
            //    btnSelectProcess.Text = "Chassis 2".ToString();
            //}
            //else if (lblDetails.Text == "Side Sensor Assy")
            //{
            //    btnSelectProcess.Text = "Side Sensor Assy".ToString();
            //}
            //else if (lblDetails.Text == "Cutter Lever Assy")
            //{
            //    btnSelectProcess.Text = "Cutter Lever Assy".ToString();
            //}
            //else if (lblDetails.Text == "Main PCB Assy")
            //{
            //    btnSelectProcess.Text = "Main PCB Assy".ToString();
            //}
            //else if (lblDetails.Text == "Cutter Sensor Assy")
            //{
            //    btnSelectProcess.Text = "Cutter Sensor Assy".ToString();
            //}
            //else if (lblDetails.Text == "Harnessing")
            //{
            //    btnSelectProcess.Text = "Harnessing".ToString();
            //}
            //else if (lblDetails.Text == "6 Screwing")
            //{
            //    btnSelectProcess.Text = "6 Screwing".ToString();
            //}
            //else if (lblDetails.Text == "Motor Checking")
            //{
            //    btnSelectProcess.Text = "Motor Checking".ToString();
            //}
            //else if (lblDetails.Text == "Destination Printing")
            //{
            //    btnSelectProcess.Text = "Destination Printing".ToString();
            //}
            //else if (lblDetails.Text == "Panel Attachment/ Keypad Checking")
            //{
            //    btnSelectProcess.Text = "Panel Attachment/ Keypad Checking".ToString();
            //}
            //else if (lblDetails.Text == "Inspection 1")
            //{
            //    btnSelectProcess.Text = "Inspection 1".ToString();
            //}
            //else if (lblDetails.Text == "Inspection 2")
            //{
            //    btnSelectProcess.Text = "Inspection 2".ToString();
            //}
            //else if (lblDetails.Text == "Repair Table")
            //{
            //    btnSelectProcess.Text = "Repair Table".ToString();
            //}
            //else if (lblDetails.Text == "SUB DAMPER")
            //{
            //    btnSelectProcess.Text = "SUB DAMPER".ToString();
            //}
            //else if (lblDetails.Text == "Scanner-Unit")
            //{
            //    btnSelectProcess.Text = "Scanner-Unit".ToString();
            //}
            //else if (lblDetails.Text == "Sub-Unit Ink Refill")
            //{
            //    btnSelectProcess.Text = "Sub-Unit Ink Refill".ToString();
            //}
            //else if (lblDetails.Text == "Sub-Unit Power Supply")
            //{
            //    btnSelectProcess.Text = "Sub-Unit Power Supply".ToString();
            //}
        }
        private void jeButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN aaa = new LOGIN();
            aaa.ShowDialog();
            this.Close();
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(36, 9, 53);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
               
            }
        }
             private void DisableButton()
        {
            if (currentBtn != null)
            {

                currentBtn.BackColor = Color.FromArgb(36, 9, 53);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;

            }
        }
        private void QAPSAuditForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void btnEngineAssembly_Click(object sender, EventArgs e)
        {
   
            QAPSAuditForm(new Engine_Assembly());
            
            
            btnSelectProcess.BackColor = Color.SteelBlue;


            btnSelectProcess.Enabled = false;
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Section_Checksheet aaa = new Section_Checksheet();
            aaa.ShowDialog();
            this.Close();
        }

        private void jeButton2_Click(object sender, EventArgs e)
        {

        }

        private void jeButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pending_Approval aaa = new Pending_Approval();
            aaa.ShowDialog();
            this.Close();
        }

        private void jeButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Import_Master_Data aaa = new Import_Master_Data();
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

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed in DASHBOARD?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //Do Something
                this.Hide();
                lblManual aaa = new lblManual();
                aaa.ShowDialog();
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do Nothing
            }
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to LOGOUT in the middle of AUDIT?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //Do Something
                this.Hide();
                LOGIN aaa = new LOGIN();
                aaa.ShowDialog();
                this.Close();

               // PSCategory.ActiveForm.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do Nothing
            }
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Audit_Checksheet_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Common.ReleaseCapture();
                Common.SendMessage(Handle, Common.WM_NCLBUTTONDOWN, Common.HT_CAPTION, 0);
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnNewAudit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Create new AUDIT?", "Verification!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                PSCategory eron = new PSCategory();
                eron.ShowDialog();
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do Nothing
            }
        }
    }
}
