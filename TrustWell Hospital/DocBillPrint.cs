using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class DocBillPrint: Form
    {
        private int Docid;
        private string DoctorName;
        private string Special;
        private int Fee;
        private string PatientName;
        private string RefNo;
        private string PatientMobile;
        private string DocAppDay;
        private int bill;
        //d_t.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public DocBillPrint(int doctorID,string docName, string spec,int fees , string patientname , string refno,string patientmobile ,string doctorAppointmentDate)
        {
            Docid = doctorID;
            DoctorName = docName;
            Special = spec;
            Fee = fees;
            PatientName = patientname;
            RefNo = refno;
            PatientMobile = patientmobile;
            DocAppDay = doctorAppointmentDate;
            InitializeComponent();
            LoadHosphitalFee();
            LoadRoomNo();


            label6.Text = $"Patient Name : {PatientName}";
            label8.Text = $"RefNo : {RefNo + data}";
            label7.Text = $"Patient Mobile : {PatientMobile}";
            label9.Text = $"Date & Time : {DocAppDay}";
            label10.Text = $"Patient No : {PatientName}";

            label12.Text = $"Consultant : {DoctorName}";
            label13.Text = $"Speciality : {Special}";


            label14.Text = $"Doctor Charges : {Fee}";



            bill = int.Parse(hosp_price);
            //int total = Fee + hosfee;
            label16.Text = $"Total : {Fee + bill}";


            label17.Text = $"Invoice date : {DateTime.Now.ToString("yyyy-MM-dd")}";
        }

        public string data;
        private void LoadRoomNo()
        {
            string query = "SELECT * FROM Doc_availability Where DoctorID = @DOCID";
            MySqlParameter[] parameters = {
            new MySqlParameter("@DOCID", Docid)
        };

            DataTable dt = Database.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                data =  row["RoomNo"].ToString();

                label15.Text = "Room No:" + data;
            }
        }

        public string hosp_price;
        private void LoadHosphitalFee()
        {
            //eception handeling :::
            try
            {
                string query = "SELECT * FROM Hospital Where ID = 1";

                MySqlParameter[] parameters = new MySqlParameter[0];

                DataTable dt = Database.ExecuteQuery(query , parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    hosp_price = row["Price"].ToString();

                    label19.Text = "Hosphital Fees: " + hosp_price;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Loading the Hosphital Charges:::");
                Console.WriteLine(ex);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            e.Graphics.DrawImage(bmp, 0, 0);

        }

        private void DocBillPrint_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
